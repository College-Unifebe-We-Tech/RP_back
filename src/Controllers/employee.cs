public class EmployeeController 
{
    private readonly EmployeeService _service;

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
        int? employeeId = await _service.Create(employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail) ?? throw new Exception("did not create");

        return Results.Json(employeeId, statusCode: StatusCodes.Status200OK);
    }


    public async Task<IResult> Update(int id, Employee employee) 
    {
        await _service.Update(id, employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);

        return Results.Ok();
    }

    public async Task<IResult> Delete(int id) 
    {
        await _service.Delete(id);

        return Results.Ok();
    }
}

