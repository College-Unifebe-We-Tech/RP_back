using System.Data;
using System.Data.SqlClient;

public interface IRepositorySupplier<Supplier> {
    Supplier? Get(int id);
    Supplier? Create(string name, string cnpj, string address, string email);
    Supplier? GetByName(string name);
    void Update(int id, string name, string cnpj, string address, string email);
    void Delete(int id);
}

public class SupplierRepository : IRepositorySupplier<Supplier> {
    private readonly SQLServerAdapter<Supplier> _sql;

    public SupplierRepository() {
        _sql = new SQLServerAdapter<Supplier>(EnvironmentVariables.DBString);
    }

    public Supplier? Get(int id)
    {
        return _sql.Get<Supplier>("SELECT SupplierId, SupplierName, SupplierCNPJ, SupplierAddress, SupplierEmail FROM Supplier WHERE SupplierId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Supplier? Create(string name, string cnpj, string address, string email) 
    {
        return _sql.Get<Supplier>("INSERT INTO Supplier (SupplierId, SupplierName, SupplierCNPJ, SupplierAddress, SupplierEmail) OUTPUT inserted.* VALUES (@name, @supplierId, @categoryId, @costPrice, @salePrice)", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj},
            new SqlParameter("@address", SqlDbType.VarChar) { Value = address},
            new SqlParameter("@email", SqlDbType.VarChar) { Value = email},
        ]);
    }

    public Supplier? GetByName(string name) 
    {
        return _sql.Get<Supplier>("SELECT SupplierId, SupplierName, SupplierCNPJ, SupplierAddress, SupplierEmail FROM Supplier WHERE SupplierName = @name", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public void Update(int id, string name, string cnpj, string address, string email) 
    {
        _sql.Execute("UPDATE Supplier SET SupplierName = @name, SupplierId = @supplierId, CategoryId = @categoryId, SupplierCostPrice = @costPrice, SupplierSalePrice = @salePrice WHERE SupplierId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj},
            new SqlParameter("@address", SqlDbType.VarChar) { Value = address},
            new SqlParameter("@email", SqlDbType.VarChar) { Value = email},
        ]);
    }

    public void Delete(int id) {
        _sql.Execute("DELETE FROM Supplier WHERE SupplierId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }
}
