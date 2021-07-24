﻿using Atacado.DAL.Model;
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
    public class UFController : BaseController
    {
        /// <summary>
        /// Chamado do controlador base
        /// </summary>
        public UFController() : base() { }

        /// <summary>
        /// Obter todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<UFPoco>))]
        public List<UFPoco> Get()
        {
            List<UFPoco> ufPoco = this.contexto.UFs.Select(
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
            UFPoco ufPoco = this.contexto.UFs
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

            this.contexto.UFs.Add(uf);
            this.contexto.SaveChanges();

            int id = uf.UFID;
            return this.Get(id);
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
            UnidadesFederacao uf = this.contexto.UFs.SingleOrDefault(reg => reg.UFID == id);

            uf.Descricao = poco.Descricao;
            uf.SiglaUF = poco.SiglaUF;
            uf.RegiaoID = poco.RegiaoID;
            this.contexto.Entry<UnidadesFederacao>(uf).State = System.Data.Entity.EntityState.Modified;
            this.contexto.SaveChanges();

            return this.Get(id);

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
            UnidadesFederacao uf = this.contexto.UFs.SingleOrDefault(reg => reg.UFID == id);
            this.contexto.Entry<UnidadesFederacao>(uf).State = System.Data.Entity.EntityState.Deleted;
            this.contexto.SaveChanges();
            return this.Get(id);
        }
    }
}
