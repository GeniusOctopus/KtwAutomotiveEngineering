using KtwAutomotiveEngineering.Entities.Models.WorkingTime;

namespace KtwAutomotiveEngineering.Contracts
{
    public interface IWorkSliceRepository
    {
        Task<IEnumerable<WorkSlice>> GetWorkSlicesAsync(Guid workTaskId, bool trackChanges);
        void CreateWorkSliceForWorkTask(Guid workTaskId, WorkSlice workSlice);
    }
}
