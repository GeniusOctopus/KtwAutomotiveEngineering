using KtwAutomotiveEngineering.Service.Contracts;
using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;
using Microsoft.AspNetCore.Mvc;

namespace KtwAutomotiveEngineering.Api.V1.Controllers.WorkingTime
{
    [ApiController]
    [Route("api/v{version:apiversion}/worktask/{workTaskId}[controller]")]
    public class WorkSlicesController(IServiceManager service) : ApiControllerBase
    {
        private readonly IServiceManager _service = service;

        [HttpGet(Name = "GetWorkSliceForWorkTask")]
        public async Task<IActionResult> GetWorkSlicesForWorkDay(Guid workTaskId)
        {
            var workTasks = await _service.WorkSliceService.GetWorkSlicesAsync(workTaskId, trackChanges: false);

            return Ok(workTasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkSliceForWorkTask(Guid workTaskId, [FromBody] WorkSliceForCreationDto workSlice)
        {
            if (workSlice is null)
                return BadRequest("WorkSliceForCreationDto object is null");

            var workSliceToReturn = await _service.WorkSliceService.CreateWorkSliceForWorkTask(workTaskId, workSlice, trackChanges: false);

            return CreatedAtRoute("GetWorkSliceForWorkTask", new { workTaskId, id = workSliceToReturn.Id }, workSliceToReturn);
        }
    }
}
