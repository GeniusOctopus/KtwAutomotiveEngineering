namespace KtwAutomotiveEngineering.Entities.Models.WorkingTime
{
    public class WorkTask : ModelBase
    {
        public Guid WorkDayId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string? Description { get; set; }
        public string? Customer { get; set; }
        public bool IsPause { get; set; }
        public List<WorkSlice> WorkSlices { get; set; }
    }
}
