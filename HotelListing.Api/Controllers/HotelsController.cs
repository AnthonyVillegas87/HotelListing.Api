using AutoMapper;
using HotelListing.Api.Contracts;
using HotelListing.Api.Data;
using HotelListing.Api.Models.Hotel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelsRepository _hotelsRepository;
        private readonly IMapper _mapper;

        public HotelsController(IHotelsRepository hotelsRepository, IMapper mapper)
        {
            this._hotelsRepository = hotelsRepository;
            this._mapper = mapper;
        }
        // GET: api/<HotelsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
        {
            var hotels = await _hotelsRepository.GetAllAsync();   
            // Return status *200* OK
            return Ok(_mapper.Map<List<HotelDto>>(hotels));
        }

        // GET api/<HotelsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDto>> GetHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                // Return status *404* Not Found
                return NotFound();           
            }
            return Ok(_mapper.Map<HotelDto>(hotel));
        }

        // POST api/<HotelsController>
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto newHotel)
        {
            var hotel = _mapper.Map<Hotel>(newHotel);
           await _hotelsRepository.AddAsync(hotel);
            
            // CreatedAtAction specifies *201* (Created) response
            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);       
        }

        
        // PUT api/<HotelsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, HotelDto updatedHotel)
        {
            if (id != updatedHotel.Id)
            {
                // Return status *400* BadRequest
                return BadRequest("Invalid record ID.");           
            }
            
            var hotel = await _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                // Return status *404* Not Found
                return NotFound();           
            }
            
            _mapper.Map(updatedHotel, hotel);

            try
            {
                await _hotelsRepository.UpdateAsync(hotel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await HotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            // Return status *204* No Content
            return NoContent();       
        }

        // DELETE api/<HotelsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotel = _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                // Return status *404* Not Found
                return NotFound(new { message = "Hotel not found." });
            }
            _hotelsRepository.DeleteAsync(id);
            
            // Return status *204* No Content
            return NoContent();      
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsRepository.Exists(id);
        }
    }
}
