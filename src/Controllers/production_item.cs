public class ProductionItemController 
{
    private readonly ProductionItemService _service;

    public ProductionItemController() 
    {
        _service = new ProductionItemService(); 
    }

    public async Task<IResult> List()
    {
        List<ProductionItem> productionItems = await _service.List();

        return Results.Json(productionItems, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Get(int id) 
    {
        ProductionItem? productionItemId = await _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(productionItemId, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Create(ProductionItem productionItem) 
    {
        int? productionItemId = await _service.Create(productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste) ?? throw new Exception("did not create");
            
        return Results.Json(productionItemId, statusCode: StatusCodes.Status201Created);
    }

    public async Task<IResult> Update(int id, ProductionItem productionItem) 
    {
        await _service.Update(id, productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);
    
        return Results.NoContent();
    }

    public async Task<IResult> Delete(int id) 
    {
        await _service.Delete(id);

        return Results.NoContent();
    }
}
