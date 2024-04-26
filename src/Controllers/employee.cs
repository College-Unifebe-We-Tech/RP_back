public class EmployeeController 
{
    private readonly EmployeeService _service;

    public EmployeeController() 
    {
        _service = new EmployeeService(); 
    }

    public async void Get(HttpContext context, int id) {
        var employee =_service.Get(id);
         
        await context.Response.WriteAsJsonAsync<Employee>(employee);
    }

    public async void Create(HttpContext context) 
    {
        var employee = await context.Request.ReadFromJsonAsync<Employee>();

        int? employeeId = _service.Create(employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);

        if (employeeId != null) 
        {
            context.Response.StatusCode = 201;
            await context.Response.WriteAsync(employeeId.ToString());
        
            return;
        }

        context.Response.StatusCode = 500;
    }

    public async void Update(HttpContext context, int id) 
    {
        var employee = await context.Request.ReadFromJsonAsync<Employee>();

        _service.Update(id, employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);
    }
    public void Delete(HttpContext context, int id) 
    {
        _service.Delete(id);
    }
}
