using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;

namespace KtwAutomotiveEngineering.DataAccess.Repositories
{
    public class WorkTaskRepository(RepositoryContext repositoryContext) :
        RepositoryBase<WorkTask>(repositoryContext), IWorkTaskRepository
    {
    }
}
