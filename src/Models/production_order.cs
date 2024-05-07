using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class ProductionOrder
{
    [Key]
    public int ProductionOrderId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string? ProductionOrderDescription { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "2000-01-01", "9999-12-31",
            ErrorMessage = "A {0} deve estar no intervalo entre {1} e {2}.")]
    public DateTime ProductionOrderExpectedStartDate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    [Range(typeof(DateTime), "2000-01-01", "9999-12-31",
            ErrorMessage = "A {0} deve estar no intervalo entre {1} e {2}.")]
    public DateTime ProductionOrderExpectedCompletionDate { get; set; }
    
    [Required]
    public int EmployeeId { get; set; }
    
    [ForeignKey("EmployeeId")]
    [JsonIgnore]
    public Employee? Employee { get; set; }
}
