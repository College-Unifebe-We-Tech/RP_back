public class EmployeeController 
{
    private readonly EmployeeService _service;

    public EmployeeController() 
    {
        _service = new EmployeeService(); 
    }

    public async Task<IResult> List()
    {
        List<Employee> employees = await _service.List();

        return Results.Json(employees, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Get(int id) 
    {
        Employee? employee = await _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(employee, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Create(Employee employee) 
    {    
        int? createdEmployeeId = await _service.Create(employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail) ?? throw new Exception("Can't create a null Employee"); 

        return Results.Json(createdEmployeeId, statusCode: StatusCodes.Status201Created); 
    }


    public async Task<IResult> Update(int id, Employee employee) 
    {
        await _service.Update(id, employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);

        return Results.NoContent();
    }

    public async Task<IResult> Delete(int id) 
    {
        await _service.Delete(id);

        return Results.NoContent();
    }
}

