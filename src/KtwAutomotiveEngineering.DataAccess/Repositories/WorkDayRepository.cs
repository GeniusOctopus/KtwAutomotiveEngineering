using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;
using Microsoft.EntityFrameworkCore;

namespace KtwAutomotiveEngineering.DataAccess.Repositories
{
    public class WorkDayRepository(RepositoryContext repositoryContext) :
        RepositoryBase<WorkDay>(repositoryContext), IWorkDayRepository
    {
        public void CreateWorkDay(WorkDay workDay) => Create(workDay);

        public async Task<WorkDay?> GetWorkDayAsync(Guid workDayId, bool trackChanges) =>
            await FindByCondition(w => w.Id.Equals(workDayId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
