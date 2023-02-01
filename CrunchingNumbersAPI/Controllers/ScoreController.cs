using CrunchingNumbersAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrunchingNumbersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return new JsonResult("Successful get request!");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex);
            }
        }
        [HttpPost]
        public IActionResult Post(Scores score)
        {
            int sampleMaxCount = score.SampleMaxCount;
            int patient = score.Patient;
            int doctor = score.Doctor;

            List<string> results = new List<string>();

            for (int i = 1; i <= sampleMaxCount; i++)
            {
                if (i % doctor == 0 && i % patient == 0)
                {
                    results.Add("Both");
                }
                else if (i % doctor == 0)
                {
                    results.Add("Doctor");
                }
                else if (i % patient == 0)
                {
                    results.Add("Patient");
                }
                else
                {
                    results.Add("None");
                }
            } 

            return new JsonResult(results);
        }
    }
}