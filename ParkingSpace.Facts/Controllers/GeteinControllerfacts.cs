using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ParkingSpace.Web.Controllers;
using ParkingSpace.Web.Printing;
using Xunit;
using System.Web.Mvc;
using ParkingSpace.Models;
using ParkingSpace.Services;

namespace ParkingSpace.Facts.Controllers
{

    public class GateInControllerFacts
    {

        public class IndexAction
        {

            [Fact]
            public void ShouldReturnsView()
            {
                var ctrl = new GateInController();

                var r = ctrl.Index();

                Assert.NotNull(r);
                Assert.IsType<ViewResult>(r);
            }
        }

        public class CreateTicketAction
        {

            class FakePrinter : IParkingTicketPrinter
            {

                public bool HasPrinted = false;


                public void Print(ParkingTicket ticket)
                {
                    HasPrinted = true;
                }

                public void Print(ParkingTicket ticket, object args = null)
                {
                    throw new NotImplementedException();
                }
            }

            [Fact]
            public void ShouldCreatePdfFile()
            {
                using (var app = new App(testing: true))
                {

                    var printer = new FakePrinter();
                    var ctrl = new GateInController(printer, app);

                    ctrl.CreateTicket("000");

                    Assert.True(printer.HasPrinted);
                }
            }
        }

    }
}