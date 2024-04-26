public class ProductionOrderService
{

    private readonly IRepositoryProductionOrder<ProductionOrder> _repository;

    public ProductionOrderService() 
    {
        _repository = new ProductionOrderRepository();
    }

    public ProductionOrder? Get(int id)
    {
        return _repository.Get(id);
    }

    public int? Create(string description, DateOnly expectedStartDate, DateOnly expectedCompletionDate, int employeeId) 
    {
        var productionOrder = _repository.Create(description, expectedStartDate, expectedCompletionDate, employeeId);
        return productionOrder.ProductionOrderId;
    }

    public void Update(int id, string description, DateOnly expectedStartDate, DateOnly expectedCompletionDate, int employeeId) 
    {
        _repository.Update(id, description, expectedStartDate, expectedCompletionDate, employeeId);        
    }

    public void Delete (int id)
    {
        _repository.Delete(id);
    }
}