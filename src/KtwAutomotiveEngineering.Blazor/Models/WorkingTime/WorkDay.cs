using System;
using System.Collections.Generic;

namespace KtwAutomotiveEngineering.Blazor.Models.WorkingTime
{
    internal class WorkDay
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsDone { get; set; }
        public List<WorkTask> WorkTasks { get; set; }

    }
}
