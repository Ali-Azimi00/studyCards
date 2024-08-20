using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CardsAPI.Models
{
    public class SCards
    {
        [JsonPropertyName("cardId")]
        [Key]
        public Guid CardId { get; set; }

        [JsonPropertyName("question")]
        [Required(ErrorMessage ="A Question is Required")]
        public String Question { get; set; }

        [JsonPropertyName("answer")]
        public String Answer { get; set; }

        [JsonPropertyName("stat")]
        public String Stat { get; set; }
    }
}
