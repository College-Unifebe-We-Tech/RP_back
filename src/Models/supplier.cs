using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Supplier
{
    [Key]
    [JsonIgnore]
    public int SupplierId { get; set; }

    [Required]
    public string? SupplierName { get; set; }

    public string? SupplierCNPJ { get; set; }

    public string? SupplierAddress { get; set; }
    
    public string? SupplierEmail { get; set; }
}
