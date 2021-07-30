using Atacado.POCO.Model;
using Atacado.DAL.Model;
using Atacado.Repository.Estoque;
using Atacado.Service.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.Mapping.Estoque;

namespace Atacado.Service.Estoque
{
    public class CategoriaService :
        GenericService<DbContext, categoria, CategoriaPoco>,
        IService<CategoriaPoco>
    {
        public CategoriaService(DbContext contexto)
        {
            this.repositorio = new CategoriaRepository(contexto);
            this.mapa = new CategoriaMap();
        }

        public CategoriaPoco Obter(int id)
        {
            categoria dominio = this.repositorio.Read(cat => cat.catid == id);
            CategoriaPoco poco = this.mapa.GetMapper.Map<CategoriaPoco>(dominio);
            return poco;
        }

        public IEnumerable<CategoriaPoco> ObterTodos()
        {
            List<categoria> lista = this.repositorio.Browsable().ToList();
            List<CategoriaPoco> listaPoco = this.mapa.GetMapper.Map<List<CategoriaPoco>>(lista);

            return listaPoco;
        }

        public CategoriaPoco Atualizar(CategoriaPoco poco)
        {
            categoria cat = this.mapa.GetMapper.Map<categoria>(poco);
            categoria alterada = this.repositorio.Edit(cat);
            CategoriaPoco novoPoco = this.mapa.GetMapper.Map<CategoriaPoco>(alterada);
            return novoPoco;
        }

        public CategoriaPoco Excluir(int id)
        {
            categoria cat = this.repositorio.Read(reg => reg.catid == id);
            CategoriaPoco poco = this.mapa.GetMapper.Map<CategoriaPoco>(cat);
            this.repositorio.Delete(cat);
            return poco;
        }

        public CategoriaPoco Incluir(CategoriaPoco poco)
        {
            categoria cat = this.mapa.GetMapper.Map<categoria>(poco);
            categoria nova = this.repositorio.Add(cat);
            CategoriaPoco novoPoco = this.mapa.GetMapper.Map<CategoriaPoco>(nova);
            return novoPoco;
        }
    }
}
