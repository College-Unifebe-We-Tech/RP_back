using System.Data;
using System.Data.SqlClient;

public interface IRepositoryProductionItem<ProductionItem> 
{
    ProductionItem? Get(int id);
    ProductionItem? Create(int productionOrder, int productId, int quantity, bool waste);
    void Update(int id, int productionOrder, int productId, int quantity, bool waste);
    void Delete(int id);
}

public class ProductionItemRepository : IRepositoryProductionItem<ProductionItem> 
{
    private readonly SQLServerAdapter<ProductionItem> _sql;

    public ProductionItemRepository() 
    {
        _sql = new SQLServerAdapter<ProductionItem>(EnvironmentVariables.DBString);
    }

    public ProductionItem? Get(int id)
    {
        return _sql.Get<ProductionItem>("SELECT ProductionItemId, ProductionOrderId, ProductId, Quantity, Waste FROM ProductionItem WHERE ProductionItemId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public ProductionItem? Create(int productionOrderId, int productId, int quantity, bool waste) 
    {
        return _sql.Get<ProductionItem>("INSERT INTO ProductionItem (ProductionOrderId, ProductId, Quantity, Waste) OUTPUT inserted.ProductionItemId VALUES (@productionOrderId, @productId, @quantity, @waste)", [
            new SqlParameter("@productionOrderId", SqlDbType.Int) { Value = productionOrderId },
            new SqlParameter("@productId", SqlDbType.Int) { Value = productId },
            new SqlParameter("@quantity", SqlDbType.Int) { Value = quantity },
            new SqlParameter("@waste", SqlDbType.Bit) { Value = waste },
        ]);
    }

    public void Update(int id, int productionOrderId, int productId, int quantity, bool waste) 
    {
        _sql.Execute("UPDATE ProductionItem SET ProductionOrderId = @productionOrderId, ProductId = @productId, Quantity = @quantity, Waste = @waste WHERE ProductionItemId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@productionOrderId", SqlDbType.Int) { Value = productionOrderId },
            new SqlParameter("@productId", SqlDbType.Int) { Value = productId },
            new SqlParameter("@quantity", SqlDbType.Int) { Value = quantity },
            new SqlParameter("@waste", SqlDbType.Bit) { Value = waste },
        ]);
    }

    public void Delete(int id) 
    {
        _sql.Execute("DELETE FROM ProductionItem WHERE ProductionItemId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }
}
