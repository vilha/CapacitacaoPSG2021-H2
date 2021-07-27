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
    public class SubcategoriaService : IService<SubcategoriaPoco>
    {
        private SubcategoriaRepository repositorio;

        private SubcategoriaMap mapa;
        public SubcategoriaService(DbContext contexto)
        {
            this.repositorio = new SubcategoriaRepository(contexto);
            this.mapa = new SubcategoriaMap();
        }

        public SubcategoriaPoco Obter(int id)
        {
            subcategoria dominio = this.repositorio.Read(subcat => subcat.subcatid == id);
            SubcategoriaPoco poco = this.mapa.GetMapper.Map<SubcategoriaPoco>(dominio);
            return poco;
        }

        public IEnumerable<SubcategoriaPoco> ObterTodos()
        {
            List<subcategoria> lista = this.repositorio.Browsable().ToList();
            List<SubcategoriaPoco> listaPoco = this.mapa.GetMapper.Map<List<SubcategoriaPoco>>(lista);
            return listaPoco;
        }

        public SubcategoriaPoco Atualizar(SubcategoriaPoco poco)
        {
            subcategoria subcat = this.mapa.GetMapper.Map<subcategoria>(poco);
            subcategoria alterada = this.repositorio.Edit(subcat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(alterada);
            return novoPoco;
        }

        public SubcategoriaPoco Excluir(int id)
        {
            subcategoria subcat = this.repositorio.Read(reg => reg.subcatid == id);
            SubcategoriaPoco poco = this.mapa.GetMapper.Map<SubcategoriaPoco>(subcat);
            this.repositorio.Delete(subcat);
            return poco;
        }

        public SubcategoriaPoco Incluir(SubcategoriaPoco poco)
        {
            subcategoria subcat = this.mapa.GetMapper.Map<subcategoria>(poco);
            subcategoria nova = this.repositorio.Add(subcat);
            SubcategoriaPoco novoPoco = this.mapa.GetMapper.Map<SubcategoriaPoco>(nova);
            return novoPoco;
        }

    }
}