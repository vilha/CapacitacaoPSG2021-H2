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
    /// Serviços de Municipio utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("atacado/localizacao/municipio")]
    public class MunicipioController : GenericBaseController<MunicipioPoco>
    {
        private MunicipioService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public MunicipioController() : base()
        {
            this.servico = new MunicipioService(this.contexto);
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(MunicipioPoco))]
        public HttpResponseMessage Get([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MunicipioPoco poco = this.servico.Obter(id);
                return Request.CreateResponse<MunicipioPoco>(HttpStatusCode.OK, poco);
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
        [ResponseType(typeof(MunicipioPoco))]
        public HttpResponseMessage Post([FromBody] MunicipioPoco poco)
        {
            try
            {
                MunicipioPoco respPoco = this.servico.Incluir(poco);
                return Request.CreateResponse<MunicipioPoco>(HttpStatusCode.OK, respPoco);
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
        [ResponseType(typeof(MunicipioPoco))]
        public HttpResponseMessage Put([FromBody] MunicipioPoco poco)
        {
            try
            {
                MunicipioPoco respPoco = this.servico.Atualizar(poco);
                return Request.CreateResponse<MunicipioPoco>(HttpStatusCode.OK, respPoco);
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
        [ResponseType(typeof(MunicipioPoco))]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ID não pode ser zero.");
            }
            try
            {
                MunicipioPoco poco = this.servico.Excluir(id);
                return Request.CreateResponse<MunicipioPoco>(HttpStatusCode.OK, poco);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
