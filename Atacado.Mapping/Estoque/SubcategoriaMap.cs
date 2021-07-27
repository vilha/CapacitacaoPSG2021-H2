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
    public class SubcategoriaMap : BaseMapping
    {
        public SubcategoriaMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<subcategoria, SubcategoriaPoco>()
                    .ForMember(dst => dst.SubcategoriaID, map => map.MapFrom(src => src.subcatid))
                    .ForMember(dst => dst.CategoriaID, map => map.MapFrom(src => src.catid))
                    .ForMember(dst => dst.Descricao, map => map.MapFrom(src => src.descricao))
                    .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.datainsert));
                cfg.CreateMap<SubcategoriaPoco, subcategoria>()
                    .ForMember(dst => dst.subcatid, map => map.MapFrom(src => src.SubcategoriaID))
                    .ForMember(dst => dst.catid, map => map.MapFrom(src => src.CategoriaID))
                    .ForMember(dst => dst.descricao, map => map.MapFrom(src => src.Descricao))
                    .ForMember(dst => dst.datainsert, map => map.MapFrom(src => (src.DataInclusao.HasValue ? src.DataInclusao.Value : DateTime.Now)));
            });
            this.GetMapper = configuration.CreateMapper();
        }
    }
}
