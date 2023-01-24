namespace bitfit.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float WeightInKg { get; set; }
        public float HeightInCm { get; set; }
        public float BMI { get; set; }

        public float CalculateBMI()
        {
            return WeightInKg / (HeightInCm * HeightInCm / 10000);
        }

        public User(int id, string name, string email, float weightInKg, float heightInCm)
        {
            Id = id;
            Name = name;
            Email = email;
            WeightInKg = weightInKg;
            HeightInCm = heightInCm;
            BMI = CalculateBMI();
        }
    }
}
