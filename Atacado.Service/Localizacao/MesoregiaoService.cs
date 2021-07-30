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
    public class MesoregiaoService :
        GenericService<DbContext, Mesoregiao, MesoregiaoPoco>,
        IService<MesoregiaoPoco>
    {
        public MesoregiaoService(DbContext contexto)
        {
            this.repositorio = new MesoregiaoRepository(contexto);
            this.mapa = new MesoregiaoMap();
        }

        public MesoregiaoPoco Obter(int id)
        {
            Mesoregiao dominio = this.repositorio.Read(mes => mes.MesoregiaoID == id);
            MesoregiaoPoco poco = this.mapa.GetMapper.Map<MesoregiaoPoco>(dominio);
            return poco;
        }

        public IEnumerable<MesoregiaoPoco> ObterTodos()
        {
            List<Mesoregiao> lista = this.repositorio.Browsable().ToList();
            List<MesoregiaoPoco> listaPoco = this.mapa.GetMapper.Map<List<MesoregiaoPoco>>(lista);
            return listaPoco;
        }

        public MesoregiaoPoco Atualizar(MesoregiaoPoco poco)
        {
            Mesoregiao meso = this.mapa.GetMapper.Map<Mesoregiao>(poco);
            Mesoregiao alterada = this.repositorio.Edit(meso);
            MesoregiaoPoco novoPoco = this.mapa.GetMapper.Map<MesoregiaoPoco>(alterada);
            return novoPoco;
        }

        public MesoregiaoPoco Excluir(int id)
        {
            Mesoregiao meso = this.repositorio.Read(reg => reg.MesoregiaoID == id);
            MesoregiaoPoco poco = this.mapa.GetMapper.Map<MesoregiaoPoco>(meso);
            this.repositorio.Delete(meso);
            return poco;
        }

        public MesoregiaoPoco Incluir(MesoregiaoPoco poco)
        {
            Mesoregiao meso = this.mapa.GetMapper.Map<Mesoregiao>(poco);
            Mesoregiao nova = this.repositorio.Add(meso);
            MesoregiaoPoco novoPoco = this.mapa.GetMapper.Map<MesoregiaoPoco>(nova);
            return novoPoco;
        }

        public void Dispose()
        {
            this.repositorio = null;
            this.mapa = null;
        }
    }
}
