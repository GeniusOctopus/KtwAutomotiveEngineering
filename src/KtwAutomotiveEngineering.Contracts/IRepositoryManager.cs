namespace KtwAutomotiveEngineering.Contracts
{
    public interface IRepositoryManager
    {
        IWorkDayRepository WorkDay {  get; }
        IWorkTaskRepository WorkTask { get; }
        IWorkSliceRepository WorkSlice { get; }
        void Save();
        Task SaveAsync();
    }
}
