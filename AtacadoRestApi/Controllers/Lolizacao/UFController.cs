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
    /// Serviços de UnidadesFederacao utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("atacado/localizacao/estados")]
    public class UFController : BaseController
    {
        private UFService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public UFController() : base()
        {
            this.servico = new UFService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<UFPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<UFPoco> poco = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<UFPoco>>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(UFPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                UFPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<UFPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter municipios por sigla do estado.
        /// </summary>
        /// <param name="siglauf">Sigla do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{siglauf}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public HttpResponseMessage GetMunicipiosPorSigla([FromUri] string siglauf)
        {
            if (string.IsNullOrEmpty(siglauf))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SiglaUF deve ser informada.");
            }
            if (siglauf.Length != 2)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "SiglaUF deve conter duas letras.");
            }
            try
            {
                string sigla = siglauf.ToUpper();
                MunicipioService srv = new MunicipioService(this.contexto);
                List<MunicipioPoco> lista = srv.ObterTodos()
                    .Where(mun => mun.SiglaUF == sigla).ToList();
                return Request.CreateResponse<List<MunicipioPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter municipios por id do estado.
        /// </summary>
        /// <param name="ufid">Chave primaria do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{ufid:int}/municipio")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public HttpResponseMessage GetMunicipiosPorID([FromUri] int ufid)
        {
            if (ufid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MunicipioService srv = new MunicipioService(this.contexto);
                List<MunicipioPoco> lista = srv.ObterTodos()
                    .Where(mun => mun.UFID == ufid).ToList();
                return Request.CreateResponse<List<MunicipioPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter mesoregioes por id do estado.
        /// </summary>
        /// <param name="ufid">Chave primaria do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{ufid:int}/mesoregioes")]
        [ResponseType(typeof(UFPoco))]
        public HttpResponseMessage GetMesoregioesPorID([FromUri] int ufid)
        {
            if (ufid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MesoregiaoService srv = new MesoregiaoService(this.contexto);
                List<MesoregiaoPoco> lista = srv.ObterTodos()
                    .Where(mes => mes.UFID == ufid).ToList();
                return Request.CreateResponse<List<MesoregiaoPoco>> (HttpStatusCode.OK, lista);
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
        [ResponseType(typeof(UFPoco))]
        public HttpResponseMessage Post([FromBody] UFPoco poco)
        {
            try
            {
                this.servico.Incluir(poco);
                return Request.CreateResponse<UFPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(UFPoco))]
        public HttpResponseMessage Put([FromBody] UFPoco poco)
        {
            try
            {
                this.servico.Atualizar(poco);
                return Request.CreateResponse<UFPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(UFPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                UFPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<UFPoco>(HttpStatusCode.OK, poco);
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
