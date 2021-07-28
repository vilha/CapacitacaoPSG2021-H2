using Atacado.Repository.Ancestor;
using Atacado.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Atacado.Repository.Localizacao
{
    public class UFRepository : GenericRepository<DbContext, UnidadesFederacao>
    {
        public UFRepository(DbContext contexto) : base(contexto)
        { }
    }
}