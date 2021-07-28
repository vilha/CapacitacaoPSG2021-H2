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
    public class RegiaoRepository : GenericRepository<DbContext, Regiao>
    {
        public RegiaoRepository(DbContext contexto) : base(contexto)
        { }
    }
}