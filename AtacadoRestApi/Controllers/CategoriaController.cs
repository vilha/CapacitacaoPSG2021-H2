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
    [RoutePrefix("atacado/estoque/categoria")]
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
        /// Obter todos os registros.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<CategoriaPoco>))]
        public HttpResponseMessage Get()
        {
            try
            {
                List<CategoriaPoco> lista = this.servico.ObterTodos().ToList();
                return Request.CreateResponse<List<CategoriaPoco>>(HttpStatusCode.OK, lista);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Obter registro por chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:int}")]
        [ResponseType(typeof(CategoriaPoco))]
        public CategoriaPoco Get([FromUri] int id)
        {
            return this.servico.Obter(id);
        }

        /// <summary>
        /// Obter subcategorias por id da categoria.
        /// </summary>
        /// <param name="catid">Chave primaria da categoria.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{catid:int}/subcategorias")]
        [ResponseType(typeof(List<SubcategoriaPoco>))]
        public List<SubcategoriaPoco> GetSubcategoriaPorID([FromUri] int catid)
        {
            SubcategoriaService srv = new SubcategoriaService(this.contexto);
            List<SubcategoriaPoco> subcategoriaPoco = srv.ObterTodos()
                .Where(sub => sub.CategoriaID == catid).ToList();
            return subcategoriaPoco;
        }

        /// <summary>
        /// Incluir novo registro.
        /// </summary>
        /// <param name="poco">Objeto a ser incluso.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(CategoriaPoco))]
        public CategoriaPoco Post([FromBody] CategoriaPoco poco)
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
        [ResponseType(typeof(CategoriaPoco))]
        public CategoriaPoco Put([FromBody] CategoriaPoco poco)
        {
            return this.servico.Atualizar(poco);
        }

        /// <summary>
        /// Excluir um registro.
        /// </summary>
        /// <param name="id">Chave primaria</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        [ResponseType(typeof(CategoriaPoco))]
        public CategoriaPoco Delete([FromUri] int id)
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
