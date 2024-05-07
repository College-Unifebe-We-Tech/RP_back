using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    public string? EmployeeName { get; set; }

    public string? EmployeeAddress {get; set;}
    
    public string? EmployeeEmail {get; set;}
}