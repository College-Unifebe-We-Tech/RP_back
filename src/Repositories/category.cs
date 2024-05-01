using System.Data;
using System.Data.SqlClient;

public interface IRepositoryCategory<Category> 
{
    List<Category>? List();
    Category? Get(int id);
    Category? Create(string name);
    Category? GetByName(string name);
    int? Update(int id, string name);
    int? Delete(int id);
}

public class CategoryRepository : IRepositoryCategory<Category> 
{
    private readonly SQLServerAdapter<Category> _sql;

    public CategoryRepository() 
    {
        _sql = new SQLServerAdapter<Category>(EnvironmentVariables.DBString);
    }

    public List<Category>? List()
    {
        return _sql.List<Category>("SELECT CategoryId, CategoryName FROM Category");
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

    public int? Update(int id, string name) 
    {
        return _sql.Get<Category>("UPDATE Category SET CategoryName = @name OUTPUT inserted.CategoryId WHERE CategoryId = @id" , [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
            new SqlParameter("@name", SqlDbType.VarChar) { Value = name }
        ])?.CategoryId;
    }

    public int? Delete(int id) 
    {
        return _sql.Get<Category>("DELETE FROM Category OUTPUT Deleted.CategoryId WHERE CategoryId = @id", [
            new SqlParameter("@id", SqlDbType.Int) { Value = id },
        ])?.CategoryId;
    }
}
