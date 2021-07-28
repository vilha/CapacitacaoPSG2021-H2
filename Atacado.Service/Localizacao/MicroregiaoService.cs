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
    public class MicroregiaoService : IService<MicroregiaoPoco>
    {
        private MicroregiaoRepository repositorio;

        private MicroregiaoMap mapa;
        public MicroregiaoService(DbContext contexto)
        {
            this.repositorio = new MicroregiaoRepository(contexto);
            this.mapa = new MicroregiaoMap();
        }

        public MicroregiaoPoco Obter(int id)
        {
            Microregiao dominio = this.repositorio.Read(mic => mic.MicroregiaoID == id);
            MicroregiaoPoco poco = this.mapa.GetMapper.Map<MicroregiaoPoco>(dominio);
            return poco;
        }

        public IEnumerable<MicroregiaoPoco> ObterTodos()
        {
            List<Microregiao> lista = this.repositorio.Browsable().ToList();
            List<MicroregiaoPoco> listaPoco = this.mapa.GetMapper.Map<List<MicroregiaoPoco>>(lista);
            return listaPoco;
        }

        public MicroregiaoPoco Atualizar(MicroregiaoPoco poco)
        {
            Microregiao micro = this.mapa.GetMapper.Map<Microregiao>(poco);
            Microregiao alterada = this.repositorio.Edit(micro);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(alterada);
            return novoPoco;
        }

        public MicroregiaoPoco Excluir(int id)
        {
            Microregiao micro = this.repositorio.Read(reg => reg.MicroregiaoID == id);
            MicroregiaoPoco poco = this.mapa.GetMapper.Map<MicroregiaoPoco>(micro);
            this.repositorio.Delete(micro);
            return poco;
        }

        public MicroregiaoPoco Incluir(MicroregiaoPoco poco)
        {
            Microregiao micro = this.mapa.GetMapper.Map<Microregiao>(poco);
            Microregiao nova = this.repositorio.Add(micro);
            MicroregiaoPoco novoPoco = this.mapa.GetMapper.Map<MicroregiaoPoco>(nova);
            return novoPoco;
        }

    }
}
