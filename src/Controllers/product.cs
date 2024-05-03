public class ProductController 
{
    private readonly ProductService _service;

    public ProductController() 
    {
        _service = new ProductService(); 
    }

    public async Task<IResult> List()
    {
        List<Product> products = await _service.List();

        return Results.Json(products, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Get(int id) 
    {
        Product? productId = await _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(productId, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Create(Product product) 
    {
        int? productId = await _service.Create(product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice) ?? throw new Exception("did not create");

        return Results.Json(productId, statusCode: StatusCodes.Status201Created);
    }

    public async Task<IResult> Update(int id, Product product) 
    {
        await _service.Update(id, product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice);
    
        return Results.NoContent();
    }

    public async Task<IResult> Delete(int id) 
    {
        await _service.Delete(id);

        return Results.NoContent();
    }
}
