public class ProductionOrderController 
{
    private readonly ProductionOrderService _service;

    public ProductionOrderController() 
    {
        _service = new ProductionOrderService(); 
    }

    public async void Get(HttpContext context, int id) {
        var ProductionOrder =_service.Get(id);
         
        await context.Response.WriteAsJsonAsync<ProductionOrder>(ProductionOrder);
    }

    public async void Create(HttpContext context) {
        var productionOrder = await context.Request.ReadFromJsonAsync<ProductionOrder>();

        int? productionOrderId = _service.Create(productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);

        if (productionOrderId != null) {
            context.Response.StatusCode = 201;
            await context.Response.WriteAsync(productionOrderId.ToString());
        
            return;
        }

        context.Response.StatusCode = 500;
    }

    public async void Update(HttpContext context, int id) {
        var productionOrder = await context.Request.ReadFromJsonAsync<ProductionOrder>();

        _service.Update(id, productionOrder.ProductionOrderDescription, productionOrder.ProductionOrderExpectedStartDate, productionOrder.ProductionOrderExpectedCompletionDate, productionOrder.EmployeeId);
    }
    public void Delete(HttpContext context, int id) {
        _service.Delete(id);
    }
}
