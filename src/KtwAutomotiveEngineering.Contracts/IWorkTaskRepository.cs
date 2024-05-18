using KtwAutomotiveEngineering.Entities.Models.WorkingTime;

namespace KtwAutomotiveEngineering.Contracts
{
    public interface IWorkTaskRepository
    {
        Task<IEnumerable<WorkTask>> GetWorkTasks(Guid workDayId, bool trackChanges);
        void CreateWorkTaskForWorkDay(Guid workDayId, WorkTask workTasks);
    }
}
