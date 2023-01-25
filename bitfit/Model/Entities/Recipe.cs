using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bitfit.Model.Entities
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("ingredients")]
        public string Ingredients { get; set; }
        [JsonPropertyName("servings")]
        public string Servings { get; set; }
        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }

        public Recipe(string name,string title, string ingredients, string servings, string instructions)
        {
            Name = name;
            Title = title;
            Ingredients = ingredients;
            Servings = servings;
            Instructions = instructions;
        }
    }
}
