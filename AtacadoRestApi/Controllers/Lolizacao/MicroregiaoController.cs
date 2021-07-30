using Atacado.POCO.Model;
using Atacado.Service.Localizacao;
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
    /// Serviços de Microregiao utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("atacado/localizacao/microregiao")]
    public class MicroregiaoController : BaseController
    {
        private MicroregiaoService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public MicroregiaoController() : base()
        {
            this.servico = new MicroregiaoService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<MicroregiaoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<MicroregiaoPoco> poco = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<MicroregiaoPoco>>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MicroregiaoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<MicroregiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter municipios por id da microregiao.
        /// </summary>
        /// <param name="micid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{micid:int}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public HttpResponseMessage GetMunicipiosPorID([FromUri] int micid)
        {
            if (micid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MunicipioService srv = new MunicipioService(this.contexto);
                List<MunicipioPoco> lista = srv.ObterTodos()
                    .Where(mun => mun.MicroregiaoID == micid).ToList();
                return Request.CreateResponse<List<MunicipioPoco>>(HttpStatusCode.OK, lista);
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public HttpResponseMessage Post([FromBody] MicroregiaoPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<MicroregiaoPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public HttpResponseMessage Put([FromBody] MicroregiaoPoco poco)
        {
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<MicroregiaoPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MicroregiaoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<MicroregiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
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
