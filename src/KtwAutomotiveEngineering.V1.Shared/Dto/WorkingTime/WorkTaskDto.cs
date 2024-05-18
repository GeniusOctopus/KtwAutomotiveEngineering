namespace KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime
{
    public record WorkTaskDto(Guid WorkDayId, Guid Id, DateTime? Start, DateTime? End, string? Description, string? Customer, bool IsPause, IEnumerable<WorkSliceDto>? WorkSlices);
}