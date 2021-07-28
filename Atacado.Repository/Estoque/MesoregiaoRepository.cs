using Atacado.Repository.Ancestor;
using Atacado.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Atacado.Repository.Estoque
{
    public class MesoregiaoRepository : GenericRepository<DbContext, Mesoregiao>
    {
        public MesoregiaoRepository(DbContext contexto) : base(contexto)
        { }
    }
}
