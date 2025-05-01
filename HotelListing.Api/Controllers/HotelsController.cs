using HotelListing.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {   
        private static List<Hotel> _hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Name = "Grand Plaza", Address = "123 Main St.", Rating = 4.5 },
            new Hotel { Id = 2, Name = "Hilton", Address = "456 Main St.", Rating = 4.0 },
            new Hotel { Id = 3, Name = "Marriott", Address = "789 Main St.", Rating = 3.5 }       
        };
        // GET: api/<HotelsController>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            // Return status *200* OK
            return Ok(_hotels);
        }

        // GET api/<HotelsController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                // Return status *404* Not Found
                return NotFound();           
            }
            return Ok(hotel);
        }

        // POST api/<HotelsController>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if (_hotels.Any(h => h.Id == newHotel.Id))
            {
                // Return status *400* BadRequest
                return BadRequest("Hotel already exists.");
            }
            _hotels.Add(newHotel);
            
            // CreatedAtAction specifies status *201* (Created) response
            return CreatedAtAction(nameof(Get), new { id = newHotel.Id }, newHotel);       
        }

        // PUT api/<HotelsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hotel updatedHotel)
        {
            var existingHotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (existingHotel == null)
            {
                // Return status *404* Not Found
                return NotFound();
            }
            existingHotel.Name = updatedHotel.Name;
            existingHotel.Address = updatedHotel.Address;
            existingHotel.Rating = updatedHotel.Rating;  
            
            // Return status *204* No Content
            return NoContent();       
        }

        // DELETE api/<HotelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotel = _hotels.FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                // Return status *404* Not Found
                return NotFound(new { message = "Hotel not found." });
            }
            _hotels.Remove(hotel);
            
            // Return status *204* No Content
            return NoContent();      
        }
    }
}
