using AutoMapper;
using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Exceptions;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;
using KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime;
using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;
using Serilog;

namespace KtwAutomotiveEngineering.Service.Services.WorkingTime
{
    public class WorkDayService(IRepositoryManager repository, ILogger logger, IMapper mapper) : IWorkDayService
    {
        private readonly IRepositoryManager _repository = repository;
        private readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<WorkDayDto> GetWorkDayAsync(Guid workDayId, bool trackChanges)
        {
            var workDay = await _repository.WorkDay.GetWorkDayAsync(workDayId, trackChanges);
            if (workDay is null)
                throw new WorkDayNotFoundException(workDayId);

            var workDayDto = _mapper.Map<WorkDayDto>(workDay);
            return workDayDto;
        }

        public async Task<WorkDayDto> CreateWorkDayAsync(WorkDayForCreationDto workDay)
        {
            var workDayEntity = _mapper.Map<WorkDay>(workDay);

            _repository.WorkDay.CreateWorkDay(workDayEntity);
            await _repository.SaveAsync();

            var workDayToReturn = _mapper.Map<WorkDayDto>(workDayEntity);

            return workDayToReturn;
        }
    }
}
