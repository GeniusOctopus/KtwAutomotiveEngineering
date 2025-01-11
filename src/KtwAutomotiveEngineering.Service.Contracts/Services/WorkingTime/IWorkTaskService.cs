using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;

namespace KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime
{
    public interface IWorkTaskService
    {
        Task<IEnumerable<WorkTaskDto>> GetWorkTasksAsync(Guid workDayId, bool trackChanges);
        Task<WorkTaskDto> CreateWorkTaskForWorkDay(Guid workDayId, WorkTaskForCreationDto workTaskForCreation, bool trackChanges);
    }
}
