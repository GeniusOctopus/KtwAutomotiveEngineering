using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;
using Microsoft.AspNetCore.Mvc;

namespace KtwAutomotiveEngineering.Api.V1.Controllers.WorkingTime
{
    [ApiController]
    [Route("api/v{version:apiversion}/[controller]")]
    public class WorkTaskController(IServiceManager service) : ApiControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpPost]
        public async Task<IActionResult> CreateWorkTaskForWorkDay(Guid workDayId, [FromBody] WorkTaskForCreationDto workTask)
        {
            if (workTask is null)
                return BadRequest("WorkTaskForCreationDto object is null");

            var workTaskToReturn = await _service.WorkTaskService.CreateWorkTaskForWorkDay(workDayId, workTask, trackChanges: false);

            return CreatedAtRoute("GetWorkTaskForWorkDay", new { workDayId, id = workTaskToReturn.Id }, workTaskToReturn);
        }
    }
}
