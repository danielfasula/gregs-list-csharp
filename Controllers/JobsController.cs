using System.Collections.Generic;
using gregs_list_csharp.db;
using gregs_list_csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace gregs_list_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Job>> Get()
        {
            try
            {
                return Ok(FakeDB.Jobs);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpPost]
        public ActionResult<Job> Create([FromBody] Job newJob)
        {
            try
            {
                FakeDB.Jobs.Add(newJob);
                return Ok(newJob);
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpGet("{jobId}")]
        public ActionResult<Job> GetJob(string jobId)
        {
            try
            {
                Job foundJob = FakeDB.Jobs.Find(j => j.Id == jobId);
                if (foundJob != null)
                {
                    return Ok(foundJob);
                }
                throw new System.Exception("Job Does Not Exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{jobId}")]
        public ActionResult<Job> DeleteJob(string jobId)
        {
            try
            {
                Job jobToRemove = FakeDB.Jobs.Find(j => j.Id == jobId);
                if (FakeDB.Jobs.Remove(jobToRemove))
                {
                    return Ok("Job Deleted");
                }
                throw new System.Exception("Invalid Job ID");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{jobId}")]
        public ActionResult<Job> EditJob(string jobId, Job updatedJob)
        {
            try
            {
                Job jobToUpdate = FakeDB.Jobs.Find(j => j.Id == jobId);
                if (jobToUpdate != null)
                {
                    jobToUpdate.Company = updatedJob.Company;
                    jobToUpdate.JobTitle = updatedJob.JobTitle;
                    jobToUpdate.Hours = updatedJob.Hours;
                    jobToUpdate.Rate = updatedJob.Rate;
                    jobToUpdate.Description = updatedJob.Description;

                    return Ok(jobToUpdate);
                }
                throw new System.Exception("Job Does Not exist");
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}