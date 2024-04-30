using System.Data;
using System.Data.SqlClient;

public interface IRepositoryCategory<Category> 
{
    Category? Get(int id);
    Category? Create(string name);
    Category? GetByName(string name);
    void Update(int id, string name);
    void Delete(int id);
}

public class CategoryRepository : IRepositoryCategory<Category> 
{
    private readonly SQLServerAdapter<Category> _sql;

    public CategoryRepository() 
    {
        _sql = new SQLServerAdapter<Category>(EnvironmentVariables.DBString);
    }

    public Category? Get(int id)
    {
        return _sql.Get<Category>("SELECT CategoryId, CategoryName FROM Category WHERE CategoryId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Category? Create(string name) 
    {
        return _sql.Get<Category>("INSERT INTO Category (CategoryName) OUTPUT inserted.CategoryId VALUES (@name)", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public Category? GetByName(string name) 
    {
        return _sql.Get<Category>("SELECT CategoryId, CategoryName FROM Category WHERE CategoryName = @name", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public void Update(int id, string name) 
    {
        _sql.Execute("UPDATE Category SET CategoryName = @name WHERE CategoryId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name }
        ]);
    }

    public void Delete(int id) 
    {
        _sql.Execute("DELETE FROM Category WHERE CategoryId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }
}
