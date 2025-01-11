using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;
using Microsoft.EntityFrameworkCore;

namespace KtwAutomotiveEngineering.DataAccess.Repositories
{
    public class WorkTaskRepository(RepositoryContext repositoryContext) :
        RepositoryBase<WorkTask>(repositoryContext), IWorkTaskRepository
    {
        public async Task<WorkTask?> GetWorkTaskAsync(Guid workTaskId, bool trackChanges) =>
            await FindByCondition(w => w.Id.Equals(workTaskId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<IEnumerable<WorkTask>> GetWorkTasks(Guid workDayId, bool trackChanges) =>
            await FindByCondition(w => w.WorkDayId.Equals(workDayId), trackChanges)
            .OrderBy(w => w.Start).ToListAsync();

        public void CreateWorkTaskForWorkDay(Guid workDayId, WorkTask workTasks)
        {
            workTasks.WorkDayId = workDayId;
            Create(workTasks);
        }
    }
}
