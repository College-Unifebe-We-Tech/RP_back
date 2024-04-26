public class CategoryController 
{
    private readonly CategoryService _service;

    public CategoryController() 
    {
        _service = new CategoryService(); 
    }

    public async void Get(HttpContext context, int id) {
        var category =_service.Get(id);
         
        await context.Response.WriteAsJsonAsync<Category>(category);
    }

    public async void Create(HttpContext context) {
        var category = await context.Request.ReadFromJsonAsync<Category>();

        int? categoryId = _service.Create(category.CategoryName);

        if (categoryId != null) {
            context.Response.StatusCode = 201;
            await context.Response.WriteAsync(categoryId.ToString());
        
            return;
        }

        context.Response.StatusCode = 500;
    }

    public async void Update(HttpContext context, int id) {
        var category = await context.Request.ReadFromJsonAsync<Category>();

        _service.Update(id, category.CategoryName);
    }
    public void Delete(HttpContext context, int id) {
        _service.Delete(id);
    }
}
