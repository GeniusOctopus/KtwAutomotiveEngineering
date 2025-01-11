using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;

namespace KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime
{
    public interface IWorkSliceService
    {
        Task<IEnumerable<WorkSliceDto>> GetWorkSlicesAsync(Guid workTaskId, bool trackChanges);
        Task<WorkSliceDto> CreateWorkSliceForWorkTask(Guid workTaskId, WorkSliceForCreationDto workSlice, bool trackChanges);
    }
}
