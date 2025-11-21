using Locadora.Models;
using Locadora.Controller;
using Locadora.Models.Enums;



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

//categoriaController.AtualizarDescricao("Relâmpago Marquinhos", "Esportivo");
//Console.WriteLine(categoriaController.BuscarCategoriaPorNome("Esportivo"));

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

//var veiculoController = new VeiculoController();

//try
//{
//    var veiculo = new Veiculo(1, "ABC-1234", "Chevrolet", "Camaro", 2025, EStatusVeiculo.Disponivel.ToString());
//    veiculoController.AdicionarVeiculo(veiculo);
//    veiculoController.ListarTodosVeiculos();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

var veiculoController = new VeiculoController();

//try
//{
//    var veiculo = veiculoController.ListarTodosVeiculos();

//    foreach (var v in veiculo)
//    {
//        Console.WriteLine(v);
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var veiculo = veiculoController.BuscarVeiculoPlaca("JKL3456");
//    Console.WriteLine(veiculo);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//try
//{
//    var veiculo = veiculoController.BuscarVeiculoPlaca("ASD1234");
//    veiculoController.DeletarVeiculo(veiculo.VeiculoID);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
try 
{
    Console.WriteLine(veiculoController.BuscarVeiculoPlaca("MNO7890"));
    veiculoController.AtualizarStatusVeiculo(EStatusVeiculo.Manutencao.ToString(), "MNO7890");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}