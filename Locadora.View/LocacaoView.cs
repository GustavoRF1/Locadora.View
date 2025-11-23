using Locadora.Controller;
using Locadora.Models;
using Microsoft.Data.SqlClient;
using Utils.Inputs;

namespace Locadora.View;

public class LocacaoView
{
    public static void ExibirMenuLocacao()
    {
        int op;
        bool convertido;

        LocacaoController locacaoController = new LocacaoController();
        do
        {
            do
            {
                Console.Clear();
                Console.WriteLine("===== Menu de Locações =====");
                Console.WriteLine("1. Adicionar Locação");
                Console.WriteLine("2. Listar Locações");
                Console.WriteLine("3. Cancelar Locação");
                Console.WriteLine("4. Encerrar Locação");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.WriteLine("=============================\n");
                Console.Write("Selecione uma opção: ");
                int.TryParse(Console.ReadLine(), out op);

                if (op >= 0 && op <= 4)
                {
                    convertido = true;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    convertido = false;
                }
            } while (convertido == false);

            switch (op)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("===== Adicionar Locação =====\n");

                    string cpf = InputHelper.LerString("Digite o CPF do funcionário: ", "CPF inválido");

                    int idCliente = InputHelper.LerInt("Digite o ID do cliente: ", "ID do cliente inválido");
                    int idVeiculo = InputHelper.LerInt("Digite o ID do veículo: ", "ID do veículo inválido");
                    int diasLocacao = InputHelper.LerInt("Digite a quantidade de dias de locação: ",
                        "Dias de locação inválido");

                    Locacao locacao = new Locacao(idCliente, idCliente, DateTime.Now, diasLocacao);

                    try
                    {
                        locacaoController.AdicionarLocacao(locacao, cpf);

                        Console.WriteLine("\nLocação adicionada com sucesso!");

                        Console.ReadKey();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro ao adicionar locação. " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao adicionar locação. " + ex.Message);
                    }
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("===== Listar Locações =====\n");
                    try
                    {
                        var listaLocacoes = new List<Locacao>();

                        listaLocacoes = locacaoController.ListarLocacoes();

                        foreach (var item in listaLocacoes)
                        {
                            Console.WriteLine("=============================");
                            Console.WriteLine(item);
                            Console.WriteLine("=============================\n");
                        }

                        Console.ReadKey();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro ao listar locação. " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao listar locações. " + ex.Message);
                    }
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("===== Cancelar Locação =====\n");

                    var placaCancelar =
                        InputHelper.LerString("Digite a placa do veículo que deseja cancelar: ", "Placa inválida");

                    try
                    {
                        locacaoController.CancelarLocacao(placaCancelar);

                        Console.WriteLine("\nLocação cancelada com sucesso!");

                        Console.ReadKey();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro ao cancelar locação. " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao cancelar locação. " + ex.Message);
                    }

                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("===== Encerrar Locação =====");

                    var placaEncerrar = InputHelper.LerString("Digite a placa que deseja encerrar: ", "Placa inválida");

                    try
                    {
                        locacaoController.EncerrarLocacao(placaEncerrar);

                        Console.WriteLine("Locação encerrada com sucesso");

                        Console.ReadKey();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Erro ao encerrar locação. " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Erro ao encerrar locação. " + ex.Message);
                    }
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        } while (op != 0);
    }
}