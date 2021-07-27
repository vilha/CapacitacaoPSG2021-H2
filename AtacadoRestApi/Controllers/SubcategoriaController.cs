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
    [RoutePrefix("subcategoria")]
    public class SubcategoriaController : BaseController
    {
        private SubcategoriaService servico;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public SubcategoriaController() : base()
        {
            this.servico = new SubcategoriaService(this.contexto);
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [ResponseType(typeof(SubcategoriaPoco))]
        [HttpGet]
        public SubcategoriaPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(List<SubcategoriaPoco>))]
        [HttpGet]
        public List<SubcategoriaPoco> Get()
        {
            return this.servico.ObterTodos().ToList();
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluso.</param>
        /// <returns></returns>
        public SubcategoriaPoco Post([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Incluir(poco);
        }

        /// <summary>
        /// Atualizar um registro.
        /// </summary>
        /// <param name="poco">Objeto a ser atualizado.</param>
        /// <returns></returns>
        public SubcategoriaPoco Put([FromBody] SubcategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// Excluir um registro.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        public SubcategoriaPoco Delete([FromUri] int id)
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
