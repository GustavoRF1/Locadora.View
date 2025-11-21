using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Databases;

namespace Locadora.Controller
{
    public class CategoriaController
    {
        public void AdicionarCategoria(Categoria categoria)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Categoria.INSERTCATEGORIA, connection, transaction);

                    command.Parameters.AddWithValue("@NOME", categoria.Nome);
                    command.Parameters.AddWithValue("@DESCRICAO", categoria.Descricao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DIARIA", categoria.Diaria);

                    int categoriaId = Convert.ToInt32(command.ExecuteScalar());

                    categoria.setCategoriaId(categoriaId);

                    transaction.Commit();
                }
                catch (SqlException sqlEx)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categoria. Detalhes: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao adicionar categoria." + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public List<Categoria> ListarTodasCategorias()
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(Categoria.SELECTALLCATEGORIAS, connection);

                SqlDataReader reader = command.ExecuteReader();

                List<Categoria> categorias = new List<Categoria>();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria(
                        reader["Nome"].ToString()!,
                        reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : null,
                        double.Parse(reader["Diaria"].ToString()!)
                    );
                    categoria.setCategoriaId(Convert.ToInt32(reader["CategoriaId"]));

                    categorias.Add(categoria);
                }

                connection.Close();

                return categorias;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao listar categorias." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao listar categorias." + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public Categoria BuscarCategoriaPorNome(string nome)
        {
            var connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();

            try
            {
                SqlCommand command = new SqlCommand(Categoria.SELECTCATEGORIAPORNOME, connection);

                command.Parameters.AddWithValue("@Nome", nome);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Categoria categoria = new Categoria(
                        reader["Nome"].ToString()!,
                        reader["Descricao"] != DBNull.Value ? reader["Descricao"].ToString() : null,
                        double.Parse(reader["Diaria"].ToString()!)
                    );
                    categoria.setCategoriaId(Convert.ToInt32(reader["CategoriaId"]));

                    return categoria;
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao buscar categoria." + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado ao buscar categoria." + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void AtualizarDiaria(double diaria, string nome)
        {
            var categoriaEncontrada = BuscarCategoriaPorNome(nome);

            if (categoriaEncontrada is null)
            {
                throw new Exception("Não existe essa categoria");
            }

            categoriaEncontrada.setDiaria(diaria);

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Categoria.UPDATEDIARIACATEGORIA, connection, transaction);
                    command.Parameters.AddWithValue("@Diaria", categoriaEncontrada.Diaria);
                    command.Parameters.AddWithValue("@CategoriaId", categoriaEncontrada.CategoriaId);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar categoria." + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar categoria." + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void AtualizarDescricao(string descricao, string nome)
        {
            var categoriaEncontrada = BuscarCategoriaPorNome(nome);

            if (categoriaEncontrada is null)
            {
                throw new Exception("Não existe essa categoria");
            }

            categoriaEncontrada.setDescricao(descricao);

            SqlConnection connection = new SqlConnection(ConnectionDB.GetConnectionString());

            connection.Open();
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    SqlCommand command = new SqlCommand(Categoria.UPDATEDESCRICAOCATEGORIA, connection, transaction);
                    command.Parameters.AddWithValue("@Descricao", categoriaEncontrada.Descricao);
                    command.Parameters.AddWithValue("@CategoriaId", categoriaEncontrada.CategoriaId);

                    command.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro ao atualizar categoria." + ex.Message);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("Erro inesperado ao atualizar categoria." + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void ExcluirCategoriaPorNome(string categoria)
            {
                var categoriaEncontrada = BuscarCategoriaPorNome(categoria);

                if (categoriaEncontrada is null)
                {
                    throw new Exception("Categoria não encontrada");
                }

                var connection = new SqlConnection(ConnectionDB.GetConnectionString());

                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(Categoria.DELETECATEGORIAPORNOME, connection, transaction);

                        command.Parameters.AddWithValue("@CategoriaId", categoriaEncontrada.CategoriaId);

                        command.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro ao excluir categoria." + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Erro inesperado ao excluir categoria." + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }

            }
    }
}
