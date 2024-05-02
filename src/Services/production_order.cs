public class ProductionOrderService
{

    private readonly IRepositoryProductionOrder<ProductionOrder> _repository;

    public ProductionOrderService() 
    {
        _repository = new ProductionOrderRepository();
    }

    public Task<List<ProductionOrder>> List()
    {
        return _repository.List();
    }

    public Task<ProductionOrder?> Get(int id)
    {
        return _repository.Get(id);
    }

    public async Task<int?> Create(string description, DateTime expectedStartDate, DateTime expectedCompletionDate, int employeeId) 
    {
        var productionOrder = await _repository.Create(description, expectedStartDate, expectedCompletionDate, employeeId);
        
        return productionOrder.ProductionOrderId;
    }

    public async Task Update(int id, string description, DateTime expectedStartDate, DateTime expectedCompletionDate, int employeeId) 
    {
        var _ = await _repository.Update(id, description, expectedStartDate, expectedCompletionDate, employeeId) ?? throw new ArgumentException($"Production Order with id {id} does not exist");        
    }

    public async Task Delete (int id)
    {
        var _ = await _repository.Delete(id) ?? throw new ArgumentException($"Production Order with id {id} does not exist");
    }
}