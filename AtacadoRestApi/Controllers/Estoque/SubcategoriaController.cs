using Atacado.POCO.Model;
using Atacado.Service.Estoque;
using AtacadoRestApi.Ancestor;
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
    public class SubcategoriaController : GenericBaseController<SubcategoriaPoco>
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
        public HttpResponseMessage Get()
        {
            try
            {
                List<SubcategoriaPoco> poco = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<SubcategoriaPoco>>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(SubcategoriaPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                SubcategoriaPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<SubcategoriaPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter produtos por id da subcategoria.
        /// </summary>
        /// <param name="subcatid">Chave primaria da subcategoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{subcatid:int}/produtos")]
        [ResponseType(typeof(List<ProdutoPoco>))]
        public HttpResponseMessage GetProdutosPorID([FromUri] int subcatid)
        {
            if (subcatid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                ProdutoService srv = new ProdutoService(this.contexto);
                List<ProdutoPoco> lista = srv.ObterTodos()
                .Where(prod => prod.SubcategoriaID == subcatid).ToList();
                return Request.CreateResponse<List<ProdutoPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluso.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(SubcategoriaPoco))]
        public HttpResponseMessage Post([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco respPoco = this.servico.Incluir(poco);
                return Request.CreateResponse<SubcategoriaPoco>(HttpStatusCode.OK, respPoco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Atualizar um registro.
        /// </summary>
        /// <param name="poco">Objeto a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ResponseType(typeof(SubcategoriaPoco))]
        public HttpResponseMessage Put([FromBody] SubcategoriaPoco poco)
        {
            try
            {
                SubcategoriaPoco respPoco = this.servico.Atualizar(poco);
                return Request.CreateResponse<SubcategoriaPoco>(HttpStatusCode.OK, respPoco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Excluir um registro.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(SubcategoriaPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                SubcategoriaPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<SubcategoriaPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
