using BookingSystemBackEnd.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5
{
    public class Resources
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public ICollection<Booking> Booking { get; set; }

    }
}
