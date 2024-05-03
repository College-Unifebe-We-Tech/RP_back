using System.Data;
using System.Data.SqlClient;

public interface IRepositorySupplier<Supplier> 
{
    Task<List<Supplier>> List();
    Task<Supplier?> Get(int id);
    Task<Supplier?> Create(string name, string cnpj, string address, string email);
    Task<Supplier?> GetByName(string name);
    Task<int?> Update(int id, string name, string cnpj, string address, string email);
    Task<int?> Delete(int id);
}

public class SupplierRepository : IRepositorySupplier<Supplier> 
{
    private readonly SQLServerAdapter<Supplier> _sql;

    public SupplierRepository() 
    {
        _sql = new SQLServerAdapter<Supplier>(EnvironmentVariables.DBString);
    }

    public Task<List<Supplier>> List()
    {
        return _sql.List<Supplier>("SELECT SupplierId, SupplierName, SupplierCNPJ, SupplierAddress, SupplierEmail FROM Supplier");
    } 

    public Task<Supplier?> Get(int id)
    {
        return _sql.Get<Supplier>("SELECT SupplierId, SupplierName, SupplierCNPJ, SupplierAddress, SupplierEmail FROM Supplier WHERE SupplierId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Task<Supplier?> Create(string name, string cnpj, string address, string email) 
    {
        return _sql.Get<Supplier>("INSERT INTO Supplier (SupplierName, SupplierCNPJ, SupplierAddress, SupplierEmail) OUTPUT inserted.SupplierId VALUES (@name, @cnpj, @address, @email)", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj},
            new SqlParameter("@address", SqlDbType.VarChar) { Value = address},
            new SqlParameter("@email", SqlDbType.VarChar) { Value = email},
        ]);
    }

    public Task<Supplier?> GetByName(string name) 
    {
        return _sql.Get<Supplier>("SELECT SupplierId, SupplierName, SupplierCNPJ, SupplierAddress, SupplierEmail FROM Supplier WHERE SupplierName = @name", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public async Task<int?> Update(int id, string name, string cnpj, string address, string email) 
    {
        var supplier = await _sql.Get<Supplier>("UPDATE Supplier SET SupplierName = @name, SupplierCNPJ = @cnpj, SupplierAddress = @address, SupplierEmail = @email OUTPUT inserted.SupplierId WHERE SupplierId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
            new SqlParameter("@cnpj", SqlDbType.VarChar) { Value = cnpj},
            new SqlParameter("@address", SqlDbType.VarChar) { Value = address},
            new SqlParameter("@email", SqlDbType.VarChar) { Value = email},
        ]);

        return supplier?.SupplierId;
    }

    public async Task<int?> Delete(int id) 
    {
        var supplier = await _sql.Get<Supplier>("DELETE FROM Supplier OUTPUT Deleted.SupplierId WHERE SupplierId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);

        return supplier?.SupplierId;
    }
}
