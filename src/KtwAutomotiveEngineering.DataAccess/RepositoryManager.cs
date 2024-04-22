using KtwAutomotiveEngineering.Contracts;

namespace KtwAutomotiveEngineering.DataAccess
{
    public class RepositoryManager(RepositoryContext repositoryContext) : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext = repositoryContext;

        public void Save() => _repositoryContext.SaveChanges();
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
