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
    [RoutePrefix("atacado/estoque/categoria")]
    public class CategoriaController : GenericBaseController<CategoriaPoco>
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public CategoriaController() : base()
        {
            this.servico = new CategoriaService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<CategoriaPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<CategoriaPoco> lista = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<CategoriaPoco>>(HttpStatusCode.OK, lista);
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
        [ResponseType(typeof(CategoriaPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                CategoriaPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<CategoriaPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter subcategorias por id da categoria.
        /// </summary>
        /// <param name="catid">Chave primaria da categoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{catid:int}/subcategorias")]
        [ResponseType(typeof(List<SubcategoriaPoco>))]
        public HttpResponseMessage GetSubcategoriaPorID([FromUri] int catid)
        {
            if (catid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                SubcategoriaService srv = new SubcategoriaService(this.contexto);
                List<SubcategoriaPoco> lista = srv.ObterTodos()
                    .Where(sub => sub.CategoriaID == catid).ToList();
                return Request.CreateResponse<List<SubcategoriaPoco>>(HttpStatusCode.OK, lista);
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
        [ResponseType(typeof(CategoriaPoco))]
        public HttpResponseMessage Post([FromBody] CategoriaPoco poco)
        {
            try
            {
                CategoriaPoco respPoco = this.servico.Incluir(poco);
                return Request.CreateResponse<CategoriaPoco>(HttpStatusCode.OK, respPoco);
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
        [ResponseType(typeof(CategoriaPoco))]
        public HttpResponseMessage Put([FromBody] CategoriaPoco poco)
        {
            try
            {
                CategoriaPoco respPoco = this.servico.Atualizar(poco);
                return Request.CreateResponse<CategoriaPoco>(HttpStatusCode.OK, respPoco);
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
        [ResponseType(typeof(CategoriaPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                CategoriaPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<CategoriaPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
