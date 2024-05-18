using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;

namespace KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime
{
    public interface IWorkDayService
    {
        Task<WorkDayDto> GetWorkDayAsync(Guid workDayId, bool trackChanges);
        Task<WorkDayDto> CreateWorkDayAsync(WorkDayForCreationDto workDay);
    }
}
