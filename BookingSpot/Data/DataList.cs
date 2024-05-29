using BookingSpot.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingSpot.Data
{
    public class DataList: IDataContext
    {
        List<User> users = new List<User>();
        List<Booking> bookings = new List<Booking>();
        List<CampingSpot> campingSpots = new List<CampingSpot>();

        // USER code
        public void newUser(User user)
        {
            if (users.Any(u => u.AccountName == user.AccountName))
            {
                throw new System.Exception("Een gebruiker met deze accountnaam bestaat al.");
            }
            users.Add(user);
        }

        public IEnumerable<User> getUsers()
        {
            return users;
        }

        public void deleteUser(int id)
        {
            var user = getUserByID(id);
            if (user != null)
            {
                users.Remove(user);
            }
        }

        public User getUserByID(int id)
        {
            return users.FirstOrDefault(u => u.id == id);
        }

        public User getUserByAccountName(string accountName)
        {
            return users.FirstOrDefault(u => u.AccountName == accountName);
        }

        // BOOKING code
        public void addBooking(Booking booking) // Veranderd van newBooking naar addBooking
        {
            bookings.Add(booking);
        }

        public IEnumerable<Booking> getBookings()
        {
            return bookings;
        }

        public void deleteBooking(int id)
        {
            var booking = getBookingByID(id);
            if (booking != null)
            {
                bookings.Remove(booking);
            }
        }

        public Booking getBookingByID(int id)
        {
            return bookings.FirstOrDefault(b => b.id == id);
        }

        // CAMPING SPOT MANAGEMENT
        public void newCampingSpot(CampingSpot spot)
        {
            campingSpots.Add(spot);
        }

        public IEnumerable<CampingSpot> getCampingSpots()
        {
            return campingSpots;
        }

        public CampingSpot getCampingSpotByID(int id)
        {
            return campingSpots.FirstOrDefault(s => s.id == id);
        }

        public void deleteCampingSpot(int id)
        {
            var spot = getCampingSpotByID(id);
            if (spot != null)
            {
                campingSpots.Remove(spot);
            }
        }
    }
}
