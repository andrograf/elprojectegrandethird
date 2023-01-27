using System.ComponentModel.DataAnnotations.Schema;

namespace bitfit.Model.Entities
{
    public class Exercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Length { get; set; }
    }
}