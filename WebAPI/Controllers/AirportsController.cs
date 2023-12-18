using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        AirLineContext context = new AirLineContext();

        // GET: api/<AirplanesController>
        [HttpGet]
        public ActionResult<IEnumerable<Airport>> Get()
        {

            var airport = (from aport in context.Airports
                           select aport).ToList();
            if (airport.Count < 0)
            {
                return NotFound();
            }
            return airport;
        }
        // GET: api/<AirplanesController>/join
        [HttpGet("join")]
        public ActionResult<IEnumerable<Airport>> GetJoin()
        {
            var airport = (from aport in context.Airports
                           select new Airport
                           {
                               ID= aport.ID,
                               AirportCode= aport.AirportCode,
                               City= aport.City,
                               Country= aport.Country,
                               ArrivingFlights=(from arriving in context.Flights 
                                                where arriving.ArrivalAirportID == aport.ID select arriving).ToList(),
                               DepartingFlights= (from departing in context.Flights
                                                where departing.ArrivalAirportID == aport.ID select departing).ToList()
                           }).ToList();


            //join departingFlights in context.Flights
            //               on aport.ID equals departingFlights.DepartureAirportID
            //               join arrivingFlights in context.Flights
            //                 on aport.ID equals arrivingFlights.ArrivalAirportID

            return airport;
        }

        // GET: api/<AirplanesController>/join/5
        [HttpGet("join/{id}")]
        public ActionResult<Airport> GetJoin(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var airport = (from aport in context.Airports
                           where aport.ID== id
                           select new Airport
                           {
                               ID = aport.ID,
                               AirportCode = aport.AirportCode,
                               City = aport.City,
                               Country = aport.Country,
                               ArrivingFlights = (from arriving in context.Flights
                                                  where arriving.ArrivalAirportID == aport.ID
                                                  select arriving).ToList(),
                               DepartingFlights = (from departing in context.Flights
                                                   where departing.ArrivalAirportID == aport.ID
                                                   select departing).ToList()
                           }).FirstOrDefault();

            if (airport == null)
            {
                return NotFound();
            }

            return airport;
        }

        // GET api/<AirplanesController>/5
        [HttpGet("code/{code}")]
        public ActionResult<Airport> Get(string code)
        {
            if (code is null)
            {
                return NotFound();
            }
            var airport = (from aport in context.Airports
                           where aport.AirportCode == code
                           select aport).FirstOrDefault();
            if (airport == null)
            {
                return NotFound();
            }
            return airport;
        }

        // GET api/<AirplanesController>/5
        [HttpGet("{id}")]
        public ActionResult<Airport> Get(int? id)
        {
            if (id is null )
            {
                return NotFound();
            }
            var airport = (from aport in context.Airports
                           where aport.ID == id
                           select aport).FirstOrDefault();
            if (airport == null)
            {
                return NotFound();
            }
            return airport;
        }

        // POST api/<AirplanesController>
        [HttpPost]
        public IActionResult Post([FromBody] Airport parameterAirport)
        {
            context.Airports.Add(parameterAirport);
            context.SaveChanges();
            return Ok();
        }

        // PUT api/<AirplanesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] Airport parameterAirplane)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var airport = (from aport in context.Airports
                           where aport.ID == id
                           select aport).FirstOrDefault();
            if (airport == null)
            {
                return NotFound();
            }
            airport.AirportCode = parameterAirplane.AirportCode;
            airport.Country = parameterAirplane.Country;
            airport.City = parameterAirplane.City;
            context.Update(airport);
            context.SaveChanges();

            return Ok();
        }

        // DELETE api/<AirplanesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }
            var airport = (from aport in context.Airports
                           where aport.ID == id
                           select aport).FirstOrDefault();
            if (airport == null)
            {
                return NotFound();
            }
            if (airport.ArrivingFlights.Count > 0)
            {
                return NotFound("Bu ucagi silmek baglantili oldugu tablodaki verilere zarar verecek");
            }
            if (airport.DepartingFlights.Count > 0)
            {
                return NotFound("Bu ucagi silmek baglantili oldugu tablodaki verilere zarar verecek");
            }
            context.Remove(airport);
            context.SaveChanges();

            return Ok();
        }
    }
}
