public class EmployeeController 
{
    private readonly EmployeeService _service;

    public EmployeeController() 
    {
        _service = new EmployeeService(); 
    }

    public async void Get(int id) 
    {
        var employee =_service.Get(id);
         
        Results.Json(employee);
        Results.Ok();
    }

    public async void Create(Employee employee) 
    {
        int? employeeId = _service.Create(employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);

        if (employeeId != null) 
        {
            Results.Json(employee);
            Results.Ok();
            
            return;
        }

        Results.Problem();
    }

    public async void Update(int id, Employee employee) 
    {
        _service.Update(id, employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);
    }

    public void Delete(int id) 
    {
        _service.Delete(id);
    }
}

