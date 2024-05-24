using System;

namespace KtwAutomotiveEngineering.Blazor.Models.WorkingTime
{
    internal class WorkSlice
    {
        public Guid? Id { get; set; }
        public Guid WorkTaskId { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
    }
}
