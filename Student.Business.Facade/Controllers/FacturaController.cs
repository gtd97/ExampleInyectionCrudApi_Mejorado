using Student.Business.Logi.BusinessLogic;
using Student.Business.Logic.Contracts;
using Student.Common.Logic.Log4Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Student.Business.Facade.Controllers
{
    public class FacturaController : ApiController
    {
        private readonly ILogger Log;
        private readonly IBusinessGeneric<Factura> facturaBl;

        public FacturaController(ILogger Log, IBusinessGeneric<Factura> facturaBl)
        {
            this.Log = Log;
            this.facturaBl = facturaBl;
        }

        [HttpGet()]
        [Route("api/Factura/GetAll")]
        public int GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
