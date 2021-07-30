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
    public class RegiaoService :
        GenericService<DbContext, Regiao, RegiaoPoco>,
        IService<RegiaoPoco>
    {
        public RegiaoService(DbContext contexto)
        {
            this.repositorio = new RegiaoRepository(contexto);
            this.mapa = new RegiaoMap();
        }

        public RegiaoPoco Obter(int id)
        {
            Regiao dominio = this.repositorio.Read(regiao => regiao.RegiaoID == id);
            RegiaoPoco poco = this.mapa.GetMapper.Map<RegiaoPoco>(dominio);
            return poco;
        }

        public IEnumerable<RegiaoPoco> ObterTodos()
        {
            List<Regiao> lista = this.repositorio.Browsable().ToList();
            List<RegiaoPoco> listaPoco = this.mapa.GetMapper.Map<List<RegiaoPoco>>(lista);
            return listaPoco;
        }

        public RegiaoPoco Atualizar(RegiaoPoco poco)
        {
            Regiao regiao = this.mapa.GetMapper.Map<Regiao>(poco);
            Regiao alterada = this.repositorio.Edit(regiao);
            RegiaoPoco novoPoco = this.mapa.GetMapper.Map<RegiaoPoco>(alterada);
            return novoPoco;
        }

        public RegiaoPoco Excluir(int id)
        {
            Regiao regiao = this.repositorio.Read(reg => reg.RegiaoID == id);
            RegiaoPoco poco = this.mapa.GetMapper.Map<RegiaoPoco>(regiao);
            this.repositorio.Delete(regiao);
            return poco;
        }

        public RegiaoPoco Incluir(RegiaoPoco poco)
        {
            Regiao regiao = this.mapa.GetMapper.Map<Regiao>(poco);
            Regiao nova = this.repositorio.Add(regiao);
            RegiaoPoco novoPoco = this.mapa.GetMapper.Map<RegiaoPoco>(nova);
            return novoPoco;
        }

        public void Dispose()
        {
            this.repositorio = null;
            this.mapa = null;
        }
    }
}
