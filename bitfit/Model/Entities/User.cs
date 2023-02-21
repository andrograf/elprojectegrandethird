using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bitfit.Model.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid? Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public float WeightInKg { get; set; }
        public float HeightInCm { get; set; }
        public float BMI { get; set; }

        public float CalculateBMI()
        {
            return WeightInKg / (HeightInCm * HeightInCm / 10000);
        }

        public User(string name, string email, float weightInKg, float heightInCm)
        {
            Name = name;
            Email = email;
            WeightInKg = weightInKg;
            HeightInCm = heightInCm;
            BMI = CalculateBMI();
        }
    }
}
