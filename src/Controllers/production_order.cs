public class ProductionOrderController 
{
    private readonly ProductionOrderService _service;

    public ProductionOrderController() 
    {
        _service = new ProductionOrderService(); 
    }

    public IResult Get(int id) 
    {
        ProductionOrder? productionOrderId = _service.Get(id)  ?? throw new Exception("does not exist");

        return Results.Json(productionOrderId, statusCode: StatusCodes.Status200OK);
    }

    public IResult Create(ProductionOrder productionOrder) 
    {
        int? productionOrderId = _service.Create(productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId) ?? throw new Exception("did not create");
        
        return Results.Json(productionOrderId, statusCode: StatusCodes.Status200OK);
    }

    public IResult Update(int id, ProductionOrder productionOrder) 
    {
        _service.Update(id, productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);
    
        return Results.Ok();
    }
    
    public IResult Delete(int id)
    {
        _service.Delete(id);
    
        return Results.Ok();
    }
}
