using BookingSpot.Data;
using BookingSpot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookingSpot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IDataContext _data;

        public UserController(IDataContext data)
        {
            _data = data;
        }

        // Need to have: As a user, I want to login into the system.
        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LoginRequest login)
        {
            var user = _data.getUserByAccountName(login.AccountName);
            if (user == null || !user.CheckPassword(login.Password))
            {
                return Unauthorized("Ongeldige inloggegevens.");
            }

            return Ok(user);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_data.getUsers());
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            _data.newUser(user);
            return Ok("Gelukt! User is toegevoegd");
        }


        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return Ok(_data.getUserByID(id));
        }

        // Need to have: As a user, I want to change my user information.
        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _data.getUserByID(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.FirstName = updatedUser.FirstName;
            user.AccountName = updatedUser.AccountName;

            return Ok("Gelukt! User is bijgewerkt!");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userToDelete = _data.getUserByID(id);
            if (userToDelete == null)
            {
                return NotFound();
            }

            _data.deleteUser(id);
            return Ok("Gelukt! User is verwijderd!");
        }

        // Need to have: As a user, I want to have an overview of my bookings.
        [HttpGet("{id}/bookings")]
        public ActionResult<IEnumerable<Booking>> GetUserBookings(int id)
        {
            var bookings = _data.getBookings().Where(b => b.UserId == id);
            return Ok(bookings);
        }
    }

    public class LoginRequest
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
    }
}
