using AutoMapper;
using KtwAutomotiveEngineering.Contracts;
using KtwAutomotiveEngineering.Entities.Exceptions;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;
using KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime;
using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;
using Serilog;

namespace KtwAutomotiveEngineering.Service.Services.WorkingTime
{
    public class WorkSliceService(IRepositoryManager repository, ILogger logger, IMapper mapper) : IWorkSliceService
    {
        private readonly IRepositoryManager _repository = repository;
        private readonly ILogger _logger = logger;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<WorkSliceDto>> GetWorkSlicesAsync(Guid workTaskId, bool trackChanges)
        {
            var workTask = await _repository.WorkTask.GetWorkTaskAsync(workTaskId, trackChanges);
            if (workTask is null)
                throw new WorkDayNotFoundException(workTaskId);

            var workSlicesFromDb = await _repository.WorkSlice.GetWorkSlicesAsync(workTaskId, trackChanges);

            var workSlicesDto = _mapper.Map<IEnumerable<WorkSliceDto>>(workSlicesFromDb);
            return workSlicesDto;
        }

        public async Task<WorkSliceDto> CreateWorkSliceForWorkTask(Guid workTaskId, WorkSliceForCreationDto workSliceForCreation, bool trackChanges)
        {
            var workTask = await _repository.WorkTask.GetWorkTaskAsync(workTaskId, trackChanges);
            if (workTask is null)
                throw new WorkTaskNotFoundException(workTaskId);

            var workSliceEntity = _mapper.Map<WorkSlice>(workSliceForCreation);

            _repository.WorkSlice.CreateWorkSliceForWorkTask(workTaskId, workSliceEntity);
            await _repository.SaveAsync();

            var workSliceToReturn = _mapper.Map<WorkSliceDto>(workSliceEntity);
            return workSliceToReturn;
        }
    }
}
