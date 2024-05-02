public class ProductionOrderController 
{
    private readonly ProductionOrderService _service;

    public ProductionOrderController() 
    {
        _service = new ProductionOrderService(); 
    }

    public async Task<IResult> List()
    {
        List<ProductionOrder> productionOrders = await _service.List();

        return Results.Json(productionOrders, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Get(int id) 
    {
        ProductionOrder? productionOrderId = await _service.Get(id)  ?? throw new Exception("does not exist");

        return Results.Json(productionOrderId, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Create(ProductionOrder productionOrder) 
    {
        int? productionOrderId = await _service.Create(productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId) ?? throw new Exception("did not create");
        
        return Results.Json(productionOrderId, statusCode: StatusCodes.Status200OK);
    }

    public async Task<IResult> Update(int id, ProductionOrder productionOrder) 
    {
        await _service.Update(id, productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);
    
        return Results.NoContent();
    }
    
    public async Task<IResult> Delete(int id)
    {
        await _service.Delete(id);
    
        return Results.NoContent();
    }
}
