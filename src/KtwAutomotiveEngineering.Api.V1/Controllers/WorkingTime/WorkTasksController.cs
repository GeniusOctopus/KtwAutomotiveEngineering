using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;
using Microsoft.AspNetCore.Mvc;

namespace KtwAutomotiveEngineering.Api.V1.Controllers.WorkingTime
{
    [ApiController]
    [Route("api/v{version:apiversion}/workday/{workDayId}/[controller]")]
    public class WorkTasksController(IServiceManager service) : ApiControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpGet]
        public async Task<IActionResult> GetWorkTasksForWorkDay(Guid workDayId)
        {
            var workTasks = await _service.WorkTaskService.GetWorkTasksAsync(workDayId, trackChanges: false);

            return Ok(workTasks);
        }

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
