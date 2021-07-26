using Atacado.POCO.Model;
using Atacado.Service.Estoque;
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
    [RoutePrefix("categoria")]
    public class CategoriaController : BaseController
    {
        private CategoriaService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public CategoriaController() : base()
        {
            this.servico = new CategoriaService(this.contexto);
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [ResponseType(typeof(CategoriaPoco))]
        [HttpGet]
        public CategoriaPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(List<CategoriaPoco>))]
        [HttpGet]
        public List<CategoriaPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
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
