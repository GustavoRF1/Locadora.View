using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Documento
    {
        public static readonly string INSERTDOCUMENTO = "INSERT INTO tblDocumentos (ClienteID, TipoDocumento, Numero, DataEmissao, DataValidade) " +
                                                            "VALUES (@CLIENTEID, @TIPODOCUMENTO, @NUMERO, @DATAEMISSAO, @DATAVALIDADE); " +
                                                            "SELECT SCOPE_IDENTITY();";

        public static readonly string UPDATEDOCUMENTO = @"UPDATE tblDocumentos
                                                          SET TipoDocumento = @TIPODOCUMENTO,
                                                          Numero = @NUMERO,
                                                          DataEmissao = @DATAEMISSAO,
                                                          DataValidade = @DATAVALIDADE
                                                          WHERE ClienteID = @CLIENTEID";

        public int DocumentoID { get; private set; }
        public int ClienteID { get; private set; }
        public string TipoDocumento { get; private set; }
        public string Numero { get; private set; }
        public DateOnly DataEmissao { get; private set; }
        public DateOnly DataValidade { get; private set; }
        
        public Documento(string tipoDocumento, string numero, DateOnly dataEmissao, DateOnly dataValidade)
        {
            TipoDocumento = tipoDocumento;
            Numero = numero;
            DataEmissao = dataEmissao;
            DataValidade = dataValidade;
        }

        public void setClienteID(int clienteID)
        {
            ClienteID = clienteID;
        }

        public override string? ToString()
        {
            return $"Tipo de Documento: {TipoDocumento}\n" +
                $"Número: {Numero}\n" +
                $"Data de Emissão: {DataEmissao}\n" +
                $"Data de Validade: {DataValidade}";
        }
    }
}
