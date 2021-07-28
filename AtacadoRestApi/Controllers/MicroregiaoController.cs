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
        public List<MicroregiaoPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(MicroregiaoPoco))]
        public MicroregiaoPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter municipios por id da microregiao.
        /// </summary>
        /// <param name="micid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{micid:int}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public List<MunicipioPoco> GetMunicipiosPorID([FromUri] int micid)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mic => mic.MesoregiaoID == micid).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(MicroregiaoPoco))]
        public MicroregiaoPoco Post([FromBody] MicroregiaoPoco poco)
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
        [ResponseType(typeof(MicroregiaoPoco))]
        public MicroregiaoPoco Put([FromBody] MicroregiaoPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// Excluir um registro.
        /// </summary>
        /// <param name="id">Chave primaria.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(MicroregiaoPoco))]
        public MicroregiaoPoco Delete([FromUri] int id)
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
