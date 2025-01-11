using KtwAutomotiveEngineering.Service.Contracts.Services.Identity;
using KtwAutomotiveEngineering.Service.Contracts.Services.WorkingTime;

namespace KtwAutomotiveEngineering.Service.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IWorkDayService WorkDayService { get; }
        IWorkTaskService WorkTaskService { get; }
        IWorkSliceService WorkSliceService { get; }
    }
}
