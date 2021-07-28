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
        public List<UFPoco> Get()
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
        [ResponseType(typeof(UFPoco))]
        public UFPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter municipios por sigla do estado.
        /// </summary>
        /// <param name="siglauf">Sigla do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{siglauf}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public List<MunicipioPoco> GetMunicipiosPorSigla([FromUri] string siglauf)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mun => mun.SiglaUF == siglauf).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// Obter municipios por id do estado.
        /// </summary>
        /// <param name="ufid">Chave primaria do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{ufid:int}/municipios")]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public List<MunicipioPoco> GetMunicipiosPorID([FromUri] int ufid)
        {
            MunicipioService srv = new MunicipioService(this.contexto);
            List<MunicipioPoco> municipioPoco = srv.ObterTodos()
                .Where(mun => mun.UFID == ufid).ToList();
            return municipioPoco;
        }

        /// <summary>
        /// Obter mesoregioes por id do estado.
        /// </summary>
        /// <param name="ufid">Chave primaria do estado.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{ufid:int}/mesoregioes")]
        [ResponseType(typeof(UFPoco))]
        public List<MesoregiaoPoco> GetMesoregioesPorSigla([FromUri] int ufid)
        {
            MesoregiaoService srv = new MesoregiaoService(this.contexto);
            List<MesoregiaoPoco> mesoregiaoPoco = srv.ObterTodos()
                .Where(mes => mes.UFID == ufid).ToList();
            return mesoregiaoPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(UFPoco))]
        public UFPoco Post([FromBody] UFPoco poco)
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
        [ResponseType(typeof(UFPoco))]
        public UFPoco Put([FromBody] UFPoco poco)
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
        [ResponseType(typeof(UFPoco))]
        public UFPoco Delete([FromUri] int id)
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
