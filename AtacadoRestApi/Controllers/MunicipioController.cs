using Atacado.DAL.Model;
using Atacado.POCO.Model;
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
    /// Serviços para a tabela municipios
    /// </summary>
    [RoutePrefix("AtacadoRestApi")]
    public class MunicipioController : BaseController
    {
        /// <summary>
        /// Chamado do controlador base
        /// </summary>
        public MunicipioController() : base() { }

        /// <summary>
        /// Obter todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<MunicipioPoco>))]
        public List<MunicipioPoco> Get([FromUri] string siglaUF)
        {
            List<MunicipioPoco> municipiosPoco =
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
            return municipiosPoco;
        }

        /// <summary>
        /// Obter um registro, baseado na chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(MunicipioPoco))]
        public MunicipioPoco Get([FromUri] int id)
        {
            MunicipioPoco municipioPoco = this.contexto.Municipios
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
            return municipioPoco;
        }

        /// <summary>
        /// Criar registro na tabela
        /// </summary>
        /// <param name="poco">Objeto que sera incluido na tabela</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(MunicipioPoco))]
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

        /// <summary>
        /// Atualizar registro na tabela
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <param name="poco">Objeto que sera atualizado</param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(MunicipioPoco))]
        public MunicipioPoco Put([FromUri]  int id, [FromBody] MunicipioPoco poco)
        {
            Municipio municipio = this.contexto.Municipios.SingleOrDefault(reg => reg.MunicipioID == id);

            municipio.IBGE6 = poco.IBGE6;
            municipio.IBGE7 = poco.IBGE7;
            municipio.Descricao = poco.Descricao;
            municipio.MesoregiaoID = poco.MesoregiaoID;
            municipio.MicroregiaoID = poco.MicroregiaoID;
            municipio.UFID = poco.UFID;
            municipio.Populacao = poco.Populacao;
            municipio.CEP = poco.CEP;
            municipio.SiglaUF = poco.SiglaUF;

            this.contexto.Entry<Municipio>(municipio).State = System.Data.Entity.EntityState.Modified;
            this.contexto.SaveChanges();

            return this.Get(id);
        }

        /// <summary>
        /// Excluir registro da tabela
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <returns></returns>
        [HttpDelete]
        [ResponseType(typeof(MunicipioPoco))]
        public MunicipioPoco Delete([FromUri]  int id)
        {
            Municipio municipio = this.contexto.Municipios.SingleOrDefault(reg => reg.MunicipioID == id);
            this.contexto.Entry<Municipio>(municipio).State = System.Data.Entity.EntityState.Deleted;
            this.contexto.SaveChanges();
            return this.Get(id);
        }
    }
}
