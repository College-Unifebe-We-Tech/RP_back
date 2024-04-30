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
            Category? categoryId = _service.Get(id) ?? throw new Exception("does not exist");
            return Results.Json(categoryId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }

    public IResult Create(Category category) 
    {
        try
        {
            int? categoryId = _service.Create(category.CategoryName) ?? throw new Exception("did not create");
            
            return Results.Json(categoryId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }

    public IResult Update(int id, Category category) 
    {
        try 
        {
            _service.Update(id, category.CategoryName);

            return Results.Ok();
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }

    public IResult Delete(int id) 
    {
        try
        {
            _service.Delete(id);

            return Results.Ok();
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
        
    }
}