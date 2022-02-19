using BookingSystemBackEnd.Application.Commands;
using BookingSystemBackEnd.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackEnd.Application
{
    public interface IBookingService
    {
        Task<bool> ResourceValidation(BookingCommand bookingCommand);
    }
}
