using AutoMapper;
using KtwAutomotiveEngineering.Entities.Models.Identity;
using KtwAutomotiveEngineering.V1.Shared.Dto.Identity;

namespace KtwAutomotiveEngineering
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, AppUser>()
                .ForMember(x => x.FirstName, _ => _.MapFrom(_ => _.FirstName))
                .ForMember(x => x.LastName, _ => _.MapFrom(_ => _.LastName))
                .ForMember(x => x.UserName, _ => _.MapFrom(_ => _.UserName))
                .ForMember(x => x.Email, _ => _.MapFrom(_ => _.Email));
        }
    }
}
