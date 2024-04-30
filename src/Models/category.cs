using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Category
{
    [Key]
    [JsonIgnore]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(100)]
    public string? CategoryName { get; set; }
}
