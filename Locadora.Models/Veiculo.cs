using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Veiculo
    {
        public int VeiculoID { get; private set; }
        public int CategoriaID { get; private set; }
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

        public override string? ToString()
        {
            return $"Placa: {Placa}" +
                   $"Marca: {Marca}\n" +
                   $"Modelo: {Modelo}\n" +
                   $"Ano: {Ano}\n" +
                   $"Status do Veículo: {StatusVeiuclo}\n";
        }
    }
}
