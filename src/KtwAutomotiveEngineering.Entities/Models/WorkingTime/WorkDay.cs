namespace KtwAutomotiveEngineering.Entities.Models.WorkingTime
{
    public class WorkDay : ModelBase
    {
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool IsDone { get; set; }
        public List<WorkTask> WorkTasks { get; set; }
    }
}
