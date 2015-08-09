using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace _324THLHI.Controllers
{
    public class PDFCreatorController : ApiController
    {
        [HttpGet]
        [ActionName("GetPDF")]
        public IHttpActionResult GetPDF()
        {
            return Ok();
        }
    }
}
