using BookingSpot.Data;
using BookingSpot.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingSpot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private IDataContext _data;

        public BookingController(IDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            return Ok(_data.getBookings());
        }

        // Need to have: As a user, I want to book a camping spot.
        [HttpPost]
        public ActionResult AddBooking([FromBody] Booking booking)
        {
            _data.addBooking(booking);
            return Ok("Gelukt! Booking is toegevoegd");
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(int id)
        {
            return Ok(_data.getBookingByID(id));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            var bookingToDelete = _data.getBookingByID(id);
            if (bookingToDelete == null)
            {
                return NotFound();
            }

            _data.deleteBooking(id);
            return Ok("Gelukt! Booking is verwijderd!");
        }
    }
}
