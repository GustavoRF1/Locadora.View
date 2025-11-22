using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Locadora.Models;

namespace Utils.Menus
{
    public class Menus
    {
        public static void ExibirMenuPrincipal()
        {
            int op;
            bool convertido;
            do
            {
                Console.Clear();
                Console.WriteLine("===== Menu Principal =====");
                Console.WriteLine("1. Gerenciar Locações");
                Console.WriteLine("2. Gerenciar Clientes");
                Console.WriteLine("3. Gerenciar Veículos");
                Console.WriteLine("4. Gerenciar Funcionários");
                Console.WriteLine("0. Sair");
                Console.WriteLine("===========================\n");
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
                    ExibirMenuLocacao();
                    break;

                case 2:
                    ExibirMenuClientes();
                    break;

                case 3:
                    ExibirMenuVeiculos();
                    break;

                case 4:
                    ExibirMenuFuncionarios();
                    break;

                case 0:
                    Console.WriteLine("Saindo do sistema...");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        public static void ExibirMenuLocacao()
        {
            int op;
            bool convertido;
            do
            {
                Console.Clear();
                Console.WriteLine("===== Menu de Locações =====");
                Console.WriteLine("1. Adicionar Locação");
                Console.WriteLine("2. Listar Locações");
                Console.WriteLine("3. Buscar Locação Individualmente");
                Console.WriteLine("4. Atualizar Status da Locação");
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

                    Console.WriteLine("\nLocação adicionada com sucesso!");
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("===== Listar Locações =====\n");
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("===== Buscar Locação =====\n");

                    Console.WriteLine("\n===== Locação Encontrada =====\n");
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("===== Alterar Status Locação =====");

                    Console.WriteLine("Status da locação alterado com sucesso");
                    break;

                case 0:
                    ExibirMenuPrincipal();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        

        public static void ExibirMenuVeiculos()
        {
            int op;
            bool convertido;

            do
            {
                Console.Clear();
                Console.WriteLine("===== Menu de Veículos =====");
                Console.WriteLine("1. Adicionar Veículo");
                Console.WriteLine("2. Listar Veículos");
                Console.WriteLine("3. Buscar Veículo Por Placa");
                Console.WriteLine("4. Atualizar Status do Veículo");
                Console.WriteLine("5. Excluir Veículo");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.WriteLine("=============================\n");
                Console.Write("Selecione uma opção: ");
                int.TryParse(Console.ReadLine(), out op);

                if (op >= 0 && op <= 5)
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
                    Console.WriteLine("===== Adicionar Veiculo =====\n");

                    Console.WriteLine("\nVeiculo adicionado com sucesso!");
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("===== Listar Veículos =====\n");
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("===== Buscar Veículo Por Placa =====\n");

                    Console.WriteLine("\n===== Veículo Encontrado =====\n");
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("===== Alterar Status Veículo =====");

                    Console.WriteLine("Status do veículo alterado com sucesso");
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine("===== Remover Veículo =====");

                    Console.WriteLine("Veículo removido com sucesso!");

                    break;

                case 0:
                    ExibirMenuPrincipal();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

        public static void ExibirMenuFuncionarios()
        {
            int op;
            bool convertido;

            do
            {
                Console.Clear();
                Console.WriteLine("===== Menu de Funcionários =====");
                Console.WriteLine("1. Adicionar Funcionário");
                Console.WriteLine("2. Listar Funcionários");
                Console.WriteLine("3. Buscar Funcionário Por CPF");
                Console.WriteLine("4. Atualizar Funcionário");
                Console.WriteLine("5. Excluir Funcionário");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.WriteLine("=================================");
                Console.Write("Selecione uma opção: ");
                int.TryParse(Console.ReadLine(), out op);

                if (op >= 0 && op <= 5)
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
                    Console.WriteLine("===== Adicionar Funcionário =====\n");

                    Console.WriteLine("\nFuncionário adicionado com sucesso!");
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("===== Listar Funcionários =====\n");
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("===== Buscar Funcionário Por CPF =====\n");

                    Console.WriteLine("\n===== Funcionário Encontrado =====\n");
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("===== Alterar Salário Funcionário =====");

                    Console.WriteLine("Salário do funcionário alterado com sucesso");
                    break;

                case 5:
                    Console.Clear();
                    Console.WriteLine("===== Remover Funcionário =====");

                    Console.WriteLine("Funcionário removido com sucesso!");

                    break;

                case 0:
                    ExibirMenuPrincipal();
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
