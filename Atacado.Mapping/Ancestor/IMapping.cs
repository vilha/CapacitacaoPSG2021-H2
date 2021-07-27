using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Mapping.Ancestor
{
    public interface IMapping
    {
        IMapper GetMapper { get; set; }
    }
}
