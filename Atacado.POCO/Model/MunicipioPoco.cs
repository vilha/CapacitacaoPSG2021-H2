using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.POCO.Model
{
    public class MunicipioPoco
    {
        public int MunicipioID { get; set; }

        public int IBGE6 { get; set; }

        public int IBGE7 { get; set; }

        public string Descricao { get; set; }

        public int MesoregiaoID { get; set; }

        public int MicroregiaoID { get; set; }

        public int UFID { get; set; }

        public int? Populacao { get; set; }

        public int? CEP { get; set; }

        public string SiglaUF { get; set; }
    }
}
