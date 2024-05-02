using System.Data;
using System.Data.SqlClient;

public interface IRepositoryProductionOrder<ProductionOrder> 
{
    Task<List<ProductionOrder>> List();
    Task<ProductionOrder?> Get(int id);
    Task<ProductionOrder?> Create(string description, DateTime expectedStartDate, DateTime expectedCompletionDate, int employeeId);
    Task<int?> Update(int id, string description, DateTime expectedStartDate, DateTime expectedCompletionDate, int employeeId);
    Task<int?> Delete(int id);
}

public class ProductionOrderRepository : IRepositoryProductionOrder<ProductionOrder> 
{
    private readonly SQLServerAdapter<ProductionOrder> _sql;

    public ProductionOrderRepository() 
    {
        _sql = new SQLServerAdapter<ProductionOrder>(EnvironmentVariables.DBString);
    }

    public Task<List<ProductionOrder>> List()
    {
        return _sql.List<ProductionOrder>("SELECT ProductionOrderId, ProductionOrderDescription, ProductionOrderExpectedStartDate, ProductionOrderExpectedCompletionDate, EmployeeId FROM ProductionOrder");
    }

    public Task<ProductionOrder?> Get(int id)
    {
        return _sql.Get<ProductionOrder>("SELECT ProductionOrderId, ProductionOrderDescription, ProductionOrderExpectedStartDate, ProductionOrderExpectedCompletionDate, EmployeeId FROM ProductionOrder WHERE ProductionOrderId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Task<ProductionOrder?> Create(string description, DateTime expectedStartDate, DateTime expectedCompletionDate, int employeeId) 
    {
        return _sql.Get<ProductionOrder>("INSERT INTO ProductionOrder (ProductionOrderDescription, ProductionOrderExpectedStartDate, ProductionOrderExpectedCompletionDate, EmployeeId) OUTPUT inserted.ProductionOrderId VALUES (@description, @expectedStartDate, @expectedCompletionDate, @employeeId)", [
            new SqlParameter("@description", SqlDbType.VarChar) { Value = description },
            new SqlParameter("@expectedStartDate", SqlDbType.Date) { Value = expectedStartDate },
            new SqlParameter("@expectedCompletionDate", SqlDbType.Date) { Value = expectedCompletionDate },
            new SqlParameter("@employeeId", SqlDbType.Int) { Value = employeeId }
        ]);
    }

    public async Task<int?> Update(int id, string description, DateTime expectedStartDate, DateTime expectedCompletionDate, int employeeId) 
    {
        var productionOrder = await _sql.Get<ProductionOrder>("UPDATE ProductionOrder SET ProductionOrderDescription = @description, ProductionOrderExpectedStartDate = @expectedStartDate, ProductionOrderExpectedCompletionDate = @expectedCompletionDate, EmployeeId = @employeeId OUTPUT inserted.ProductionOrderId WHERE ProductionOrderId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@description", SqlDbType.VarChar) { Value = description },
            new SqlParameter("@expectedStartDate", SqlDbType.Date) { Value = expectedStartDate },
            new SqlParameter("@expectedCompletionDate", SqlDbType.Date) { Value = expectedCompletionDate },
            new SqlParameter("@employeeId", SqlDbType.Int) { Value = employeeId },
        ]);

        return productionOrder?.ProductionOrderId;
    }

    public async Task<int?> Delete(int id) 
    {
        var productionOrder = await _sql.Get<ProductionOrder>("DELETE FROM ProductionOrder OUTPUT Deleted.ProductionOrderId WHERE ProductionOrderId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);

        return productionOrder?.ProductionOrderId;
    }
}
