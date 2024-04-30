public class CategoryController 
{
    private readonly CategoryService _service;

    public CategoryController() 
    {
        _service = new CategoryService(); 
    }

    public void Get(int id) 
    {
        var category =_service.Get(id);
         
        Results.Json(category);
        Results.Ok();
    }

    public void Create(Category category) 
    {
        int? employeeId = _service.Create(category.CategoryName);

        if (employeeId != null) 
        {
            Results.Json(employeeId);
            Results.Ok();
            
            return;
        }

        Results.Problem();
    }

    public void Update(int id, Category category) 
    {
        _service.Update(id, category.CategoryName);
    }

    public void Delete(int id) 
    {
        _service.Delete(id);
    }
}
