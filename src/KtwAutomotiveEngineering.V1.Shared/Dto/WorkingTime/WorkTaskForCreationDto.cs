namespace KtwAutomotiveEngineering.V1.Shared.Dto.WorkingTime
{
    public record WorkTaskForCreationDto(DateTime Start, string? Description, string? Customer, bool IsPause, IEnumerable<WorkSliceForCreationDto>? WorkSlices);
}
