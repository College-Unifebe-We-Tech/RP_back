using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Product
{
    [Key]
    [JsonIgnore]
    public int ProductId { get; set; }
    
    [Required]
    public string? ProductName { get; set; }
    
    [Required]
    [ForeignKey("Supplier")]
    public int SupplierId { get; set; }
    
    [Required]
    [JsonIgnore]
    public Supplier? Supplier { get; set; }

    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }
    
    [Required]
    public decimal ProductCostPrice { get; set; }
    
    [Required]
    public decimal ProductSalePrice { get; set; }
}
