using System;

namespace Atacado.POCO.Model
{
    public class MesoregiaoPoco
    {
        public int MesoregiaoID { get; set; }

        public string Descricao { get; set; }

        public int UFID { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
