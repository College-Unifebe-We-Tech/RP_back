using System.Data;
using System.Data.SqlClient;

public interface IRepositoryCategory<Category> 
{
    Task<List<Category>> List();
    Task<Category?> Get(int id);
    Task<Category?> Create(string name);
    Task<Category?> GetByName(string name);
    Task<int?> Update(int id, string name);
    Task<int?> Delete(int id);
}

public class CategoryRepository : IRepositoryCategory<Category> 
{
    private readonly SQLServerAdapter<Category> _sql;

    public CategoryRepository() 
    {
        _sql = new SQLServerAdapter<Category>(EnvironmentVariables.DBString);
    }

    public Task<List<Category>> List()
    {
        return _sql.List<Category>("SELECT CategoryId, CategoryName FROM Category");
    } 

    public Task<Category?> Get(int id)
    {
        return _sql.Get<Category>("SELECT CategoryId, CategoryName FROM Category WHERE CategoryId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);
    }

    public Task<Category?> Create(string name) 
    {
        return _sql.Get<Category>("INSERT INTO Category (CategoryName) OUTPUT inserted.CategoryId VALUES (@name)", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public Task<Category?> GetByName(string name) 
    {
        return _sql.Get<Category>("SELECT CategoryId, CategoryName FROM Category WHERE CategoryName = @name", [
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name },
        ]);
    }

    public async Task<int?> Update(int id, string name) 
    {
        var category = await  _sql.Get<Category>("UPDATE Category SET CategoryName = @name OUTPUT inserted.CategoryId WHERE CategoryId = @id" , [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name }
        ]);

        return category?.CategoryId;
    }

    public async Task<int?> Delete(int id) 
    {
        var category = await _sql.Get<Category>("DELETE FROM Category OUTPUT Deleted.CategoryId WHERE CategoryId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ]);

        return category?.CategoryId;
    }
}
