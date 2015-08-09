using _324THLHI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace _324THLHI.Controllers
{
    public class PDFCreatorController : ApiController
    {
        [HttpGet]
        [ActionName("GetPDF")]
        public HttpResponseMessage GetPDF([FromUri]LIKData uploadedLIKData)
        {
            MassageLIKData(uploadedLIKData);

            var path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            path = path + ".\\324LIKRequest.pdf";
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/pdf");
            return result;
        }

        private void MassageLIKData(LIKData toMassage)
        {
            toMassage.Initials = toMassage.Initials ?? "";
            for (int i = 0; i < toMassage.LodgingDates.Count; i++)
            {
                toMassage.LodgingDates[i] = toMassage.LodgingDates[i] ?? "";
            }
            toMassage.Mileage = toMassage.Mileage ?? "";
            toMassage.Name = toMassage.Name ?? "";
            toMassage.Phone = toMassage.Phone ?? "";
            toMassage.PhoneAreaCode = toMassage.PhoneAreaCode ?? "";
            toMassage.Rank = toMassage.Rank ?? "";
            toMassage.Unit = toMassage.Unit ?? "";
            toMassage.WorkPhone = toMassage.WorkPhone ?? "";
            toMassage.WorkPhoneAreaCode = toMassage.WorkPhoneAreaCode ?? "";
        }
    }
}
