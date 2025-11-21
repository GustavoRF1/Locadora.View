using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {
        public readonly static string INSERTVEICULO = @"INSERT INTO tblVeiculos (CategoriaID, Placa, Marca, Modelo, Ano, StatusVeiculo)
                                                VALUES (@CategoriaID, @Placa, @Marca, @Modelo, 
                                                        @Ano, @StatusVeiculo)";

        public readonly static string SELECTALLVEICULOS = @"SELECT CategoriaID, 
                                                    Placa, Marca, Modelo, Ano, StatusVeiculo
                                                    FROM tblVeiculos";

        public readonly static string SELECTVEICULOBYPLACA = @"SELECT VeiculoID, CategoriaID, 
                                                    Placa, Marca, Modelo, Ano, StatusVeiculo
                                                    FROM tblVeiculos
                                                    WHERE Placa = @Placa";

        public readonly static string UPDATESTATUSVEICULO = @"UPDATE tblVeiculos 
                                                    SET StatusVeiculo = @StatusVeiculo
                                                    WHERE Placa = @Placa";

        public readonly static string DELETEVEICULO = @"DELETE FROM tblVeiculos
                                                WHERE VeiculoID = @IdVeiculo";

        public int VeiculoID { get; private set; }
        public int CategoriaID { get; private set; }
        public string CategoriaNome { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Placa { get; private set; }
        public string StatusVeiuclo { get; private set; }
        public Veiculo(int categoriaID, string placa, string marca, string modelo, int ano, string statusVeiuclo)
        {
            CategoriaID = categoriaID;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            StatusVeiuclo = statusVeiuclo;
        }

        public void setVeiculoID(int veiculoID)
        {
            VeiculoID = veiculoID;
        }

        public void setStatusVeiculo(string statusVeiuclo)
        {
            StatusVeiuclo = statusVeiuclo;
        }

        public void setCategoriaNome(string categoriaNome)
        {
            CategoriaNome = categoriaNome;
        }

        public override string? ToString()
        {
            return $"Placa: {Placa}\n" +
                   $"Marca: {Marca}\n" +
                   $"Modelo: {Modelo}\n" +
                   $"Ano: {Ano}\n" +
                   $"Categoria: {CategoriaNome}\n" +
                   $"Status do Veículo: {StatusVeiuclo}\n";
        }
    }
}
