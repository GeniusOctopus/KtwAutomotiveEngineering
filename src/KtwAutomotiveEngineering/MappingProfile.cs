using AutoMapper;
using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.Entities.Models.WorkingTime;
using KtwAutomotiveEngineering.V1.Shared.Dto.Identity;
using KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime;

namespace KtwAutomotiveEngineering
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, AppUser>();
            CreateMap<WorkDayForCreationDto, WorkDay>();
            CreateMap<WorkDay, WorkDayDto>();
            CreateMap<WorkTaskForCreationDto, WorkTask>();
            CreateMap<WorkTask, WorkTaskDto>();
            CreateMap<WorkSliceForCreationDto, WorkSlice>();
            CreateMap<WorkSlice, WorkSliceDto>();
        }
    }
}
