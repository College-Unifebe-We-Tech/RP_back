using System.Data;
using System.Data.SqlClient;

public interface IRepositoryProduct<Product> 
{
    Task<List<Product>> List();
    Task<Product?> Get(int id);
    Task<Product?> Create(string name, int supplier, int category, decimal costPrice, decimal salePrice);
    Task<Product?> GetByName(string name);
    Task<int?> Update(int id, string name, int supplier, int category, decimal costPrice, decimal salePrice);
    Task<int?> Delete(int id);
}

public class ProductRepository : IRepositoryProduct<Product> 
{
    private readonly SQLServerAdapter<Product> _sql;

    public ProductRepository() 
    {
        _sql = new SQLServerAdapter<Product>(EnvironmentVariables.DBString);
    }

    public Task<List<Product>> List()
    {
        return _sql.List<Product>("SELECT ProductId, ProductName, SupplierId, CategoryId, ProductCostPrice, ProductSalePrice FROM Product");
    } 

    public Task<Product?> Get(int id)
    {
        return _sql.Get<Product>("SELECT ProductId, ProductName, SupplierId, CategoryId, ProductCostPrice, ProductSalePrice FROM Product WHERE ProductId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Task<Product?> Create(string name, int supplier, int category, decimal costPrice, decimal salePrice) 
    {
        return _sql.Get<Product>("INSERT INTO Product (ProductName, SupplierId, CategoryId, ProductCostPrice, ProductSalePrice) OUTPUT inserted.ProductId VALUES (@name, @supplierId, @categoryId, @costPrice, @salePrice)", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@supplierId", SqlDbType.Int) { Value = supplier },
            new SqlParameter("@categoryId", SqlDbType.Int) { Value = category },
            new SqlParameter("@costPrice", SqlDbType.Decimal) { Value = costPrice },
            new SqlParameter("@salePrice", SqlDbType.Decimal) { Value = salePrice }
        ]);
    }

    public Task<Product?> GetByName(string name) 
    {
        return _sql.Get<Product>("SELECT ProductId, ProductName, SupplierId, CategoryId, ProductCostPrice, ProductSalePrice FROM Product WHERE ProductName = @name", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public async Task<int?> Update(int id, string name, int supplier, int category, decimal costPrice, decimal salePrice) 
    {
        var product = await _sql.Get<Product>("UPDATE Product SET ProductName = @name, SupplierId = @supplierId, CategoryId = @categoryId, ProductCostPrice = @costPrice, ProductSalePrice = @salePrice OUTPUT inserted.ProductId  WHERE ProductId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@supplierId", SqlDbType.Int) { Value = supplier },
            new SqlParameter("@categoryId", SqlDbType.Int) { Value = category },
            new SqlParameter("@costPrice", SqlDbType.Decimal) { Value = costPrice },
            new SqlParameter("@salePrice", SqlDbType.Decimal) { Value = salePrice }
        ]);

        return product?.ProductId;
    }

    public async Task<int?> Delete(int id) 
    {
        var product = await _sql.Get<Product>("DELETE FROM Product OUTPUT Deleted.ProductId WHERE ProductId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);

        return product?.ProductId;
    }
}
