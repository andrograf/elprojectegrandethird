using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bitfit.Model.Entities
{
    public class Recipe
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("ingredients")]
        public string Ingredients { get; set; }
        [JsonPropertyName("servings")]
        public string Servings { get; set; }
        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }

        public Recipe(string title, string ingredients, string servings, string instructions)
        {
            Title = title;
            Ingredients = ingredients;
            Servings = servings;
            Instructions = instructions;
        }
    }
}
