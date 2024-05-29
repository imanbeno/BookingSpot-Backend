using BookingSpot.Data;
using BookingSpot.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BookingSpot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampingSpotController : ControllerBase
    {
        private readonly IDataContext _data;

        public CampingSpotController(IDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CampingSpot>> Get([FromQuery] CampingSpotFilter filter)
        {
            var spots = _data.getCampingSpots().ToList();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Location))
                {
                    spots = spots.Where(s => s.Location == filter.Location).ToList();
                }
                if (filter.Capacity.HasValue)
                {
                    spots = spots.Where(s => s.Capacity >= filter.Capacity.Value).ToList();
                }
            }

            return Ok(spots);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CampingSpot spot)
        {
            _data.newCampingSpot(spot);
            return Ok("Gelukt! Camping spot is toegevoegd");
        }

        [HttpGet("{id}")]
        public ActionResult<CampingSpot> Get(int id)
        {
            var spot = _data.getCampingSpotByID(id);
            if (spot == null)
            {
                return NotFound();
            }
            return Ok(spot);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCampingSpot(int id)
        {
            var spotToDelete = _data.getCampingSpotByID(id);
            if (spotToDelete == null)
            {
                return NotFound();
            }

            _data.deleteCampingSpot(id);
            return Ok("Gelukt! Camping spot is verwijderd!");
        }
    }

    public class CampingSpotFilter
    {
        public string Location { get; set; }
        public int? Capacity { get; set; }
    }
}
