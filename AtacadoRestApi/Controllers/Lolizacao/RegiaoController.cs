using Atacado.POCO.Model;
using Atacado.Service.Localizacao;
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
    /// Serviços de Regiao utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("atacado/localizacao/regioes")]
    public class RegiaoController : GenericBaseController<RegiaoPoco>
    {
        private RegiaoService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public RegiaoController() : base()
        {
            this.servico = new RegiaoService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<RegiaoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<RegiaoPoco> poco = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<RegiaoPoco>>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(RegiaoPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                RegiaoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<RegiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter estados por chave primaria da regiao.
        /// </summary>
        /// <param name="regiaoid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{regiaoid:int}/estados")]
        [ResponseType(typeof(List<UFPoco>))]
        public HttpResponseMessage GetEstadosPorID([FromUri] int regiaoid)
        {
            if (regiaoid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                UFService srv = new UFService(this.contexto);
                List<UFPoco> lista = srv.ObterTodos()
                    .Where(uf => uf.RegiaoID == regiaoid).ToList();
                return Request.CreateResponse<List<UFPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(RegiaoPoco))]
        public HttpResponseMessage Post([FromBody] RegiaoPoco poco)
        {
            try
            {
                RegiaoPoco respPoco = this.servico.Incluir(poco);
                return Request.CreateResponse<RegiaoPoco>(HttpStatusCode.OK, respPoco);
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
        [ResponseType(typeof(RegiaoPoco))]
        public HttpResponseMessage Put([FromBody] RegiaoPoco poco)
        {
            try
            {
                RegiaoPoco respPoco = this.servico.Atualizar(poco);
                return Request.CreateResponse<RegiaoPoco>(HttpStatusCode.OK, respPoco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Excluir um registro.
        /// </summary>
        /// <param name="id">Chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(RegiaoPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                RegiaoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<RegiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
