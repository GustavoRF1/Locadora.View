using Locadora.Models;
using Locadora.Controller;



Cliente cliente = new Cliente("Outro Nome B", "d@d.com");
//Documento documento = new Documento(cliente.ClienteID, "RG", "123456789", DateOnly.Parse("2015-05-20"), DateOnly.Parse("2025-05-20"));

Console.WriteLine(cliente);

var clienteController = new ClienteController();

//try
//{
//    clienteController.AdicionarCliente(cliente);
//}
//catch (Exception ex)
//{
//    Console.Write(ex.Message);
//}

//try
//{
//    var listaDeClientes = clienteController.ListarTodosClientes();

//    foreach (var c in listaDeClientes)
//    {
//        Console.WriteLine(c);
//    }
//}
//catch (Exception ex)
//{
//    Console.Write(ex.Message);
//}

clienteController.AtualizarTelefoneCliente("99999999", "d@d.com");
Console.WriteLine(clienteController.BuscarClientePorEmail("d@d.com"));