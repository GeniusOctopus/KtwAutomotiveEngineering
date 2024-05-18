using KtwAutomotiveEngineering.Entities.Models.WorkingTime;

namespace KtwAutomotiveEngineering.Contracts
{
    public interface IWorkTaskRepository
    {
        void CreateWorkTaskForWorkDay(Guid workDayId, WorkTask workTasks);
    }
}
