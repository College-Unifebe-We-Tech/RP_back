using System.Data;
using System.Data.SqlClient;

public interface IRepositoryProductionItem<ProductionItem> 
{
    Task<List<ProductionItem>> List();
    Task<ProductionItem?> Get(int id);
    Task<ProductionItem?> Create(int productionOrder, int productId, int quantity, bool waste);
    Task<int?> Update(int id, int productionOrder, int productId, int quantity, bool waste);
    Task<int?> Delete(int id);
}

public class ProductionItemRepository : IRepositoryProductionItem<ProductionItem> 
{
    private readonly SQLServerAdapter<ProductionItem> _sql;

    public ProductionItemRepository() 
    {
        _sql = new SQLServerAdapter<ProductionItem>(EnvironmentVariables.DBString);
    }

    public Task<List<ProductionItem>> List()
    {
        return _sql.List<ProductionItem>("SELECT ProductionItemId, ProductionOrderId, ProductId, Quantity, Waste FROM ProductionItem");
    } 

    public Task<ProductionItem?> Get(int id)
    {
        return _sql.Get<ProductionItem>("SELECT ProductionItemId, ProductionOrderId, ProductId, Quantity, Waste FROM ProductionItem WHERE ProductionItemId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Task<ProductionItem?> Create(int productionOrderId, int productId, int quantity, bool waste) 
    {
        return _sql.Get<ProductionItem>("INSERT INTO ProductionItem (ProductionOrderId, ProductId, Quantity, Waste) OUTPUT inserted.ProductionItemId VALUES (@productionOrderId, @productId, @quantity, @waste)", [
            new SqlParameter("@productionOrderId", SqlDbType.Int) { Value = productionOrderId },
            new SqlParameter("@productId", SqlDbType.Int) { Value = productId },
            new SqlParameter("@quantity", SqlDbType.Int) { Value = quantity },
            new SqlParameter("@waste", SqlDbType.Bit) { Value = waste },
        ]);
    }

    public async Task<int?> Update(int id, int productionOrderId, int productId, int quantity, bool waste) 
    {
        var productionItem = await _sql.Get<ProductionItem>("UPDATE ProductionItem SET ProductionOrderId = @productionOrderId, ProductId = @productId, Quantity = @quantity, Waste = @waste OUTPUT inserted.ProductionItemId WHERE ProductionItemId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@productionOrderId", SqlDbType.Int) { Value = productionOrderId },
            new SqlParameter("@productId", SqlDbType.Int) { Value = productId },
            new SqlParameter("@quantity", SqlDbType.Int) { Value = quantity },
            new SqlParameter("@waste", SqlDbType.Bit) { Value = waste },
        ]);

        return productionItem?.ProductionItemId;
    }

    public async Task<int?> Delete(int id) 
    {
        var productionItem = await _sql.Get<ProductionItem>("DELETE FROM ProductionItem OUTPUT Deleted.ProductionItemId WHERE ProductionItemId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);

        return productionItem?.ProductionItemId;
    }
}
