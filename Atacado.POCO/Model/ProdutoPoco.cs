using System;

namespace Atacado.POCO.Model
{
    public class ProdutoPoco
    {
        public int ProdutoID { get; set; }

        public int SubcategoriaID { get; set; }

        public int CategoriaID { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
