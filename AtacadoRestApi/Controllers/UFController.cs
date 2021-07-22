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
    /// Serviços para a tabela UnidadesFederacao
    /// </summary>
    [RoutePrefix("AtacadoRestApi")]
    public class UFController : ApiController
    {
        /// <summary>
        /// Obter todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<UFPoco>))]
        public List<UFPoco> Get()
        {
            AtacadoModel contexto = new AtacadoModel();

            List<UFPoco> ufPoco = contexto.UFs.Select(
                novo => new UFPoco()
                {
                    UFID = novo.UFID,
                    SiglaUF = novo.SiglaUF,
                    Descricao = novo.Descricao,
                    RegiaoID = novo.RegiaoID,
                    DataInclusao = novo.datainsert
                }).ToList();

            return ufPoco;
        }

        /// <summary>
        /// Obter um registro, baseado na chave primaria.
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(UFPoco))]
        public UFPoco Get([FromUri] int id)
        {
            AtacadoModel contexto = new AtacadoModel();

            UFPoco ufPoco = contexto.UFs
                .Where(reg => reg.UFID == id)
                .Select(novo => new UFPoco()
                {
                    UFID = novo.UFID,
                    SiglaUF = novo.SiglaUF,
                    Descricao = novo.Descricao,
                    RegiaoID = novo.RegiaoID,
                    DataInclusao = novo.datainsert
                }).FirstOrDefault();

            return ufPoco;
        }

        /// <summary>
        /// Criar registro na tabela
        /// </summary>
        /// <param name="poco">Objeto que sera incluido na tabela</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(UFPoco))]
        public UFPoco Post([FromBody] UFPoco poco)
        {
            UnidadesFederacao uf = new UnidadesFederacao();
            uf.Descricao = poco.Descricao;
            uf.SiglaUF = poco.SiglaUF;
            uf.RegiaoID = poco.RegiaoID;
            uf.datainsert = DateTime.Now;

            AtacadoModel contexto = new AtacadoModel();
            contexto.UFs.Add(uf);
            contexto.SaveChanges();

            UFPoco novoPoco = new UFPoco();
            novoPoco.UFID = uf.UFID;
            novoPoco.Descricao = uf.Descricao;
            novoPoco.SiglaUF = uf.SiglaUF;
            novoPoco.RegiaoID = uf.RegiaoID;
            novoPoco.DataInclusao = uf.datainsert;

            return novoPoco;
        }

        /// <summary>
        /// Atualizar registro na tabela
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <param name="poco">Objeto que sera atualizado</param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(UFPoco))]
        public UFPoco Put([FromUri] int id, [FromBody] UFPoco poco)
        {
            AtacadoModel contexto = new AtacadoModel();
            UnidadesFederacao uf = contexto.UFs.SingleOrDefault(reg => reg.UFID == id);

            uf.Descricao = poco.Descricao;
            uf.SiglaUF = poco.SiglaUF;
            uf.RegiaoID = poco.RegiaoID;
            contexto.Entry<UnidadesFederacao>(uf).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

            UFPoco novoPoco = new UFPoco();
            novoPoco.UFID = uf.UFID;
            novoPoco.Descricao = uf.Descricao;
            novoPoco.SiglaUF = uf.SiglaUF;
            novoPoco.RegiaoID = uf.RegiaoID;
            novoPoco.DataInclusao = uf.datainsert;

            return novoPoco;

        }

        /// <summary>
        /// Excluir registro da tabela
        /// </summary>
        /// <param name="id">Chave primaria do registro</param>
        /// <returns></returns>
        [HttpDelete]
        [ResponseType(typeof(UFPoco))]
        public UFPoco Delete([FromUri] int id)
        {
            AtacadoModel contexto = new AtacadoModel();
            UnidadesFederacao uf = contexto.UFs.SingleOrDefault(reg => reg.UFID == id);
            contexto.Entry<UnidadesFederacao>(uf).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();

            UFPoco novoPoco = new UFPoco();
            novoPoco.UFID = uf.UFID;
            novoPoco.Descricao = uf.Descricao;
            novoPoco.SiglaUF = uf.SiglaUF;
            novoPoco.RegiaoID = uf.RegiaoID;
            novoPoco.DataInclusao = uf.datainsert;

            return novoPoco;
        }
    }
}
