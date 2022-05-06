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

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Shipper>>> GetAll()
        {
            return Ok(shippers);   
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Shipper>> GetByID([FromRoute]int id)
        {
            var shipper = shippers.FirstOrDefault(s => s.ShipperID == id);
            if(shipper is null)
            {
                return BadRequest("Shipper not found");
            }
            return Ok(shipper);   
        }
        
        [HttpPost("AddShipper")]
        public async Task<ActionResult<List<Shipper>>> AddShipper([FromQuery]Shipper shipper)
        {
            shippers.Add(shipper);
            return Ok(shippers);   
        }

        [HttpPost("EchoList")]
        public async Task<ActionResult<List<string>>> EchoList([FromBody]List<string> strings)
        {
            return Ok(strings);   
        }
        [HttpPost("EchoCustomTypeList")]
        public async Task<ActionResult<List<Shipper>>> EchoListOfShippers([FromRoute]List<Shipper> shrs)
        {
            // shippers.Add(shrs);
            return Ok(shrs);
        }


        [HttpPut("UpdateShipper")]
        public ActionResult<List<Shipper>> UpdateShipper([FromBody]Shipper request)
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

        [HttpDelete("DeleteShipper/{id}")]
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
