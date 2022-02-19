using BookingSystemBackEnd.Data.ViewModel;
using BookingSystemBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5;

namespace BookingSystemBackEnd.Data
{
    public interface IBookingRepository
    {
        Task<List<Resources>> GetResources();
        Task<int> BookResource(Booking booking);
        Task<List<BookResourceViewModel>> GetResourceData(int resourceId);
        Task UpdateResource(int quantityRequired, int resourceId);
        Task<Resources> GetResourceById(int resourceId);
    }
}
