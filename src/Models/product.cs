using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    
    [Required]
    public string ProductName { get; set; }
    
    [Required]
    [ForeignKey("Supplier")]
    public int SupplierId { get; set; }
    
    [Required]
    public Supplier Supplier { get; set; }

    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    
    public Category Category { get; set; }
    
    [Required]
    public decimal ProductCostPrice { get; set; }
    
    [Required]
    public decimal ProductSalePrice { get; set; }
}
