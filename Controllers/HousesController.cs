using System.Collections.Generic;
using gregs_list_csharp.db;
using gregs_list_csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregs_list_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<House>> Get()
        {
            try
            {
                return Ok(FakeDB.Houses);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<House> Create([FromBody] House newHouse)
        {
            try
            {
                FakeDB.Houses.Add(newHouse);
                return Ok(newHouse);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{houseId}")]
        public ActionResult<House> GetHouse(string houseId)
        {
            try
            {
                House foundHouse = FakeDB.Houses.Find(h => h.Id == houseId);
                if (foundHouse != null)
                {
                    return Ok(foundHouse);
                }
                throw new System.Exception("House Does Not Exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{houseId}")]
        public ActionResult<House> DeleteHouse(string houseId)
        {
            try
            {
                House houseToRemove = FakeDB.Houses.Find(h => h.Id == houseId);
                if (FakeDB.Houses.Remove(houseToRemove))
                {
                    return Ok("House Deleted");
                }
                throw new System.Exception("Invalid House ID");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{houseId}")]
        public ActionResult<House> EditHouse(string houseId, House updatedHouse)
        {
            try
            {
                House houseToUpdate = FakeDB.Houses.Find(h => h.Id == houseId);
                if (houseToUpdate != null)
                {
                    houseToUpdate.Bathrooms = updatedHouse.Bathrooms;
                    houseToUpdate.Bedrooms = updatedHouse.Bedrooms;
                    houseToUpdate.Levels = updatedHouse.Levels;
                    houseToUpdate.Description = updatedHouse.Description;
                    houseToUpdate.Price = updatedHouse.Price;

                    return Ok(houseToUpdate);
                }
                throw new System.Exception("House Does Not Exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}