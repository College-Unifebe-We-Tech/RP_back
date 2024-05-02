public class ProductionOrderService
{

    private readonly IRepositoryProductionOrder<ProductionOrder> _repository;

    public ProductionOrderService() 
    {
        _repository = new ProductionOrderRepository();
    }

    public List<ProductionOrder> List()
    {
        return _repository.List() ?? [];
    }

    public ProductionOrder? Get(int id)
    {
        return _repository.Get(id);
    }

    public int? Create(string description, DateTime expectedStartDate, DateTime expectedCompletionDate, int employeeId) 
    {
        var productionOrder = _repository.Create(description, expectedStartDate, expectedCompletionDate, employeeId);
        return productionOrder.ProductionOrderId;
    }

    public void Update(int id, string description, DateTime expectedStartDate, DateTime expectedCompletionDate, int employeeId) 
    {
        _repository.Update(id, description, expectedStartDate, expectedCompletionDate, employeeId);        
    }

    public void Delete (int id)
    {
        _repository.Delete(id);
    }
}