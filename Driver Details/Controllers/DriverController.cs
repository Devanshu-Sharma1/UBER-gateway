using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DriverDetails;

namespace DriverDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        static List<DriverModel> driverList = new List<DriverModel>()
        {
            new DriverModel(){DriverId=1,DriverName="Driver1",Gender="Female",Location="Pune",DriverPhone=111111},
            new DriverModel(){DriverId=2,DriverName="Driver2",Gender="Female",Location="Mumbai",DriverPhone=222222},
            new DriverModel(){DriverId=3,DriverName="Driver3",Gender="Male",Location="Delhi",DriverPhone=333333}
        };

        [HttpGet]
        public List<DriverModel> Get()
        {
            return driverList;
        }

        [HttpGet("{id}")]
        public DriverModel Get(int id)
        {
            DriverModel obj = driverList.Find(item => item.DriverId == id);
            return obj;
        }

        [HttpPost]
        public List<DriverModel> Post([FromBody] DriverModel obj)
        {
            driverList.Add(obj);
            return driverList;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DriverModel newObj)
        {
            DriverModel oldObj = driverList.Find(item => item.DriverId == id);
            if (oldObj != null)
            {
                driverList.Insert(id - 1, newObj);
                driverList.Remove(oldObj);
                return Ok(driverList);
            }
            return NotFound("Failed : No such Driver Exists");

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DriverModel obj = driverList.Find(item => item.DriverId == id);
            if (obj != null)
            {
                driverList.Remove(obj);
                return Ok(driverList);
            }
            return NotFound("Failed : No such Driver Exists");
        }
    }
}