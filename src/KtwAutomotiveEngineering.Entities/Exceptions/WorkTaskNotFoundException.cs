namespace KtwAutomotiveEngineering.Entities.Exceptions
{
    public sealed class WorkTaskNotFoundException(Guid workTaskId)
        : NotFoundException($"The worktask with id: {workTaskId} doesn't exist in the database.")
    {
    }
}
