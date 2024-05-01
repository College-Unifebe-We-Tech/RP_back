using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

public class CategoryController 
{
    private readonly CategoryService _service;

    public CategoryController() 
    {
        _service = new CategoryService(); 
    }

    public async Task<IResult> List()
    {
        try
        {
            var categories = _service.List();
            return Results.Json(categories, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }

    public async Task<IResult> Get(int id) 
    {
        try
        {
            Category category = _service.Get(id);
            return Results.Json(category, statusCode: StatusCodes.Status200OK);
        }
        catch (ArgumentException exception)
        {
            return Results.BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }

    public async Task<IResult> Create(Category category) 
    {
        try
        {     
            int? createdCategoryId = _service.Create(category.CategoryName) ?? throw new Exception("Can't create a null category"); 

            return Results.Json(createdCategoryId, statusCode: StatusCodes.Status201Created); 
        }
        catch (ArgumentException exception)
        {
            return Results.BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }

    public async Task<IResult> Update(int id, Category category) 
    {
        try 
        {
            _service.Update(id, category.CategoryName);

            return Results.NoContent();
        }
        catch (ArgumentException exception)
        {
            return Results.BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }

    public async Task<IResult> Delete(int id) 
    {
        try
        {
            _service.Delete(id);

            return Results.NoContent();
        }
        catch (ArgumentException exception)
        {
            return Results.BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);
        }
    }
}