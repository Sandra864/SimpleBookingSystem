using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackEnd.Data.ViewModel
{
    public class BookResourceViewModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime Dateto { get; set; }
        public int Quantity { get; set; }
    }
}
