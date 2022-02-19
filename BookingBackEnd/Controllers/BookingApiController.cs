using BookingSystemBackEnd.Application;
using BookingSystemBackEnd.Application.Commands;
using BookingSystemBackEnd.Data;
using BookingSystemBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingApiController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingService _bookingServce;
        public BookingApiController( IBookingRepository bookingRepository, IBookingService bookingServce)
        {
            _bookingRepository = bookingRepository;
            _bookingServce = bookingServce;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _bookingRepository.GetResources();
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> BookResource(BookingCommand bookingCommand)
        {
            var canResourceBeBooked= await _bookingServce.ResourceValidation(bookingCommand);
            int? resourceId = null;
            if (canResourceBeBooked)
            {
                var resource = await _bookingRepository.GetResourceById(bookingCommand.ResourceId);
                resourceId = await _bookingRepository.BookResource(
                    new Booking { BookedQuantity = bookingCommand.BookedQuantity, DateFrom = bookingCommand.DateFrom, DateTo = bookingCommand.DateTo, Resource= resource });
                await _bookingRepository.UpdateResource(bookingCommand.BookedQuantity, bookingCommand.ResourceId);
                return Ok(resourceId);
            }
            return NoContent();
        }
    }
}
