using _324THLHI.Models;
using _324THLHI.Utilities;
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
        [Route("CreatePDF")]
        public HttpResponseMessage GetPDF([FromUri]LIKData uploadedLIKData)
        {
            MassageLIKData(uploadedLIKData);

            
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            MemoryStream stream = new MemoryStream();
            Generate324thLIK PDFCreator = new Generate324thLIK();

            PDFCreator.Address = uploadedLIKData.Address;
            PDFCreator.CityStateZip = uploadedLIKData.CSZ;
            PDFCreator.Email = uploadedLIKData.Email;
            PDFCreator.Initials = uploadedLIKData.Initials;
            PDFCreator.LodgingDates = uploadedLIKData.LodgingDates;
            PDFCreator.Mileage = uploadedLIKData.Mileage;
            PDFCreator.Name = uploadedLIKData.Name;
            PDFCreator.Phone = uploadedLIKData.Phone;
            PDFCreator.PhoneAreaCode = uploadedLIKData.PhoneAreaCode;
            PDFCreator.Rank = uploadedLIKData.Rank;
            PDFCreator.Unit = uploadedLIKData.Unit;
            PDFCreator.WorkPhone = uploadedLIKData.WorkPhone;
            PDFCreator.WorkPhoneAreaCode = uploadedLIKData.WorkPhoneAreaCode;

            PDFCreator.FillPDF(stream);
            stream.Position = 0;
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
