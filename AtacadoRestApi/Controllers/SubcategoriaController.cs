using Atacado.POCO.Model;
using Atacado.Service.Estoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AtacadoRestApi.Controllers
{
    /// <summary>
    /// Serviços de categoria utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("atacado/estoque/subcategoria")]
    public class SubcategoriaController : BaseController
    {
        private SubcategoriaService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public SubcategoriaController() : base()
        {
            this.servico = new SubcategoriaService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<SubcategoriaPoco>))]
        public List<SubcategoriaPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(SubcategoriaPoco))]
        public SubcategoriaPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter produtos por id da subcategoria.
        /// </summary>
        /// <param name="subcatid">Chave primaria da subcategoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{subcatid:int}/produtos")]
        [ResponseType(typeof(List<ProdutoPoco>))]
        public List<ProdutoPoco> GetProdutosPorID([FromUri] int subcatid)
        {
            ProdutoService srv = new ProdutoService(this.contexto);
            List<ProdutoPoco> produtoPoco = srv.ObterTodos()
                .Where(prod => prod.SubcategoriaID == subcatid).ToList();
            return produtoPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluso.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(SubcategoriaPoco))]
        public SubcategoriaPoco Post([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Incluir(poco);
        }

        /// <summary>
        /// Atualizar um registro.
        /// </summary>
        /// <param name="poco">Objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ResponseType(typeof(SubcategoriaPoco))]
        public SubcategoriaPoco Put([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// Excluir um registro.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(SubcategoriaPoco))]
        public SubcategoriaPoco Delete([FromUri] int id)
        {
            return this.servico.Excluir(id);
        }

        /// <summary>
        /// Dispose do serviço.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            this.servico = null;
            base.Dispose(disposing);
        }
    }
}
