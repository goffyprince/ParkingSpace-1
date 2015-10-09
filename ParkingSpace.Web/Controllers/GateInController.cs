using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingSpace.Models;
using ParkingSpace.Services;
using System;
using ParkingSpace.Web.Printing;
using Rotativa;

namespace ParkingSpace.Web.Controllers
{

    [RoutePrefix("gate-in")]
    public class GateInController : Controller
    {

        #region static members

        private static ParkingTicketService service;

        static GateInController()
        {
            service = new ParkingTicketService();
        }

        #endregion

        private IParkingTicketPrinter printer;

        public GateInController()
        {
            printer = new PdfParkingTicketPrinter(this.ControllerContext);
        }

        public GateInController(IParkingTicketPrinter printer)
        {
            this.printer = printer;
        }

        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateTicket")]
        public ActionResult CreateTicket(string plateNo)
        {
            var ticket = service.CreateParkingTicket(plateNo);
            printer = new PdfParkingTicketPrinter(this.ControllerContext);

            printer.Print(ticket);


            TempData["newTicket"] = ticket;
            return RedirectToAction("Index");
        }

        public ActionResult OpenBarrier()
        {
            throw new NotImplementedException();
        }


    }
}