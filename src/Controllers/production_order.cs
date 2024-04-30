public class ProductionOrderController 
{
    private readonly ProductionOrderService _service;

    public ProductionOrderController() 
    {
        _service = new ProductionOrderService(); 
    }

    public void Get(int id) 
    {
        var productionOrder =_service.Get(id);
         
        Results.Json(productionOrder);
        Results.Ok();
    }

    public void Create(ProductionOrder productionOrder) 
    {

        int? productionOrderId = _service.Create(productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);

        if (productionOrderId != null) 
        {
            Results.Json(productionOrderId);
            Results.Ok();
            
            return;
        }

        Results.Problem();
    }

    public void Update(int id, ProductionOrder productionOrder) 
    {
        _service.Update(id, productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);
    }
    
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}
