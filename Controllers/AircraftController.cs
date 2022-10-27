using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using VehicleGarage.Common.Models.DTOs;
using VehicleGarage.Core.Models.Responses;
using VehicleGarage.Infrastructure.Services.Contract;

namespace VehicleGarage.Controllers
{
    [ApiController]
    [Route("api/aircraft")]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;

        public AircraftController(IAircraftService aircraftService)
        {
            _aircraftService = aircraftService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<AircraftDTO>>> GetAircraftById([FromRoute] int id)
        {
            try
            {
                var result = await _aircraftService.GetAircraftById(id);

                return Ok(new BaseResponse<AircraftDTO>
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    CodeDescription = "SUCCESS",
                    innerObject = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new BaseResponse<AircraftDTO>
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    CodeDescription = "FODEU",
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}
