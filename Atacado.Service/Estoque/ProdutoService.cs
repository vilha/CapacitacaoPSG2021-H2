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
    public class ProdutoService : IService<ProdutoPoco>
    {
        private ProdutoRepository repositorio;

        private ProdutoMap mapa;
        public ProdutoService(DbContext contexto)
        {
            this.repositorio = new ProdutoRepository(contexto);
            this.mapa = new ProdutoMap();
        }

        public ProdutoPoco Obter(int id)
        {
            produto dominio = this.repositorio.Read(prod => prod.produtoid == id);
            ProdutoPoco poco = this.mapa.GetMapper.Map<ProdutoPoco>(dominio);
            return poco;
        }

        public IEnumerable<ProdutoPoco> ObterTodos()
        {
            List<produto> lista = this.repositorio.Browsable().ToList();
            List<ProdutoPoco> listaPoco = this.mapa.GetMapper.Map<List<ProdutoPoco>>(lista);
            return listaPoco;
        }

        public ProdutoPoco Atualizar(ProdutoPoco poco)
        {
            produto prod = this.mapa.GetMapper.Map<produto>(poco);
            produto alterada = this.repositorio.Edit(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(alterada);
            return novoPoco;
        }

        public ProdutoPoco Excluir(int id)
        {
            produto prod = this.repositorio.Read(reg => reg.produtoid == id);
            ProdutoPoco poco = this.mapa.GetMapper.Map<ProdutoPoco>(prod);
            this.repositorio.Delete(prod);
            return poco;
        }

        public ProdutoPoco Incluir(ProdutoPoco poco)
        {
            produto prod = this.mapa.GetMapper.Map<produto>(poco);
            produto nova = this.repositorio.Add(prod);
            ProdutoPoco novoPoco = this.mapa.GetMapper.Map<ProdutoPoco>(nova);
            return novoPoco;
        }

    }
}