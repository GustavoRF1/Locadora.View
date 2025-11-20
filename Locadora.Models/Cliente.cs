namespace Locadora.Models
{
    public class Cliente
    {
        public readonly static string INSERTCLIENTE = "INSERT INTO tblClientes VALUES (@NOME, @EMAIL, @TELEFONE); " +
                                                      "SELECT SCOPE_IDENTITY();";

        public readonly static string SELECTALLCLIENTES = "SELECT * FROM tblClientes;";

        public readonly static string UPDATEFONECLIENTE = "UPDATE tblClientes SET TELEFONE = @TELEFONE " +
                                                          "WHERE CLIENTEID = @CLIENTEID;";

        public readonly static string SELECTCLIENTEPOREMAIL = "SELECT * FROM tblClientes WHERE EMAIL = @EMAIL;";

        public readonly static string SELECTCLIENTEPORID = "SELECT * FROM tblClientes WHERE CLIENTEID = @CLIENTEID;";

        public readonly static string DELETECLIENTEPORID = "DELETE FROM tblClientes WHERE CLIENTEID = @CLIENTEID;";

        public int ClienteID { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string? Telefone { get; private set; } = String.Empty;

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Cliente(string nome, string email, string? telefone) : this(nome, email)
        {
            Telefone = telefone;
        }

        public void setClienteID(int clienteID)
        {
            ClienteID = clienteID;
        }

        public void setTelefone(string telefone)
        {
            Telefone = telefone;
        }

        public override string? ToString()
        {
            return $"Nome: {Nome}\n" +
                $"Email: {Email}\n" +
                $"Telefone: {(Telefone == string.Empty ? "Sem telefone" : Telefone)}\n";
        }
    }
}
