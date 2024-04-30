public class ProductController 
{
    private readonly ProductService _service;

    public ProductController() 
    {
        _service = new ProductService(); 
    }

    public async void Get(HttpContext context, int id) 
    {
        var product =_service.Get(id);
         
        await context.Response.WriteAsJsonAsync<Product>(product);
    }

    public async void Create(HttpContext context) 
    {
        var product = await context.Request.ReadFromJsonAsync<Product>();

        int? productId = _service.Create(product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice);

        if (productId == null)
        {
            context.Response.StatusCode = 500;
        }

        context.Response.StatusCode = 201;
        await context.Response.WriteAsync(productId.ToString());
    
        return;
    }

    public async void Update(HttpContext context, int id) 
    {
        var product = await context.Request.ReadFromJsonAsync<Product>();

        _service.Update(id, product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice);
    }

    public void Delete(int id) 
    {
        _service.Delete(id);
    }
}
