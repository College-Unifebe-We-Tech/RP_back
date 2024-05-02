public class ProductController 
{
    private readonly ProductService _service;

    public ProductController() 
    {
        _service = new ProductService(); 
    }

    public IResult Get(int id) 
    {
        Product? productId = _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(productId, statusCode: StatusCodes.Status200OK);
    }

    public IResult Create(Product product) 
    {
        int? productId = _service.Create(product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice) ?? throw new Exception("did not create");

        return Results.Json(productId, statusCode: StatusCodes.Status200OK);
    }

    public IResult Update(int id, Product product) 
    {
        _service.Update(id, product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice);
    
        return Results.Ok();
    }

    public IResult Delete(int id) 
    {
        _service.Delete(id);

        return Results.Ok();
    }
}
