namespace KtwAutomotiveEngineering.Contracts
{
    public interface IRepositoryManager
    {
        void Save();
        Task SaveAsync();
    }
}
