using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;

namespace KtwAutomotiveEngineering.DataAccess.Repositories
{
    public class WorkSliceRepository(RepositoryContext repositoryContext) :
        RepositoryBase<WorkSlice>(repositoryContext), IWorkSliceRepository
    {
    }
}
