using BookingSystemBackEnd.Application.Commands;
using BookingSystemBackEnd.Data;
using BookingSystemBackEnd.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemBackEnd.Application
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRespoitory;
        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRespoitory = bookingRepository;
        }

        public async Task<bool> ResourceValidation(BookingCommand bookingCommand)
        {
            var resourcesBookingData = await bookingRespoitory.GetResourceData(bookingCommand.ResourceId);
            if (resourcesBookingData.Count > 0)
            {
                if (bookingCommand.BookedQuantity > resourcesBookingData.FirstOrDefault().Quantity)
                    return false;

                foreach (var resourceDb in resourcesBookingData)
                {
                    if (bookingCommand.DateFrom >= resourceDb.DateFrom && bookingCommand.DateFrom <= resourceDb.Dateto
                        || bookingCommand.DateFrom >= resourceDb.DateFrom && bookingCommand.DateTo <= resourceDb.Dateto
                        || bookingCommand.DateTo >= resourceDb.DateFrom && bookingCommand.DateFrom <= resourceDb.Dateto)
                    {
                        return false;
                    }

                }
            }
            return true;
        }
    }
}
