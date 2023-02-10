using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bitfit.Model.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        public float? WeightInKg { get; set; }
        public float? HeightInCm { get; set; }
        public float? BMI { get; set; }

        public float? CalculateBMI()
        {
            return WeightInKg / (HeightInCm * HeightInCm / 10000);
        }

        public User()
        {
        }

        public User(string name, string email, string password, float? weightInKg, float? heightInCm)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            WeightInKg = weightInKg;
            Password = password;
            HeightInCm = heightInCm;
            BMI = CalculateBMI();
        }
    }
}