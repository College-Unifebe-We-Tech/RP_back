public class ProductController 
{
    private readonly ProductService _service;

    public ProductController() 
    {
        _service = new ProductService(); 
    }

    public void Get(int id) 
    {
        var product =_service.Get(id);
         
        Results.Json(product);
        Results.Ok();
    }

    public void Create(Product product) 
    {
        int? productId = _service.Create(product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice);

        if (productId != null) 
        {
            Results.Json(productId);
            Results.Ok();
            
            return;
        }

        Results.Problem();
    }

    public void Update(int id, Product product) 
    {
        _service.Update(id, product.ProductName, product.SupplierId, product.CategoryId, product.ProductCostPrice, product.ProductSalePrice);
    }

    public void Delete(int id) 
    {
        _service.Delete(id);
    }
}
