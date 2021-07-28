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

namespace Atacado.Service.Estoque
{
    public class RegiaoServico : IService<RegiaoPoco>
    {
        public RegiaoRepository repositorio;

    }
}
/*
    public class CategoriaService : IService<CategoriaPoco>
    {
        public CategoriaRepository repositorio;

        public CategoriaService(DbContext contexto)
        {
            this.repositorio = new CategoriaRepository(contexto);
        }

        public CategoriaPoco Obter(int id)
        {
            categoria dominio = this.repositorio.Read(cat => cat.catid == id);
            CategoriaPoco poco = new CategoriaPoco()
            {
                Categoriaid = dominio.catid,
                Descricao = dominio.descricao,
                DataInclusao = dominio.datainsert
            };
            return poco;
        }

        public IEnumerable<CategoriaPoco> ObterTodos()
        {
            List<CategoriaPoco> listaPoco = this.repositorio.Browsable()
                .Select(cat => new CategoriaPoco()
                {
                    Categoriaid = cat.catid,
                    Descricao = cat.descricao,
                    DataInclusao = cat.datainsert
                }
                ).ToList();
            return listaPoco;
        }

        public CategoriaPoco Atualizar(CategoriaPoco poco)
        {
            categoria atuaCat = this.repositorio.Read(reg => reg.catid == poco.Categoriaid);
            atuaCat.descricao = poco.Descricao;
            atuaCat.datainsert = poco.DataInclusao;
            this.repositorio.Edit(atuaCat);

            return this.Obter(atuaCat.catid);
        }

        public CategoriaPoco Excluir(int id)
        {
            categoria excCat = this.repositorio.Read(reg => reg.catid == id);
            this.repositorio.Delete(excCat);
            return this.Obter(id);
        }

        public CategoriaPoco Incluir(CategoriaPoco poco)
        {
            categoria novoCat = new categoria();
            novoCat.descricao = poco.Descricao;
            novoCat.datainsert = poco.DataInclusao;

            this.repositorio.Add(novoCat);

            return this.Obter(novoCat.catid);
        }
    }
}
