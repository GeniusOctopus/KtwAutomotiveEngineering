namespace KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime
{
    public record WorkDayDto(Guid Id, DateTime? Start, DateTime? End, bool IsDone, IEnumerable<WorkTaskDto>? WorkTasks);
}
