public class ProductionItemController 
{
    private readonly ProductionItemService _service;

    public ProductionItemController() 
    {
        _service = new ProductionItemService(); 
    }

    public IResult Get(int id) 
    {
        ProductionItem? productionItemId = _service.Get(id) ?? throw new Exception("does not exist");

        return Results.Json(productionItemId, statusCode: StatusCodes.Status200OK);
    }

    public IResult Create(ProductionItem productionItem) 
    {
        int? productionItemId = _service.Create(productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste) ?? throw new Exception("did not create");
            
        return Results.Json(productionItemId, statusCode: StatusCodes.Status200OK);
    }

    public IResult Update(int id, ProductionItem productionItem) 
    {
        _service.Update(id, productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);
    
        return Results.Ok();
    }

    public IResult Delete(int id) 
    {
        _service.Delete(id);

        return Results.Ok();
    }
}
