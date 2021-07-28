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
    public class MesoregiaoMap : BaseMapping
    {
        public MesoregiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Mesoregiao, MesoregiaoPoco>()
                    .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.datainsert));

                cfg.CreateMap<MesoregiaoPoco, Mesoregiao>()
                    .ForMember(dst => dst.datainsert, map => map.MapFrom(src => (src.DataInclusao.HasValue ? src.DataInclusao.Value : DateTime.Now)));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}