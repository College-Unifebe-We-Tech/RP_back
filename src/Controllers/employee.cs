using Microsoft.AspNetCore.Mvc;

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
            Employee? employee = _service.Get(id) ?? throw new Exception("does not exist");

            return Results.Json(employee, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }

    public IResult Create(Employee employee) 
    {
        try
        {
            int? employeeId = _service.Create(employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail) ?? throw new Exception("did not create");

            return Results.Json(employeeId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }


    public IResult Update(int id, Employee employee) 
    {
        try
        {
            _service.Update(id, employee.EmployeeName, employee.EmployeeAddress, employee.EmployeeEmail);

            return Results.Ok();
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }

    public IResult Delete(int id) 
    {
        try
        {
            _service.Delete(id);

            return Results.Ok();
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }
}

