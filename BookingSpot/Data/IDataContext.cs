using BookingSpot.Models;
using System.Collections.Generic;

namespace BookingSpot.Data
{
    public interface IDataContext
    {
        // USER CODE
        void newUser(User user);
        IEnumerable<User> getUsers();
        void deleteUser(int id);
        User getUserByID(int id);
        User getUserByAccountName(string accountName);

        // BOOKING CODE
        void addBooking(Booking booking);
        void deleteBooking(int id);
        IEnumerable<Booking> getBookings();
        Booking getBookingByID(int id);

        // CAMPINGSPOT CODE
        void newCampingSpot(CampingSpot spot);
        IEnumerable<CampingSpot> getCampingSpots();
        CampingSpot getCampingSpotByID(int id);
        void deleteCampingSpot(int id);
    }
}
