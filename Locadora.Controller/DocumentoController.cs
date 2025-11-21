using Locadora.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Utils.Databases;

namespace Locadora.Controller
{
    public class DocumentoController
    {
        public void AdicionarDocumento(Documento documento, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                SqlCommand command = new SqlCommand(Documento.INSERTDOCUMENTO, connection, transaction);

                command.Parameters.AddWithValue("@CLIENTEID", documento.ClienteID);
                command.Parameters.AddWithValue("@TIPODOCUMENTO", documento.TipoDocumento);
                command.Parameters.AddWithValue("@NUMERO", documento.Numero);
                command.Parameters.AddWithValue("@DATAEMISSAO", documento.DataEmissao);
                command.Parameters.AddWithValue("@DATAVALIDADE", documento.DataValidade);

                command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Erro ao adicionar documento. Detalhes: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar documento." + ex.Message);
            }
        }

        public void AtualizarDocumento(Documento documento, SqlConnection connection, SqlTransaction transaction)
        {
            try
            {
                SqlCommand command = new SqlCommand(Documento.UPDATEDOCUMENTO, connection, transaction);

                command.Parameters.AddWithValue("@CLIENTEID", documento.ClienteID);
                command.Parameters.AddWithValue("@TIPODOCUMENTO", documento.TipoDocumento);
                command.Parameters.AddWithValue("@NUMERO", documento.Numero);
                command.Parameters.AddWithValue("@DATAEMISSAO", documento.DataEmissao);
                command.Parameters.AddWithValue("@DATAVALIDADE", documento.DataValidade);

                command.ExecuteNonQuery();
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Erro ao adicionar documento. Detalhes: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar documento." + ex.Message);
            }
        }
    }
}
