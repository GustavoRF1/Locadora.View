using Locadora.Controller.Interfaces;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Databases;

namespace Locadora.Controller
{
    public class VeiculoController : IVeiculoController
    {
        public void AdicionarVeiculo(Veiculo veiculo)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Veiculo.INSERTVEICULO, connection, transaction);
                    command.Parameters.AddWithValue("@CategoriaID", veiculo.CategoriaID);
                    command.Parameters.AddWithValue("@Marca", veiculo.Marca);
                    command.Parameters.AddWithValue("@Modelo", veiculo.Modelo);
                    command.Parameters.AddWithValue("@Ano", veiculo.Ano);
                    command.Parameters.AddWithValue("@Placa", veiculo.Placa);
                    command.Parameters.AddWithValue("@StatusVeiculo", veiculo.StatusVeiuclo);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar veículo: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao adicionar veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarStatusVeiculo(string statusVeiculo, string placa)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            var veiculo = BuscarVeiculoPlaca(placa) ?? 
                throw new Exception("Veículo não entrontrado para atualizar status.");

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Veiculo.UPDATESTATUSVEICULO, connection, transaction);
                    command.Parameters.AddWithValue("@StatusVeiculo", statusVeiculo);
                    command.Parameters.AddWithValue("@Placa", placa);

                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar status do veículo: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar status do veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Veiculo BuscarVeiculoPlaca(string placa)
        {
            var categoriaController = new CategoriaController();

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            Veiculo veiculo = null;

            connection.Open();

            using (SqlCommand command = new SqlCommand(Veiculo.SELECTVEICULOBYPLACA, connection))
            {
                try
                {
                    command.Parameters.AddWithValue("@Placa", placa);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                            veiculo = new Veiculo(
                            reader.GetInt32(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetInt32(5),
                            reader.GetString(6)
                        );

                        veiculo.setVeiculoID(reader.GetInt32(0));

                        veiculo.setCategoriaNome(categoriaController.BuscarCategoriaPorID(veiculo.CategoriaID));
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao listar veículos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao listar veículos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return veiculo ?? throw new Exception("Veículo não encontrado");
            }
        }
        
        public void DeletarVeiculo(int idVeiculo)
        {
            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();


            using(SqlTransaction transaction = connection.BeginTransaction())
            {

                SqlCommand command = new SqlCommand(Veiculo.DELETEVEICULO, connection, transaction);
                try
                {
                    command.Parameters.AddWithValue("@IdVeiculo", idVeiculo);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao deletar veículo: " + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao deletar veículo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Veiculo> ListarTodosVeiculos()
        {
            var veiculos = new List<Veiculo>();
            var categoriaController = new CategoriaController();

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            using (SqlCommand command = new SqlCommand(Veiculo.SELECTALLVEICULOS, connection))
            {
                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Veiculo veiculo = new Veiculo(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetInt32(4),
                            reader.GetString(5)
                        );

                        veiculo.setCategoriaNome(categoriaController.BuscarCategoriaPorID(veiculo.CategoriaID));

                        veiculos.Add(veiculo);
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Erro ao listar veículos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro inesperado ao listar veículos: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return veiculos;
            }
        }
    }
}
