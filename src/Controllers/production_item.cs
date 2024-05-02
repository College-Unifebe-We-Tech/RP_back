public class ProductionItemController 
{
    private readonly ProductionItemService _service;

    public ProductionItemController() 
    {
        _service = new ProductionItemService(); 
    }

    public async Task<IResult> List()
    {
        List<ProductionItem> productionItems = _service.List();

        return Results.Json(productionItems, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Get(int id) 
    {
        ProductionItem? productionItemId = _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(productionItemId, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Create(ProductionItem productionItem) 
    {
        int? productionItemId = _service.Create(productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste) ?? throw new Exception("did not create");
            
        return Results.Json(productionItemId, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Update(int id, ProductionItem productionItem) 
    {
        _service.Update(id, productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);
    
        return Results.Ok();
    }

    public async Task<IResult> Delete(int id) 
    {
        _service.Delete(id);

        return Results.Ok();
    }
}
