using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime;
using Serilog;

namespace KtwAutomotiveEngineering.Service.Services.WorkingTime
{
    public class WorkSliceService(IRepositoryManager repository, ILogger logger) : IWorkSliceService
    {
        private readonly IRepositoryManager _repository = repository;
        private readonly ILogger _logger = logger;
    }
}
