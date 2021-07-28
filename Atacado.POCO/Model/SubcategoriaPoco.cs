﻿using System;

namespace Atacado.POCO.Model
{
    public class SubcategoriaPoco
    {
        public int SubcategoriaID { get; set; }

        public int CategoriaID { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
