using System;

namespace Atacado.POCO.Model
{
    public class MicroregiaoPoco
    {
        public int MicroregiaoID { get; set; }

        public string Descricao { get; set; }

        public int MesoregiaoID { get; set; }

        public DateTime? DataInclusao { get; set; }
    }
}
