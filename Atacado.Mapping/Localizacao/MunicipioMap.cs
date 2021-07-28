using Atacado.DAL.Model;
using Atacado.Mapping.Ancestor;
using Atacado.POCO.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Mapping.Localizacao
{
    public class MunicipioMap : BaseMapping
    {
        public MunicipioMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Municipio, MunicipioPoco>();

                cfg.CreateMap<ProdutoPoco, produto>();
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}