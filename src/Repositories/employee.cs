using System.Data;
using System.Data.SqlClient;

public interface IRepositoryEmployee<Employee> 
{
    Task<List<Employee>> List();
    Task<Employee?> Get(int id);
    Task<Employee?> Create(string name, string address, string email);
    Task<Employee?> GetByName(string name);
    Task<int?> Update(int id, string name, string address, string email);
    Task<int?> Delete(int id);
}

public class EmployeeRepository : IRepositoryEmployee<Employee> 
{
    private readonly SQLServerAdapter<Employee> _sql;

    public EmployeeRepository() 
    {
        _sql = new SQLServerAdapter<Employee>(EnvironmentVariables.DBString);
    }

    public Task<List<Employee>> List()
    {
        return _sql.List<Employee>("SELECT EmployeeId, EmployeeName, EmployeeAddress, EmployeeEmail FROM Employee");
    } 

    public Task<Employee?> Get(int id)
    {
        return _sql.Get<Employee>("SELECT EmployeeId, EmployeeName, EmployeeAddress, EmployeeEmail FROM Employee WHERE EmployeeId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Task<Employee?> Create(string name, string address, string email) 
    {
        return _sql.Get<Employee>("INSERT INTO Employee (EmployeeName, EmployeeAddress, EmployeeEmail) OUTPUT inserted.EmployeeId VALUES (@name, @address, @email)", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@address", SqlDbType.VarChar) { Value = address },
            new SqlParameter("@email", SqlDbType.VarChar) { Value = email }
        ]);
    }

    public Task<Employee?> GetByName(string name) 
    {
        return _sql.Get<Employee>("SELECT EmployeeId EmployeeName FROM Employee WHERE EmployeeName = @name", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }
    
    public async Task<int?> Update(int id, string name, string address, string email) 
    {
        var employee = await _sql.Get<Employee>("UPDATE Employee SET EmployeeName = @name, EmployeeAddress = @address, EmployeeEmail OUTPUT inserted.EmployeeId = @email WHERE EmployeeId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@address", SqlDbType.VarChar) { Value = address },
            new SqlParameter("@email", SqlDbType.VarChar) { Value = email }
        ]);

        return employee?.EmployeeId;
    }


    public async Task<int?> Delete(int id) 
    {
        var employee = await _sql.Get<Employee>("DELETE FROM Employee OUTPUT Deleted.EmployeeId WHERE EmployeeId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);

        return employee?.EmployeeId;
    }
}
