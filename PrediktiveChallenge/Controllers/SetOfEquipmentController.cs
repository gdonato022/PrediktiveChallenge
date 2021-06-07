using Microsoft.AspNetCore.Mvc;
using PrediktiveChallenge.Application.Interfaces;

namespace PrediktiveChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetOfEquipmentController : ControllerBase
    {
        private readonly ISetOfEquipmentApplication _setOfEquipmentApplication;

        public SetOfEquipmentController(ISetOfEquipmentApplication setOfEquipmentApplication)
        {
            _setOfEquipmentApplication = setOfEquipmentApplication;
        }

        /// <summary>
        /// Function that takes the model id and year, and returns an object containing the calculated values (Market and Auction)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/{year}")]
        public IActionResult GetCalculatedValues([FromRoute] string id, [FromRoute] string year)
        {
            var result = _setOfEquipmentApplication.GetCalculatedValues(id, year);

            return Ok(result);
        }

    }
}
