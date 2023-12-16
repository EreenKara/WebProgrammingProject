using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        AirLineContext context= new AirLineContext();

        // GET: api/<AirplanesController>
        [HttpGet]
        public ActionResult<IEnumerable<Airplane>> Get()
        {

            var airplanes= (from plane in context.Airplanes
                           select plane).ToList();
            if(airplanes.Count<0)
            {
                return NotFound();
            }
            return airplanes;
        }

        // GET api/<AirplanesController>/5
        [HttpGet("{id}")]
        public ActionResult<Airplane> Get(int? id)
        {
            if(id is null)
            {
                return NotFound();
            }
            var airplane = (from plane in context.Airplanes
                            where plane.ID==id
                            select plane).FirstOrDefault();
            if(airplane==null)
            {
                return NotFound();
            }
            return airplane;
        }

        // POST api/<AirplanesController>
        [HttpPost]
        public IActionResult Post([FromBody] Airplane parameterAirplane)
        {
            context.Airplanes.Add(parameterAirplane);
            context.SaveChanges();
            return Ok();
        }

        // PUT api/<AirplanesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] Airplane parameterAirplane)
        {
            if(id is null)
            {
                return BadRequest();
            }
            var airplane = (from plane in context.Airplanes
                           where plane.ID == id
                           select plane).FirstOrDefault();
            if(airplane==null)
            {
                return NotFound();
            }
            airplane.ColumnSeatNumberBusiness = parameterAirplane.ColumnSeatNumberBusiness;
            airplane.RowSeatNumberBusiness = parameterAirplane.RowSeatNumberBusiness;
            airplane.RowSeatNumberEconomy = parameterAirplane.RowSeatNumberEconomy;
            airplane.ColumnSeatNumberEconomy = parameterAirplane.ColumnSeatNumberEconomy;
            airplane.Model=parameterAirplane.Model;
            context.Update(airplane);
            context.SaveChanges();

            return Ok();
        }

        // DELETE api/<AirplanesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }
            var airplane = (from plane in context.Airplanes
                           where plane.ID==id 
                           select plane).FirstOrDefault();
            if(airplane==null)
            {
                return NotFound();
            }
            if (airplane.Flights.Count > 0)
            {
                return NotFound("Bu ucagi silmek baglantili oldugu tablodaki verilere zarar verecek");
            }
            context.Remove(airplane);
            context.SaveChanges();

            return Ok();
        }
    }
}
