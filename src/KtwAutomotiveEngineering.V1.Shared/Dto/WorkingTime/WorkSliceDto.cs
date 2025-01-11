namespace KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime
{
    public record WorkSliceDto(Guid WorkTaskId, Guid Id, DateTime? Start, DateTime? End);
}
