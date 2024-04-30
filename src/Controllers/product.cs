public class ProductController 
{
    private readonly ProductService _service;

    public ProductController() 
    {
        _service = new ProductService(); 
    }

    public IResult Get(int id) 
    {
        try
        {
            Product productId = _service.Get(id);
            return Results.Json(productId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public IResult Create(Product product) 
    {
        try
        {
            int? productId = _service.Create(product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice);
            return Results.Json(productId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public void Update(int id, Product product) 
    {
        try
        {
            _service.Update(id, product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice);
        }
        catch(Exception)
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
        catch(Exception)
        {
            Results.Problem();
        }
    }
}
