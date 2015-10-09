using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ParkingSpace.Models;

namespace ParkingSpace.Web.Printing
{
    public interface IParkingTicketPrinter
    {

        void Print(ParkingTicket ticket);

    }
}