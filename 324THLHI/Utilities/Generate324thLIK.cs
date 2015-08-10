using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _324THLHI.Utilities
{

    public class Generate324thLIK
    {
        private string Key_LogingDate = "DATE REQUESTED FOR LODGING";
        private string Key_Unit = "UNIT";
        private string Key_Name = "NAME";
        private string Key_Rank = "RANK";
        private string Key_Address = "ADDRESS";
        private string Key_CityStateZip = "CITYSTATEZIP";
        private string Key_PhoneAreaCode = "HOME PHONE";
        private string Key_Phone = "undefined";
        private string Key_WorkAreaCode = "WORK PHONE";
        private string Key_WorkPhone = "undefined_2";
        private string Key_InitialsCommuting = "normal commuting distance  51 miles to the unit";
        private string Key_Mileage = "Text1";
        private string Key_InitialsOrders = "only I may not use this program if I am on any type of orders ie Annual Training AT Active Duty";
        private string Key_InitialsResponsible = "lodging if I fail to honor my reservation without proper notification to the unit It is my responsibility to";
        private string Key_InitialsNotReimbursable = "costs are not reimbursable under this program";
        private string Key_InitialsRoomCharges = "upgrade and increase the cost of the room I will assume the entire room charge without any assistance";
        private string Key_InitialsUpgrades = "quarters This includes but is not limited to local and long distance telephone refreshments movies and";
        private string Key_PrintedNameAndRank = "Printed Name and Grade of Soldier";
        private string Key_PrintedCommanderNameAndRank = "Printed Name and Grade of Commander";
        private string Key_Unit2 = "Unit";
        private string Key_Email = "Email";
        private string Key_SoldierSignature2 = "Signature of Soldier Date";
        private string Key_SoldierSignature = "Signature of Soldier";
        private string Key_CommandersSignature2 = "Commanders Signature  Date";
        private string Key_CommandersSignature = "Commanders Signature";
        private string Key_Date = "Date";
        private string Key_Date2 = "Date_2";
        private int CurrentKeyCount = 0;

        public List<string> LodgingDates { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Address { get; set; }
        public string CityStateZip { get; set; }
        public string PhoneAreaCode { get; set; }
        public string Phone { get; set; }
        public string WorkPhoneAreaCode { get; set; }
        public string WorkPhone { get; set; }
        public string Initials { get; set; }
        public string Mileage { get; set; }
        public string Email { get; set; }

        private byte[] PDFBytes;
        private string PDFLocation;
        private List<MemoryStream> NewPDFStreams;
        private MemoryStream NewPDF;

        public Generate324thLIK()
        {
            PDFLocation = AppDomain.CurrentDomain.GetData("DataDirectory")
                .ToString() + ".\\324LIKRequest.pdf";
            FileStream file = new FileStream(PDFLocation, FileMode.Open);
            var stream = new MemoryStream();
            file.CopyTo(stream);
            PDFBytes = stream.ToArray();
            LodgingDates = new List<string>();
            NewPDFStreams = new List<MemoryStream>();
            NewPDF = new MemoryStream();
        }

        public void FillPDF(Stream ToFill)
        {
            foreach(var LodgingDate in LodgingDates)
            {
                FillFirstPage(LodgingDate);
            }
            FillLastPage();
            StichAllStreams();
            NewPDF.WriteTo(ToFill);
        }

        private void StichAllStreams()
        {
            var firstStream = NewPDFStreams.First();
            firstStream.Position = 0;
            var reader = new PdfReader(firstStream.ToArray());
            var sourceDocument = new Document(reader.GetPageSizeWithRotation(1));
            var pdfCopyProvider = new PdfCopy(sourceDocument, NewPDF);
            pdfCopyProvider.CloseStream = false;
            sourceDocument.Open();
            foreach(var pageStream in NewPDFStreams)
            {
                pageStream.Position = 0;
                reader = new PdfReader(pageStream);
                var importedPage = pdfCopyProvider.GetImportedPage(reader, 1);
                pdfCopyProvider.AddPage(importedPage);
            }
            sourceDocument.Close();
            reader.Close();
        }

        private void FillFirstPage(string LodgingDate)
        {
            var PDF = GetFirstPage();
            MemoryStream toFill = new MemoryStream();
            //Modify the pdf
            PdfStamper newPDF = new PdfStamper(PDF, toFill);
            newPDF.Writer.CloseStream = false;
            AcroFields fields = newPDF.AcroFields;

            //set fields
            fields.RenameField(Key_LogingDate, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), LodgingDate);
            CurrentKeyCount++;

            fields.RenameField(Key_Unit, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Unit);
            CurrentKeyCount++;

            fields.RenameField(Key_Name, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Name);
            CurrentKeyCount++;


            fields.RenameField(Key_Rank, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Rank);
            CurrentKeyCount++;

            fields.RenameField(Key_Address, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Address);
            CurrentKeyCount++;

            fields.RenameField(Key_CityStateZip, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), CityStateZip);
            CurrentKeyCount++;

            fields.RenameField(Key_PhoneAreaCode, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), PhoneAreaCode);
            CurrentKeyCount++;

            fields.RenameField(Key_Phone, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Phone);
            CurrentKeyCount++;

            fields.RenameField(Key_WorkAreaCode, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), WorkPhoneAreaCode);
            CurrentKeyCount++;

            fields.RenameField(Key_WorkPhone, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), WorkPhone);
            CurrentKeyCount++;

            fields.RenameField(Key_InitialsCommuting, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Initials);
            CurrentKeyCount++;

            fields.RenameField(Key_Mileage, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Mileage);
            CurrentKeyCount++;

            fields.RenameField(Key_InitialsOrders, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Initials);
            CurrentKeyCount++;

            fields.RenameField(Key_InitialsResponsible, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Initials);
            CurrentKeyCount++;

            fields.RenameField(Key_InitialsNotReimbursable, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Initials);
            CurrentKeyCount++;

            fields.RenameField(Key_InitialsRoomCharges, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Initials);
            CurrentKeyCount++;

            fields.RenameField(Key_InitialsUpgrades, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Initials);
            CurrentKeyCount++;

            fields.RenameField(Key_PrintedNameAndRank, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Name + " " + Rank);
            CurrentKeyCount++;

            fields.RenameField(Key_Unit2, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Unit);
            CurrentKeyCount++;

            fields.RenameField(Key_Email, CurrentKeyCount.ToString());
            fields.SetField(CurrentKeyCount.ToString(), Email);
            CurrentKeyCount++;

            fields.RenameField(Key_SoldierSignature, CurrentKeyCount.ToString());
            CurrentKeyCount++;
            fields.RenameField(Key_CommandersSignature, CurrentKeyCount.ToString());
            CurrentKeyCount++;
            fields.RenameField(Key_SoldierSignature2, CurrentKeyCount.ToString());
            CurrentKeyCount++;
            fields.RenameField(Key_CommandersSignature2, CurrentKeyCount.ToString());
            CurrentKeyCount++;
            fields.RenameField(Key_PrintedCommanderNameAndRank, CurrentKeyCount.ToString());
            CurrentKeyCount++;
            fields.RenameField(Key_Date, CurrentKeyCount.ToString());
            CurrentKeyCount++;
            fields.RenameField(Key_Date2, CurrentKeyCount.ToString());
            CurrentKeyCount++;
            
            newPDF.FormFlattening = false;
            newPDF.Close();

            NewPDFStreams.Add(toFill);
        }

        private void FillLastPage()
        {
            var PDF = GetSecondPage();
            MemoryStream toFill = new MemoryStream();
            //Modify the pdf
            PdfStamper newPDF = new PdfStamper(PDF, toFill);
            newPDF.Writer.CloseStream = false;
            AcroFields fields = newPDF.AcroFields;
            //set fields
            //fields.SetField(Key_LogingDate, LodgingDate);
            fields.SetField(Key_Unit, Unit);
            fields.SetField(Key_Name, Name);
            fields.SetField(Key_Rank, Rank);
            fields.SetField(Key_Address, Address);
            fields.SetField(Key_CityStateZip, CityStateZip);
            fields.SetField(Key_PhoneAreaCode, PhoneAreaCode);
            fields.SetField(Key_Phone, Phone);
            fields.SetField(Key_WorkAreaCode, WorkPhoneAreaCode);
            fields.SetField(Key_WorkPhone, WorkPhone);
            fields.SetField(Key_InitialsCommuting, Initials);
            fields.SetField(Key_Mileage, Mileage);
            fields.SetField(Key_InitialsOrders, Initials);
            fields.SetField(Key_InitialsResponsible, Initials);
            fields.SetField(Key_InitialsNotReimbursable, Initials);
            fields.SetField(Key_InitialsRoomCharges, Initials);
            fields.SetField(Key_InitialsUpgrades, Initials);
            fields.SetField(Key_PrintedNameAndRank, Name + " " + Rank);
            fields.SetField(Key_Unit2, Unit);
            fields.SetField(Key_Email, Email);

            var test = fields.GetField(Key_LogingDate);


            newPDF.FormFlattening = false;
            newPDF.Close();

            NewPDFStreams.Add(toFill);
        }

        private PdfReader GetFirstPage()
        {
            PdfReader PDF = new PdfReader(PDFBytes);
            PDF.RemoveUsageRights();
            PDF.SelectPages("1");
            return PDF;
        }

        private PdfReader GetSecondPage()
        {
            PdfReader PDF = new PdfReader(PDFBytes);
            PDF.RemoveUsageRights();
            PDF.SelectPages("2");
            return PDF;
        }
    }
}
