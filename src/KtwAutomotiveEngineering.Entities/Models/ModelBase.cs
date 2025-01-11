using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KtwAutomotiveEngineering.Entities.Models
{
    public abstract class ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? CreatedUser { get; set; }
        public DateTime? Created { get; set; }
        public string? EditedUser { get; set; }
        public DateTime? Edited { get; set; }
        public string? DeletedUser { get; set; }
        public DateTime? Deleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
