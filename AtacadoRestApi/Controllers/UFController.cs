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
    public class UFController : ApiController
    {
        // GET: api/UF
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

        // GET: api/UF/5
        public UFPoco Get(int id)
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

        // POST: api/UF
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

        // PUT: api/UF/5
        public UFPoco Put(int id, [FromBody] UFPoco poco)
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

        // DELETE: api/UF/5
        public UFPoco Delete(int id)
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
