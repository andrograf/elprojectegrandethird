using System.ComponentModel.DataAnnotations.Schema;

namespace bitfit.Model.Entities
{
    public class Gantt
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
