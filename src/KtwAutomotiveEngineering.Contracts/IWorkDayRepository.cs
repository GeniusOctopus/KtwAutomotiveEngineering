using KtwAutomotiveEngineering.Entities.Models.WorkingTime;

namespace KtwAutomotiveEngineering.Contracts
{
    public interface IWorkDayRepository
    {
        Task<WorkDay?> GetWorkDayAsync(Guid workDayId, bool trackChanges);
        void CreateWorkDay(WorkDay workDay);
    }
}
