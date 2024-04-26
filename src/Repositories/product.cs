using System.Data;
using System.Data.SqlClient;

public interface IRepositoryProduct<Product> {
    Product? Get(int id);
    Product? Create(string name, int supplier, int category, decimal costPrice, decimal salePrice);
    Product? GetByName(string name);
    void Update(int id, string name, int supplier, int category, decimal costPrice, decimal salePrice);
    void Delete(int id);
}

public class ProductRepository : IRepositoryProduct<Product> {
    private readonly SQLServerAdapter<Product> _sql;

    public ProductRepository() {
        _sql = new SQLServerAdapter<Product>(EnvironmentVariables.DBString);
    }

    public Product? Get(int id)
    {
        return _sql.Get<Product>("SELECT ProductId, ProductName, SupplierId, CategoryId, ProductCostPrice, ProductSalePrice FROM Product WHERE ProductId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Product? Create(string name, int supplier, int category, decimal costPrice, decimal salePrice) 
    {
        return _sql.Get<Product>("INSERT INTO Product (ProductName, SupplierId, CategoryId, ProductCostPrice, ProductSalePrice) OUTPUT inserted.* VALUES (@name, @supplierId, @categoryId, @costPrice, @salePrice)", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@supplierId", SqlDbType.Int) { Value = supplier },
            new SqlParameter("@categoryId", SqlDbType.Int) { Value = category },
            new SqlParameter("@costPrice", SqlDbType.Decimal) { Value = costPrice },
            new SqlParameter("@salePrice", SqlDbType.Decimal) { Value = salePrice }
        ]);
    }

    public Product? GetByName(string name) 
    {
        return _sql.Get<Product>("SELECT ProductId, ProductName, SupplierId, CategoryId, ProductCostPrice, ProductSalePrice FROM Product WHERE ProductName = @name", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public void Update(int id, string name, int supplier, int category, decimal costPrice, decimal salePrice) 
    {
        _sql.Execute("UPDATE Product SET ProductName = @name, SupplierId = @supplierId, CategoryId = @categoryId, ProductCostPrice = @costPrice, ProductSalePrice = @salePrice WHERE ProductId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@supplierId", SqlDbType.Int) { Value = supplier },
            new SqlParameter("@categoryId", SqlDbType.Int) { Value = category },
            new SqlParameter("@costPrice", SqlDbType.Decimal) { Value = costPrice },
            new SqlParameter("@salePrice", SqlDbType.Decimal) { Value = salePrice }
        ]);
    }

    public void Delete(int id) {
        _sql.Execute("DELETE FROM Product WHERE ProductId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }
}
