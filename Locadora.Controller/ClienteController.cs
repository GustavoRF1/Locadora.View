using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class ClienteController
    {
       public void AdicionarCliente(Cliente cliente, Documento documento)
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

                    int clienteId= Convert.ToInt32(command.ExecuteScalar());

                    cliente.setClienteID(clienteId);

                    var documentoController = new DocumentoController();

                    documento.setClienteID(clienteId);

                    documentoController.AdicionarDocumento(documento, connection, transaction);

                    transaction.Commit();
                }
                catch (SqlException sqlEx)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar cliente. Detalhes: " + sqlEx.Message);
                }
                catch (Exception ex)
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
                    //cliente.setClienteID(Convert.ToInt32(reader["CLIENTEID"]));

                    var documento = new Documento(
                        reader["TipoDocumento"].ToString(),
                        reader["Numero"].ToString(),
                        DateOnly.FromDateTime(reader.GetDateTime(5)),
                        DateOnly.FromDateTime(reader.GetDateTime(6))
                        );

                    cliente.setDocumento(documento);

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
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

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

                    var documento = new Documento(reader["TipoDocumento"].ToString(),
                                                  reader["Numero"].ToString(),
                                                  DateOnly.FromDateTime(reader.GetDateTime(6)),
                                                  DateOnly.FromDateTime(reader.GetDateTime(7))
                                                  );
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
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Cliente.UPDATEFONECLIENTE, connection, transaction);
                    command.Parameters.AddWithValue("@TELEFONE", clienteEncontrado.Telefone);
                    command.Parameters.AddWithValue("@CLIENTEID", clienteEncontrado.ClienteID);

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar telefone do cliente." + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar telefone do cliente." + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarDocumentoCliente(Documento documento)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    DocumentoController documentoController = new DocumentoController();

                    documentoController.AtualizarDocumento(documento, connection, transaction);

                    transaction.Commit();
                }
                catch(SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar documento do cliente: " + ex.Message);
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar documento do cliente: " + ex.Message);
                }
            }
        }

        public void DeletarCliente(string email)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());
            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                var clienteEncontrado = BuscarClientePorEmail(email);

                if (clienteEncontrado is null)
                    throw new Exception("Cliente não encontrado");

                try
                {
                    SqlCommand command = new SqlCommand(Cliente.DELETECLIENTEPORID, connection, transaction);
                    command.Parameters.AddWithValue("@IdCliente", clienteEncontrado.ClienteID);
                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao deletar cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao deletar cliente" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
