using System.Collections.Generic;
using gregs_list_csharp.db;
using gregs_list_csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregs_list_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            try
            {
                return Ok(FakeDB.Cars);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                FakeDB.Cars.Add(newCar);
                return Ok(newCar);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{carId}")]
        public ActionResult<Car> GetCar(string carId)
        {
            try
            {
                Car foundCar = FakeDB.Cars.Find(c => c.Id == carId);
                if (foundCar == null)
                {
                    throw new System.Exception("Car Does Not Exist");
                }
                return Ok(foundCar);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{carId}")]
        public ActionResult<Car> DeleteCar(string carId)
        {
            try
            {
                Car carToRemove = FakeDB.Cars.Find(c => c.Id == carId);
                if (FakeDB.Cars.Remove(carToRemove))
                {
                    return Ok("Car Deleted");
                }
                else
                {
                    throw new System.Exception("Invalid Car ID");
                }
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPut("{carId}")]
        public ActionResult<Car> EditCar(string carId, Car updatedCar)
        {
            try
            {
                Car carToUpdate = FakeDB.Cars.Find(c => c.Id == carId);
                if (carToUpdate == null)
                {
                    throw new System.Exception("Car does not exist");
                }
                // set each property if it was provided
                carToUpdate.Make = updatedCar.Make;
                carToUpdate.Model = updatedCar.Model;
                carToUpdate.Year = updatedCar.Year;
                carToUpdate.Miles = updatedCar.Miles;
                carToUpdate.Price = updatedCar.Price;

                return Ok(carToUpdate);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}