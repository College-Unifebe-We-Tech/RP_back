using System.Data;
using System.Data.SqlClient;

public interface IRepositoryEmployee<Employee> 
{
    Employee? Get(int id);
    Employee? Create(string name, string address, string email);
    Employee? GetByName(string name);
    void Update(int id, string name, string address, string email);
    void Delete(int id);
}

public class EmployeeRepository : IRepositoryEmployee<Employee> 
{
    private readonly SQLServerAdapter<Employee> _sql;

    public EmployeeRepository() 
    {
        _sql = new SQLServerAdapter<Employee>(EnvironmentVariables.DBString);
    }

    public Employee? Get(int id)
    {
        return _sql.Get<Employee>("SELECT EmployeeId, EmployeeName, EmployeeAddress, EmployeeEmail FROM Employee WHERE EmployeeId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Employee? Create(string name, string address, string email) 
    {
        return _sql.Get<Employee>("INSERT INTO Employee (EmployeeName, EmployeeAddress, EmployeeEmail) OUTPUT inserted.* VALUES (@name, @address, @email)", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@address", SqlDbType.VarChar) { Value = address },
            new SqlParameter("@email", SqlDbType.VarChar) { Value = email }
        ]);
    }

    public Employee? GetByName(string name) 
    {
        return _sql.Get<Employee>("SELECT EmployeeId EmployeeName FROM Employee WHERE EmployeeName = @name", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public void Update(int id, string name, string address, string email) 
    {
        _sql.Execute("UPDATE Employee SET EmployeeName = @name, EmployeeAddress = @address, EmployeeEmail = @email WHERE EmployeeId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@address", SqlDbType.VarChar) { Value = address },
            new SqlParameter("@email", SqlDbType.VarChar) { Value = email }
        ]);
    }


    public void Delete(int id) 
    {
        _sql.Execute("DELETE FROM Employee WHERE EmployeeId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }
}
