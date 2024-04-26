using System.ComponentModel.DataAnnotations;

public class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    [Required]
    public string? SupplierName { get; set; }

    public string? SupplierCNPJ { get; set; }

    public string? SupplierAddress { get; set; }
    
    public string? SupplierEmail { get; set; }
}
