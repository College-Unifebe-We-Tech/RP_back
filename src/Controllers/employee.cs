public class EmployeeController 
{
    private readonly EmployeeService _service;

    public EmployeeController() 
    {
        _service = new EmployeeService(); 
    }

    public IResult Get(int id) 
    {
        try
        {
            Employee employeeId = _service.Get(id);
            return Results.Json(employeeId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public IResult Create(Employee employee) 
    {
        try
        {
            int? employeeId = _service.Create(employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);
            return Results.Json(employeeId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }


    public void Update(int id, Employee employee) 
    {
        try
        {
            _service.Update(id, employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);
        }
        catch(Exception)
        {
            Results.Problem();
        }
    }

    public void Delete(int id) 
    {
        try
        {
            _service.Delete(id);
        }
        catch(Exception)
        {
            Results.Problem();
        }
    }
}

