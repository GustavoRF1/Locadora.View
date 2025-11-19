using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class ClienteController
    {
       public void AdicionarCliente(Cliente cliente)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            
            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Cliente.INSERTCLIENTE, connection, transaction);

                    command.Parameters.AddWithValue("@NOME", cliente.Nome);
                    command.Parameters.AddWithValue("@EMAIL", cliente.Email);
                    command.Parameters.AddWithValue("@TELEFONE", cliente.Telefone ?? (object)DBNull.Value);

                    cliente.setClienteID(Convert.ToInt32(command.ExecuteScalar()));

                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar cliente." + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

       public List<Cliente> ListarTodosClientes()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Cliente.SELECTALLCLIENTES, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Cliente> clientes = new List<Cliente>();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente(
                        reader["NOME"].ToString()!,
                        reader["EMAIL"].ToString()!,
                        reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null
                    );
                    cliente.setClienteID(Convert.ToInt32(reader["CLIENTEID"]));
                    clientes.Add(cliente);
                }

                connection.Close();

                return clientes;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar clientes." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao listar clientes." + ex.Message);
            }
            finally 
            { 
                connection.Close();
            }            
        }

       public Cliente BuscarClientePorEmail(string email)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand(Cliente.SELECTCLIENTEPOREMAIL, connection);

                command.Parameters.AddWithValue("@EMAIL", email);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Cliente cliente = new Cliente(
                        reader["NOME"].ToString()!,
                        reader["EMAIL"].ToString()!,
                        reader["TELEFONE"] != DBNull.Value ? reader["TELEFONE"].ToString() : null
                    );
                    cliente.setClienteID(Convert.ToInt32(reader["CLIENTEID"]));
                    return cliente;
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar cliente por email." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar cliente por email." + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

       public void AtualizarTelefoneCliente(string telefone, string email)
        {
            var clienteEncontrado = BuscarClientePorEmail(email);

            if (clienteEncontrado is null)
            {
                throw new Exception("Não existe cliente com esse email cadastrado!");
            }

            clienteEncontrado.setTelefone(telefone);

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand(Cliente.UPDATEFONECLIENTE, connection);
                command.Parameters.AddWithValue("@TELEFONE", clienteEncontrado.Telefone);
                command.Parameters.AddWithValue("@CLIENTEID", clienteEncontrado.ClienteID);
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao atualizar telefone do cliente." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao atualizar telefone do cliente." + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
