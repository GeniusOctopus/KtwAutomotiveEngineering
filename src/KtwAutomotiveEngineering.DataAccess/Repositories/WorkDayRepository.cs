using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;

namespace KtwAutomotiveEngineering.DataAccess.Repositories
{
    public class WorkDayRepository(RepositoryContext repositoryContext) :
        RepositoryBase<WorkDay>(repositoryContext), IWorkDayRepository
    {
    }
}
