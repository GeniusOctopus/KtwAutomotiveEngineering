using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.DataAccess.Repositories;

namespace KtwAutomotiveEngineering.DataAccess
{
    public class RepositoryManager(RepositoryContext repositoryContext) : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext = repositoryContext;
        private readonly Lazy<IWorkDayRepository> _workDayRepository = new(() => new WorkDayRepository(repositoryContext));
        private readonly Lazy<IWorkTaskRepository> _workTaskRepository = new(() => new WorkTaskRepository(repositoryContext));
        private readonly Lazy<IWorkSliceRepository> _workSliceRepository = new(() => new WorkSliceRepository(repositoryContext));

        public IWorkDayRepository WorkDay => _workDayRepository.Value;
        public IWorkTaskRepository WorkTask => _workTaskRepository.Value;
        public IWorkSliceRepository WorkSlice => _workSliceRepository.Value;

        public void Save() => _repositoryContext.SaveChanges();
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
