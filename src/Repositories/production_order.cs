using System.Data;
using System.Data.SqlClient;

public interface IRepositoryProductionOrder<ProductionOrder> 
{
    ProductionOrder? Get(int id);
    ProductionOrder? Create(string description, DateOnly expectedStartDate, DateOnly expectedCompletionDate, int employeeId);
    void Update(int id, string description, DateOnly expectedStartDate, DateOnly expectedCompletionDate, int employeeId);
    void Delete(int id);
}

public class ProductionOrderRepository : IRepositoryProductionOrder<ProductionOrder> 
{
    private readonly SQLServerAdapter<ProductionOrder> _sql;

    public ProductionOrderRepository() 
    {
        _sql = new SQLServerAdapter<ProductionOrder>(EnvironmentVariables.DBString);
    }

    public ProductionOrder? Get(int id)
    {
        return _sql.Get<ProductionOrder>("SELECT ProductionOrderDescription, ProductionOrderExpectedStartDate, ProductionOrderExpectedCompletionDate, EmployeeId FROM ProductionOrder WHERE ProductionOrderId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public ProductionOrder? Create(string description, DateOnly expectedStartDate, DateOnly expectedCompletionDate, int employeeId) 
    {
        return _sql.Get<ProductionOrder>("INSERT INTO ProductionOrder (ProductionOrderDescription, ProductionOrderExpectedStartDate, ProductionOrderExpectedCompletionDate, EmployeeId) OUTPUT inserted.ProductionOrderId VALUES (@description, @expectedStartDate, @expectedCompletionDate, @employeeId)", [
            new SqlParameter("@description", SqlDbType.VarChar) { Value = description },
            new SqlParameter("@expectedStartDate", SqlDbType.Date) { Value = expectedStartDate },
            new SqlParameter("@expectedCompletionDate", SqlDbType.Date) { Value = expectedCompletionDate },
            new SqlParameter("@employeeId", SqlDbType.Int) { Value = employeeId }
        ]);
    }

    public void Update(int id, string description, DateOnly expectedStartDate, DateOnly expectedCompletionDate, int employeeId) 
    {
        _sql.Get<ProductionOrder>("INSERT INTO ProductionOrder (ProductionOrderDescription, ProductionOrderExpectedStartDate, ProductionOrderExpectedCompletionDate, EmployeeId) OUTPUT inserted.ProductionOrderId VALUES (@description, @expectedStartDate, @expectedCompletionDate, @employeeId)", [
            new SqlParameter("@description", SqlDbType.VarChar) { Value = description },
            new SqlParameter("@expectedStartDate", SqlDbType.Date) { Value = expectedStartDate },
            new SqlParameter("@expectedCompletionDate", SqlDbType.Date) { Value = expectedCompletionDate },
            new SqlParameter("@employeeId", SqlDbType.Int) { Value = employeeId }
        ]);
    }

    public void Delete(int id) 
    {
        _sql.Execute("DELETE FROM ProductionOrder WHERE ProductionOrderId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }
}
