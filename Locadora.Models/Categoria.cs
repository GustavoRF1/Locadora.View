using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Models
{
    public class Categoria
    {
        public readonly static string INSERTCATEGORIA = "INSERT INTO tblCategorias VALUES (@Nome, @Descricao, @Diaria); " +
                                                      "SELECT SCOPE_IDENTITY();";

        public readonly static string SELECTALLCATEGORIAS = "SELECT * FROM tblCategorias;";

        public readonly static string SELECTCATEGORIAPORNOME = "SELECT * FROM tblCategorias WHERE Nome = @Nome;";

        public readonly static string UPDATEDIARIACATEGORIA = @"UPDATE tblCategorias 
                                                              SET Diaria = @Diaria 
                                                              WHERE CategoriaID = @CategoriaId;";

        public readonly static string UPDATEDESCRICAOCATEGORIA = @"UPDATE tblCategorias 
                                                              SET Descricao = @Descricao 
                                                              WHERE CategoriaID = @CategoriaId;";

        public readonly static string DELETECATEGORIAPORNOME = "DELETE FROM tblCategorias WHERE CategoriaID = @CategoriaId;";

        public int CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public double Diaria { get; private set; }

        public Categoria(string nome, string? descricao, double diaria)
        {
            Nome = nome;
            Descricao = descricao;
            Diaria = diaria;
        }

        public void setDiaria(double diaria)
        {
            Diaria = diaria;
        }
        public void setCategoriaId(int categoriaId)
        {
            CategoriaId = categoriaId;
        }

        public void setDescricao(string? descricao)
        {
            Descricao = descricao;
        }

        public override string? ToString()
        {
            return $"Categoria: {Nome}\n" +
                   $"Descrição: {Descricao}\n" +
                   $"Diária: {Diaria}\n";
        }
    }
}
