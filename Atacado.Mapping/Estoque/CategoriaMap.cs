using Atacado.DAL.Model;
using Atacado.Mapping.Ancestor;
using Atacado.POCO.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Mapping.Estoque
{
    public class CategoriaMap : BaseMapping
    {
        public CategoriaMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<categoria, CategoriaPoco>()
                    .ForMember(dst => dst.Categoriaid, map => map.MapFrom(src => src.catid))
                    .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.datainsert));

                cfg.CreateMap<CategoriaPoco, categoria>()
                    .ForMember(dst => dst.catid, map => map.MapFrom(src => src.Categoriaid))
                    .ForMember(dst => dst.datainsert, map => map.MapFrom(src => (src.DataInclusao.HasValue ? src.DataInclusao.Value : DateTime.Now)));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}
