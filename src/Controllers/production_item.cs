public class ProductionItemController 
{
    private readonly ProductionItemService _service;

    public ProductionItemController() 
    {
        _service = new ProductionItemService(); 
    }

    public async void Get(HttpContext context, int id) {
        var productionItem =_service.Get(id);
         
        await context.Response.WriteAsJsonAsync<ProductionItem>(productionItem);
    }

    public async void Create(HttpContext context) 
    {
        var productionItem = await context.Request.ReadFromJsonAsync<ProductionItem>();

        int? productionItemId = _service.Create(productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);

        if (productionItemId != null) 
        {
            context.Response.StatusCode = 201;
            await context.Response.WriteAsync(productionItemId.ToString());
        
            return;
        }

        context.Response.StatusCode = 500;
    }

    public async void Update(HttpContext context, int id) 
    {
        var productionItem = await context.Request.ReadFromJsonAsync<ProductionItem>();

        _service.Update(id, productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);
    }
    public void Delete(HttpContext context, int id) 
    {
        _service.Delete(id);
    }
}
