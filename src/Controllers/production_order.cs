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
            ProductionOrder? productionOrderId = _service.Get(id)  ?? throw new Exception("does not exist");

            return Results.Json(productionOrderId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }

    public IResult Create(ProductionOrder productionOrder) 
    {
        try
        {
            int? productionOrderId = _service.Create(productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId) ?? throw new Exception("did not create");
            
            return Results.Json(productionOrderId, statusCode: StatusCodes.Status200OK);
        }
        catch (Exception exception)
        {
            return Results.Problem(exception.Message);;
        }
    }

    public IResult Update(int id, ProductionOrder productionOrder) 
    {
        try 
        {
            _service.Update(id, productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);
        
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
