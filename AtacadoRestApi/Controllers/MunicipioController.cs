using Atacado.DAL.Model;
using Atacado.POCO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AtacadoRestApi.Controllers
{
    public class MunicipioController : BaseController
    {
        public MunicipioController() : base()
        { }
        // GET: api/Municipio
        public List<MunicipioPoco> Get([FromUri] string siglaUF)
        {
            List<MunicipioPoco> municipios =
                this.contexto.Municipios
                .Where(mun => mun.SiglaUF == siglaUF)
                .Select(mun => new MunicipioPoco()
                {
                    MunicipioID = mun.MunicipioID,
                    IBGE6 = mun.IBGE6,
                    IBGE7 = mun.IBGE7,
                    Descricao = mun.Descricao,
                    MesoregiaoID = mun.MesoregiaoID,
                    MicroregiaoID = mun.MicroregiaoID,
                    UFID = mun.UFID,
                    Populacao = mun.Populacao,
                    CEP = mun.CEP,
                    SiglaUF = mun.SiglaUF
                }).ToList();
            return municipios;
        }

        // GET: api/Municipio/5
        public MunicipioPoco Get([FromUri] int id)
        {
            MunicipioPoco municipio = this.contexto.Municipios
                .Where(mun => mun.MunicipioID == id).Select(mun => new MunicipioPoco()
                {
                    MunicipioID = mun.MunicipioID,
                    IBGE6 = mun.IBGE6,
                    IBGE7 = mun.IBGE7,
                    Descricao = mun.Descricao,
                    MesoregiaoID = mun.MesoregiaoID,
                    MicroregiaoID = mun.MicroregiaoID,
                    UFID = mun.UFID,
                    Populacao = mun.Populacao,
                    CEP = mun.CEP,
                    SiglaUF = mun.SiglaUF
                }).SingleOrDefault();
            return municipio;
        }

        // POST: api/Municipio
        public MunicipioPoco Post([FromBody] MunicipioPoco poco)
        {
            Municipio municipio = new Municipio();
            municipio.IBGE6 = poco.IBGE6;
            municipio.IBGE7 = poco.IBGE7;
            municipio.Descricao = poco.Descricao;
            municipio.MesoregiaoID = poco.MesoregiaoID;
            municipio.MicroregiaoID = poco.MicroregiaoID;
            municipio.UFID = poco.UFID;
            municipio.Populacao = poco.Populacao;
            municipio.CEP = poco.CEP;
            municipio.SiglaUF = poco.SiglaUF;

            this.contexto.Municipios.Add(municipio);
            this.contexto.SaveChanges();

            int id = municipio.MunicipioID;

            return this.Get(id);
        }

        // PUT: api/Municipio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Municipio/5
        public void Delete(int id)
        {
        }
    }
}
