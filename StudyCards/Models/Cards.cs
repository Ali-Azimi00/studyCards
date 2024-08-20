using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudyCards.Models
{
    public class Cards
    {
        [JsonPropertyName("cardId")]
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("question")]
        public String Question { get; set; }

        [JsonPropertyName("answer")]
        public String Answer { get; set; }

        [JsonPropertyName("stat")]
        public String Stat { get; set; }
    }
}
