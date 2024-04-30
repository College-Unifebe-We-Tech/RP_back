public class ProductionItemController 
{
    private readonly ProductionItemService _service;

    public ProductionItemController() 
    {
        _service = new ProductionItemService(); 
    }

    public void Get(int id) 
    {
        var productionItem =_service.Get(id);
         
        Results.Json(productionItem);
        Results.Ok();
    }

    public void Create(ProductionItem productionItem) 
    {
        int? productionItemId = _service.Create(productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);

        if (productionItemId != null) 
        {
            Results.Json(productionItemId);
            Results.Ok();
            
            return;
        }

        Results.Problem();
    }

    public void Update(int id, ProductionItem productionItem) 
    {
        _service.Update(id, productionItem.ProductionOrderId, productionItem.ProductId, productionItem.Quantity, productionItem.Waste);
    }

    public void Delete(int id) 
    {
        _service.Delete(id);
    }
}
