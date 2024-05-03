public class CategoryController 
{
    private readonly CategoryService _service;

    public CategoryController() 
    {
        _service = new CategoryService(); 
    }

    public async Task<IResult> List()
    {
        List<Category> categories = await _service.List();

        return Results.Json(categories, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Get(int id) 
    {
        Category category = await _service.Get(id);

        return Results.Json(category, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Create(Category category) 
    {    
        int? createdCategoryId = await _service.Create(category.CategoryName) ?? throw new Exception("Can't create a null category"); 

        return Results.Json(createdCategoryId, statusCode: StatusCodes.Status201Created); 
    }

    public async Task<IResult> Update(int id, Category category) 
    {
        await _service.Update(id, category.CategoryName);

        return Results.NoContent();
    }

    public async Task<IResult> Delete(int id) 
    {
        await _service.Delete(id);

        return Results.NoContent();
    }
}