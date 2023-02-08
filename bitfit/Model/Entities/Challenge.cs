using System.ComponentModel.DataAnnotations.Schema;

namespace bitfit.Model.Entities
{
    public class Challenge
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public User User { get; set; }
        public string Gantt { get; set; }
    }
}
