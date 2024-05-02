public class EmployeeController 
{
    private readonly EmployeeService _service;

    public EmployeeController() 
    {
        _service = new EmployeeService(); 
    }

    public IResult Get(int id) 
    {
        Employee? employee = _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(employee, statusCode: StatusCodes.Status200OK);
    }

    public IResult Create(Employee employee) 
    {
        int? employeeId = _service.Create(employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail) ?? throw new Exception("did not create");

        return Results.Json(employeeId, statusCode: StatusCodes.Status200OK);
    }


    public IResult Update(int id, Employee employee) 
    {
        _service.Update(id, employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);

        return Results.Ok();
    }

    public IResult Delete(int id) 
    {
        _service.Delete(id);

        return Results.Ok();
    }
}

