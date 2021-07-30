using Atacado.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AtacadoRestApi.Controllers
{
    
    public abstract class BaseController : ApiController
    {
        protected AtacadoModel contexto;
        public BaseController()
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
