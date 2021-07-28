﻿using Atacado.DAL.Model;
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
    public class MicroregiaoMap : BaseMapping
    {
        public MicroregiaoMap()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Microregiao, MicroregiaoPoco>()
                    .ForMember(dst => dst.DataInclusao, map => map.MapFrom(src => src.datainsert));

                cfg.CreateMap<MicroregiaoPoco, Microregiao>()
                    .ForMember(dst => dst.datainsert, map => map.MapFrom(src => (src.DataInclusao.HasValue ? src.DataInclusao.Value : DateTime.Now)));
            });

            this.GetMapper = configuration.CreateMapper();
        }
    }
}