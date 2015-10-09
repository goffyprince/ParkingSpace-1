using ParkingSpace.Models;
using Rotativa;
using System.Web;
using System.Web.Mvc;

namespace ParkingSpace.Web.Printing
{
    public class PdfParkingTicketPrinter : IParkingTicketPrinter
    {

        private ControllerContext context;

        public PdfParkingTicketPrinter(ControllerContext context)
        {
            this.context = context;
        }

        void IParkingTicketPrinter.Print(ParkingTicket ticket)
        {
            var r = new ViewAsPdf("RPT-01-ParkingTicket-In", ticket);

            r.PageSize = Rotativa.Options.Size.A6;
            r.PageOrientation = Rotativa.Options.Orientation.Portrait;

            var fileName = ticket.Id + ".pdf";
            var filePath = HttpContext.Current.Server.MapPath("~/App_Data/" + fileName);

            var bytes = r.BuildPdf(context);
            System.IO.File.WriteAllBytes(filePath, bytes);
        }
    }
}