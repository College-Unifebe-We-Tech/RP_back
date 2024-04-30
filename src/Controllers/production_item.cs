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
            ProductionItem productionItemId = _service.Get(id);
            return Results.Json(productionItemId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public IResult Create(ProductionItem productionItem) 
    {
        try
        {
            int? productionItemId = _service.Create(productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);
            return Results.Json(productionItem, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public void Update(int id, ProductionItem productionItem) 
    {
        try 
        {
            _service.Update(id, productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);
        }
        catch (Exception)
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
        catch (Exception)
        {
            Results.Problem();
        }
        
    }
}
