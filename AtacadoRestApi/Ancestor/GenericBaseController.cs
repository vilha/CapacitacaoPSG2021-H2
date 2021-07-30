using Atacado.DAL.Model;
using Atacado.Service.Ancestor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AtacadoRestApi.Ancestor
{
    public class GenericBaseController<T> : ApiController
        where T : class
    {
        protected DbContext contexto;

        protected IService<T> servico;

        public GenericBaseController()
        {
            this.contexto = new AtacadoModel();
        }

        protected override void Dispose(bool disposing)
        {
            this.contexto.Dispose();
            base.Dispose(disposing);
        }
    }
}