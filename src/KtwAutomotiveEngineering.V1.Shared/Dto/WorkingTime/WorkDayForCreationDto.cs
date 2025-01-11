namespace KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime
{
    public record WorkDayForCreationDto(DateTime Start, IEnumerable<WorkTaskForCreationDto>? WorkTasks);
}
