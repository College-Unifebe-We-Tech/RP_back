public class ProductionItemController 
{
    private readonly ProductionItemService _service;

    public ProductionItemController() 
    {
        _service = new ProductionItemService(); 
    }

    public IResult Get(int id) 
    {
        try
        {
            ProductionItem? productionItemId = _service.Get(id) ?? throw new Exception("does not exist");

            return Results.Json(productionItemId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }

    public IResult Create(ProductionItem productionItem) 
    {
        try
        {
            int? productionItemId = _service.Create(productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste) ?? throw new Exception("did not create");
            
            return Results.Json(productionItem, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }

    public IResult Update(int id, ProductionItem productionItem) 
    {
        try 
        {
            _service.Update(id, productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);
        
            return Results.Ok();
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }

    public IResult Delete(int id) 
    {
        try
        {
            _service.Delete(id);

            return Results.Ok();
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }
}
