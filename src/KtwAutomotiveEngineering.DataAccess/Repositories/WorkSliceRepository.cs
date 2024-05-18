using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;
using Microsoft.EntityFrameworkCore;

namespace KtwAutomotiveEngineering.DataAccess.Repositories
{
    public class WorkSliceRepository(RepositoryContext repositoryContext) :
        RepositoryBase<WorkSlice>(repositoryContext), IWorkSliceRepository
    {
        public async Task<IEnumerable<WorkSlice>> GetWorkSlicesAsync(Guid workTaskId, bool trackChanges) =>
            await FindByCondition(w => w.WorkTaskId.Equals(workTaskId), trackChanges)
            .OrderBy(w => w.Start).ToListAsync();

        public void CreateWorkSliceForWorkTask(Guid workTaskId, WorkSlice workSlice)
        {
            workSlice.WorkTaskId = workTaskId;
            Create(workSlice);
        }
    }
}
