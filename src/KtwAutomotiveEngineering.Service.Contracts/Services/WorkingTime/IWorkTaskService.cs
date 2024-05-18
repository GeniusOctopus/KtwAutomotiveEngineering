using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;

namespace KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime
{
    public interface IWorkTaskService
    {
        Task<WorkTaskDto> CreateWorkTaskForWorkDay(Guid workDayId, WorkTaskForCreationDto workTaskForCreation, bool trackChanges);
    }
}
