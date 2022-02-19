using BookingSystemBackEnd.Data.ViewModel;
using BookingSystemBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5;

namespace BookingSystemBackEnd.Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext dataContext;
        public BookingRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<int> BookResource(Booking booking)
        {
            await dataContext.Booking.AddAsync(booking);
            await dataContext.SaveChangesAsync();
            return booking.Id;
        }

        public async Task UpdateResource(int quantityRequired, int resourceId)
        {
            var ressource = await dataContext.Resources.FirstOrDefaultAsync(x => x.Id == resourceId);
            if (ressource != null)
            {
                ressource.Quantity -= quantityRequired;
                dataContext.Update(ressource);
                await dataContext.SaveChangesAsync();
            }

        }

        public async Task<List<BookResourceViewModel>> GetResourceData(int resourceId)
        {
            var query = await dataContext.Booking.Include(x => x.Resource).Where(x => x.Resource.Id == resourceId).ToListAsync();
            return query.Select(x => new BookResourceViewModel { DateFrom = x.DateFrom, Dateto = x.DateTo, Quantity = x.Resource.Quantity }).ToList();

        }

        public async Task<List<Resources>> GetResources()
        {
            return await dataContext.Resources.ToListAsync();
        }

        public async Task<Resources> GetResourceById(int resourceId)
        {
            return await dataContext.Resources.FirstOrDefaultAsync(x => x.Id == resourceId);
        }
    }
}
