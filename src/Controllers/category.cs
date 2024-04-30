using System.Linq.Expressions;

public class CategoryController 
{
    private readonly CategoryService _service;

    public CategoryController() 
    {
        _service = new CategoryService(); 
    }

    public IResult Get(int id) 
    {
        try
        {
            Category categoryId = _service.Get(id);
            return Results.Json(categoryId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public IResult Create(Category category) 
    {
        try
        {
            int? categoryId = _service.Create(category.CategoryName);
            return Results.Json(categoryId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public void Update(int id, Category category) 
    {
        try 
        {
            _service.Update(id, category.CategoryName);
        }
        catch (Exception)
        {
            Results.Problem();
        }
    }

    public void Delete(int id) 
    {
        try
        {
            _service.Delete(id);
        }
        catch (Exception)
        {
            Results.Problem();
        }
        
    }
}