using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime;
using Serilog;

namespace KtwAutomotiveEngineering.Service.Services.WorkingTime
{
    public class WorkDayService(IRepositoryManager repository, ILogger logger) : IWorkDayService
    {
        private readonly IRepositoryManager _repository = repository;
        private readonly ILogger _logger = logger;
    }
}
