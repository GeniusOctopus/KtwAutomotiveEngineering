namespace KtwAutomotiveEngineering.Entities.Exceptions
{
    public sealed class WorkDayNotFoundException(Guid workDayId)
        : NotFoundException($"The workday with id: {workDayId} doesn't exist in the database.")
    {
    }
}
