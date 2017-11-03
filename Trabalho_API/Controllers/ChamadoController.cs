using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Trabalho_API.Models;

namespace Trabalho_API.Controllers
{
    public class ChamadoController : ApiController
    {
        // GET api/values
        public IEnumerable<ChamadoModel> GetAll()
        {
            return null;
        }

        // GET api/values/5
        public ChamadoModel Get(Guid idChamado)
        {
            return new ChamadoModel();
        }

        // POST api/values
        public void Post([FromBody]ChamadoModel chamado)
        {
        }

        // PUT api/values/5
        public void Put(Guid idChamado, [FromBody]ChamadoModel chamado)
        {
        }

        // DELETE api/values/5
        public void Delete(Guid idChamado)
        {
        }
    }
}
