using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bitfit.Model.Entities
{
    public class Food
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonPropertyName("sugar_g")]
        public double Sugar { get; set; }

        [JsonPropertyName("fiber_g")]
        public double Fiber { get; set; }

        [JsonPropertyName("serving_size_g")]
        public double ServingSize { get; set; }

        [JsonPropertyName("sodium_mg")]
        public double Sodium { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("potassium_mg")]
        public double Potassium { get; set; }

        [JsonPropertyName("fat_saturated_g")]
        public double FatSaturated { get; set; }

        [JsonPropertyName("fat_total_g")]
        public double FatTotal { get; set; }

        [JsonPropertyName("calories")]
        public double Calories { get; set; }

        [JsonPropertyName("cholesterol_mg")]
        public double Cholesterol { get; set; }

        [JsonPropertyName("protein_g")]
        public double Protein { get; set; }

        [JsonPropertyName("carbohydrates_total_g")]
        public double Carbohydrates { get; set; }

        public Food(double sugar_g, double fiber_g, double serving_size_g, double sodium_mg, string name, double potassium_mg, double fat_saturated_g, double calories, double cholesterol_mg, double protein_g, double carbohydrates_total_g)
        {
            Name = name;
            Sugar = sugar_g;
            Fiber = fiber_g;
            ServingSize = serving_size_g;
            Sodium = sodium_mg;
            FatSaturated = fat_saturated_g;
            Calories = calories;
            Cholesterol = cholesterol_mg;
            Protein = protein_g;
            Carbohydrates = carbohydrates_total_g;
        }
    }
}
