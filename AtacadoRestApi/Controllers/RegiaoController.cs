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
    /// Serviços de Regiao utilizando disegn patterns.
    /// </summary>
    [RoutePrefix("atacado/localizacao/regioes")]
    public class RegiaoController : BaseController
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
        public List<RegiaoPoco> Get()
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
        [ResponseType(typeof(RegiaoPoco))]
        public RegiaoPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter estados por chave primaria da regiao.
        /// </summary>
        /// <param name="regiaoid">Chave primaria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{regiaoid:int}/estados")]
        [ResponseType(typeof(List<UFPoco>))]
        public List<UFPoco> GetEstadosPorID([FromUri] int regiaoid)
        {
            UFService srv = new UFService(this.contexto);
            List<UFPoco> ufPoco = srv.ObterTodos()
                .Where(uf => uf.RegiaoID == regiaoid).ToList();
            return ufPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluido.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(List<RegiaoPoco>))]
        public RegiaoPoco Post([FromBody] RegiaoPoco poco)
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
        [ResponseType(typeof(List<RegiaoPoco>))]
        public RegiaoPoco Put([FromBody] RegiaoPoco poco)
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
        [ResponseType(typeof(List<RegiaoPoco>))]
        public RegiaoPoco Delete([FromUri] int id)
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
