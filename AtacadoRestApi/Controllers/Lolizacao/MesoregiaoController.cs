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
    /// Serviços de Mesoregiao utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("atacado/localizacao/mesoregiao")]
    public class MesoregiaoController : GenericBaseController<MesoregiaoPoco>
    {
        private MesoregiaoService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public MesoregiaoController() : base()
        {
            this.servico = new MesoregiaoService(this.contexto);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<MesoregiaoPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<MesoregiaoPoco> poco = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<MesoregiaoPoco>>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MesoregiaoPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<MesoregiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter microregioes por id da mesoregiao.
        /// </summary>
        /// <param name="mesid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mesid:int}/microregioes")]
        [ResponseType(typeof(List<MicroregiaoPoco>))]
        public HttpResponseMessage GetMicroregioesPorID([FromUri] int mesid)
        {
            if (mesid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try 
            {
                MicroregiaoService srv = new MicroregiaoService(this.contexto);
                List<MicroregiaoPoco> lista = srv.ObterTodos()
                    .Where(mic => mic.MesoregiaoID == mesid).ToList();
                return Request.CreateResponse<List<MicroregiaoPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter municipios por id da mesoregiao.
        /// </summary>
        /// <param name="mesid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mesid:int}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public HttpResponseMessage GetMunicipiosPorID([FromUri] int mesid)
        {
            if (mesid == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MunicipioService srv = new MunicipioService(this.contexto);
                List<MunicipioPoco> lista = srv.ObterTodos()
                    .Where(mun => mun.MesoregiaoID == mesid).ToList();
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public HttpResponseMessage Post([FromBody] MesoregiaoPoco poco)
        {
            try
            {
                MesoregiaoPoco respPoco = this.servico.Incluir(poco);
                return Request.CreateResponse<MesoregiaoPoco>(HttpStatusCode.OK, respPoco);
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public HttpResponseMessage Put([FromBody] MesoregiaoPoco poco)
        {
            try
            {
                MesoregiaoPoco respPoco = this.servico.Atualizar(poco);
                return Request.CreateResponse<MesoregiaoPoco>(HttpStatusCode.OK, respPoco);
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MesoregiaoPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<MesoregiaoPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
