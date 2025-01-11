namespace KtwAutomotiveEngineering.Entities.Models.WorkingTime
{
    public class WorkSlice : ModelBase
    {
        public Guid WorkTaskId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
