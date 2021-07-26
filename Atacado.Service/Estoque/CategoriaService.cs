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
            List<CategoriaPoco> listaPoco = this.repositorio.Browse()
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
            throw new NotImplementedException();
        }

        public CategoriaPoco Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public CategoriaPoco Incluir(CategoriaPoco poco)
        {
            throw new NotImplementedException();
        }

        

        
    }
}
