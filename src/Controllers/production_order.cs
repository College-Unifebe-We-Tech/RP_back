public class ProductionOrderController 
{
    private readonly ProductionOrderService _service;

    public ProductionOrderController() 
    {
        _service = new ProductionOrderService(); 
    }

    public IResult Get(int id) 
    {
        try
        {
            ProductionOrder productionOrderId = _service.Get(id);
            return Results.Json(productionOrderId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public IResult Create(ProductionOrder productionOrder) 
    {
        try
        {
            int? productionOrderId = _service.Create(productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);
            return Results.Json(productionOrderId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception)
        {
            return Results.Problem();
        }
    }

    public void Update(int id, ProductionOrder productionOrder) 
    {
        try 
        {
            _service.Update(id, productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);
        }
        catch (Exception)
        {
            Results.Problem();
        }
    }
    
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}
