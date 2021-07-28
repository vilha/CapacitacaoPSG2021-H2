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
    /// Serviços de Mesoregiao utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("atacado/localizacao/mesoregiao")]
    public class MesoregiaoController : BaseController
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
        public List<MesoregiaoPoco> Get()
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public MesoregiaoPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter microregioes por id da mesoregiao.
        /// </summary>
        /// <param name="mesid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mesid:int}/microregioes")]
        [ResponseType(typeof(List<MicroregiaoPoco>))]
        public List<MicroregiaoPoco> GetMicroregioesPorID([FromUri] int mesid)
        {
            MicroregiaoService srv = new MicroregiaoService(this.contexto);
            List<MicroregiaoPoco> mesoregiaoPoco = srv.ObterTodos()
                .Where(mes => mes.MesoregiaoID == mesid).ToList();
            return mesoregiaoPoco;
        }

        /// <summary>
        /// Obter municipios por id da mesoregiao.
        /// </summary>
        /// <param name="mesid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{mesid:int}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public List<MunicipioPoco> GetMunicipiosPorID([FromUri] int mesid)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mes => mes.MesoregiaoID == mesid).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(MesoregiaoPoco))]
        public MesoregiaoPoco Post([FromBody] MesoregiaoPoco poco)
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public MesoregiaoPoco Put([FromBody] MesoregiaoPoco poco)
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
        [ResponseType(typeof(MesoregiaoPoco))]
        public MesoregiaoPoco Delete([FromUri] int id)
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
