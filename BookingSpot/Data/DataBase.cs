using LiteDB;
using BookingSpot.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookingSpot.Data
{
    public class DataBase : IDataContext
    {
        private LiteDatabase db;

        public DataBase()
        {
            db = new LiteDatabase(@"Airbnb.db");
        }

        // USER CODE
        public void newUser(User user)
        {
            var users = db.GetCollection<User>("Users");
            var existingUser = users.FindOne(u => u.AccountName == user.AccountName);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Accountnaam bestaat al.");
            }
            users.Insert(user);
        }

        public void deleteUser(int id)
        {
            db.GetCollection<User>("Users").Delete(id);
        }

        public IEnumerable<User> getUsers()
        {
            return db.GetCollection<User>("Users").FindAll();
        }

        public User getUserByID(int id)
        {
            return db.GetCollection<User>("Users").FindById(id);
        }

        public User getUserByAccountName(string accountName)
        {
            return db.GetCollection<User>("Users").FindOne(u => u.AccountName == accountName);
        }

        // BOOKING CODE
        public void addBooking(Booking booking)
        {
            db.GetCollection<Booking>("Bookings").Insert(booking);
        }

        public void deleteBooking(int id)
        {
            db.GetCollection<Booking>("Bookings").Delete(id);
        }

        public IEnumerable<Booking> getBookings()
        {
            return db.GetCollection<Booking>("Bookings").FindAll();
        }

        public Booking getBookingByID(int id)
        {
            return db.GetCollection<Booking>("Bookings").FindById(id);
        }

        // CAMPINGSPOT CODE
        public void newCampingSpot(CampingSpot spot)
        {
            db.GetCollection<CampingSpot>("CampingSpots").Insert(spot);
        }

        public IEnumerable<CampingSpot> getCampingSpots()
        {
            return db.GetCollection<CampingSpot>("CampingSpots").FindAll();
        }

        public CampingSpot getCampingSpotByID(int id)
        {
            return db.GetCollection<CampingSpot>("CampingSpots").FindById(id);
        }

        public void deleteCampingSpot(int id)
        {
            db.GetCollection<CampingSpot>("CampingSpots").Delete(id);
        }
    }
}
