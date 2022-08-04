using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UBER;

namespace PassengersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        static List<PassengerModel> passengerList = new List<PassengerModel>()
        {
            new PassengerModel(){PassengerId=1,PassengerName="Pass1",Gender="Female",Location="Pune",Phone=111111},
            new PassengerModel(){PassengerId=2,PassengerName="Pass2",Gender="Male",Location="Mumbai",Phone=222222},
            new PassengerModel(){PassengerId=3,PassengerName="Pass3",Gender="Female",Location="Delhi",Phone=333333}
        };

        [HttpGet]
        public List<PassengerModel> Get()
        {
            return passengerList;
        }

        [HttpGet("{id}")]
        public PassengerModel Get(int id)
        {
            PassengerModel obj = passengerList.Find(item => item.PassengerId == id);
            return obj;
        }

        [HttpPost]
        public List<PassengerModel> Post([FromBody] PassengerModel obj)
        {
            passengerList.Add(obj);
            return passengerList;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PassengerModel newObj)
        {
            PassengerModel oldObj = passengerList.Find(item => item.PassengerId == id);
            if (oldObj != null)
            {
                passengerList.Insert(id - 1, newObj);
                passengerList.Remove(oldObj);
                return Ok();
            }
            return NotFound("Failed : No such Passenger Exists");

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            PassengerModel obj = passengerList.Find(item => item.PassengerId == id);
            if (obj != null)
            {
                passengerList.Remove(obj);
                return Ok();
            }
            return NotFound("Failed : No such Passenger Exists");
        }
    }
}