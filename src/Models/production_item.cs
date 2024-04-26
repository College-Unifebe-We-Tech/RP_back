using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductionItem
{
    [Key]
    public int ProductionItemId { get; set; }

    [Required]
    [ForeignKey("ProductionOrder")]
    public int ProductionOrderId { get; set; }

    [Required]
    public ProductionOrder? ProductionOrder { get; set; }
    
    [Required]
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    
    [Required]
    public Product? Product { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    public bool Waste { get; set; } = false; // Default value is 0
}
