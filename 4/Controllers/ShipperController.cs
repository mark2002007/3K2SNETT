using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/shippers")]
    public class ShipperController : ControllerBase
    {
        private static List<Shipper> shippers = new List<Shipper>
        {
            new Shipper { ShipperID = 1, CompanyName = "ShippyCo", Phone = "+380961975662"},
            new Shipper { ShipperID = 2, CompanyName = "ShipThis", Phone = "+458102837648"},
        };

        [HttpGet]
        public async Task<ActionResult<List<Shipper>>> Get()
        {
            return Ok(shippers);   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shipper>> Get([FromRoute]int id)
        {
            var shipper = shippers.FirstOrDefault(s => s.ShipperID == id);
            if(shipper is null)
            {
                return BadRequest("Shipper not found");
            }
            return Ok(shipper);   
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Shipper>>> AddShipper([FromQuery]Shipper shipper)
        {
            shippers.Add(shipper);
            return Ok(shippers);   
        }

        [HttpPut]
        public async Task<ActionResult<List<Shipper>>> UpdateShipper([FromBody]Shipper request)
        {
            var shipper = shippers.FirstOrDefault(s => s.ShipperID == request.ShipperID);
            if(shipper is null)
            {
                return BadRequest("Shipper not found");
            }

            shipper.CompanyName = request.CompanyName;
            shipper.Phone = request.Phone;
            shipper.Address.City = request.Address.City;
            shipper.Address.Street = request.Address.Street;

            return Ok(shippers);   
        } 

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Shipper>>> Delete(int id)
        {
            var shipper = shippers.FirstOrDefault(s => s.ShipperID == id);
            if(shipper is null)
            {
                return BadRequest("Shipper not found");
            }
            shippers.Remove(shipper);
            return Ok(shippers);   
        } 

    }
}
