using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;
using Microsoft.AspNetCore.Mvc;

namespace KtwAutomotiveEngineering.Api.V1.Controllers.WorkingTime
{
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    public class WorkDayController(IServiceManager service) : ApiControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateWorkDay([FromBody] WorkDayForCreationDto workDay)
        {
            if (workDay is null)
                return BadRequest("WorkDayForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createdWorkDay = await _service.WorkDayService.CreateWorkDayAsync(workDay);

            return CreatedAtRoute("WorkDayById", new { id = createdWorkDay.Id }, createdWorkDay);
        }
    }
}
