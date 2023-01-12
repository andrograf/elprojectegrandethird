using System.Text.Json.Serialization;

namespace BitFit.Models
{
    public class Recipe
    {
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
