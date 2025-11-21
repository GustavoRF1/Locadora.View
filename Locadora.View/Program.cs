using Locadora.Models;
using Locadora.Controller;



//Cliente cliente = new Cliente("Outro Nome com Documento", "j@j.com");
//Documento documento = new Documento("CPF", "1324567891", DateOnly.Parse("2020-01-15"), DateOnly.Parse("2030-01-15"));
//Documento documento = new Documento(cliente.ClienteID, "RG", "123456789", DateOnly.Parse("2015-05-20"), DateOnly.Parse("2025-05-20"));

//Console.WriteLine(cliente);

//Categoria categoria = new Categoria("Esportivo", "Carro para gente rica e maluca", 280.00);

var categoriaController = new CategoriaController();

//try
//{
//    categoriaController.AdicionarCategoria(categoria);
//}
//catch (Exception ex)
//{
//    Console.Write(ex.Message);
//}

//try
//{
//    clienteController.AdicionarCliente(cliente, documento);
//}
//catch (Exception ex)
//{
//    Console.Write(ex.Message);
//}

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
//    var listaDeCategorias = categoriaController.ListarTodasCategorias();

//    foreach (var c in listaDeCategorias)
//    {
//        Console.WriteLine(c);
//    }
//}
//catch (Exception ex)
//{
//    Console.Write(ex.Message);
//}

categoriaController.AtualizarDescricao("Relâmpago Marquinhos", "Esportivo");
Console.WriteLine(categoriaController.BuscarCategoriaPorNome("Esportivo"));

//try
//{
//    Console.WriteLine(categoriaController.BuscarCategoriaPorNome("Esportivo"));
//    categoriaController.ExcluirCategoriaPorNome("Esportivo");
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    clienteController.AtualizarDocumentoCliente(documento, "j@j.com");

//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}