using Atacado.POCO.Model;
using Atacado.DAL.Model;
using Atacado.Repository.Localizacao;
using Atacado.Service.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.Mapping.Localizacao;

namespace Atacado.Service.Localizacao
{
    public class UFService :
        GenericService<DbContext, UnidadesFederacao, UFPoco>,
        IService<UFPoco>
    {
        public UFService(DbContext contexto)
        {
            this.repositorio = new UFRepository(contexto);
            this.mapa = new UFMap();
        }

        public UFPoco Obter(int id)
        {
            UnidadesFederacao dominio = this.repositorio.Read(unifed => unifed.UFID == id);
            UFPoco poco = this.mapa.GetMapper.Map<UFPoco>(dominio);
            return poco;
        }

        public IEnumerable<UFPoco> ObterTodos()
        {
            List<UnidadesFederacao> lista = this.repositorio.Browsable().ToList();
            List<UFPoco> listaPoco = this.mapa.GetMapper.Map<List<UFPoco>>(lista);
            return listaPoco;
        }

        public UFPoco Atualizar(UFPoco poco)
        {
            UnidadesFederacao unifed = this.mapa.GetMapper.Map<UnidadesFederacao>(poco);
            UnidadesFederacao alterada = this.repositorio.Edit(unifed);
            UFPoco novoPoco = this.mapa.GetMapper.Map<UFPoco>(alterada);
            return novoPoco;
        }

        public UFPoco Excluir(int id)
        {
            UnidadesFederacao unifed = this.repositorio.Read(reg => reg.UFID == id);
            UFPoco poco = this.mapa.GetMapper.Map<UFPoco>(unifed);
            this.repositorio.Delete(unifed);
            return poco;
        }

        public UFPoco Incluir(UFPoco poco)
        {
            UnidadesFederacao unifed = this.mapa.GetMapper.Map<UnidadesFederacao>(poco);
            UnidadesFederacao nova = this.repositorio.Add(unifed);
            UFPoco novoPoco = this.mapa.GetMapper.Map<UFPoco>(nova);
            return novoPoco;
        }

        public void Dispose()
        {
            this.repositorio = null;
            this.mapa = null;
        }
    }
}