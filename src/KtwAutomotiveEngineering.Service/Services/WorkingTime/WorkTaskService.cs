using AutoMapper;
using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Exceptions;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;
using KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime;
using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;
using Serilog;

namespace KtwAutomotiveEngineering.Service.Services.WorkingTime
{
    public class WorkTaskService(IRepositoryManager repository, ILogger logger, IMapper mapper) : IWorkTaskService
    {
        private readonly IRepositoryManager _repository = repository;
        private readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<WorkTaskDto> CreateWorkTaskForWorkDay(Guid workDayId, WorkTaskForCreationDto workTaskForCreation, bool trackChanges)
        {
            var workDay = await _repository.WorkDay.GetWorkDayAsync(workDayId, trackChanges);
            if (workDay is null)
                throw new WorkDayNotFoundException(workDayId);

            var workTaskEntity = _mapper.Map<WorkTask>(workTaskForCreation);

            _repository.WorkTask.CreateWorkTaskForWorkDay(workDayId, workTaskEntity);
            await _repository.SaveAsync();

            var workTaskToReturn = _mapper.Map<WorkTaskDto>(workTaskEntity);

            return workTaskToReturn;
        }
    }
}
