public class ProductionItemService
{

    private readonly IRepositoryProductionItem<ProductionItem> _repository;

    public ProductionItemService() 
    {
        _repository = new ProductionItemRepository();
    }

    public Task<List<ProductionItem>> List()
    {
        return _repository.List();
    }

    public Task<ProductionItem?> Get(int id)
    {
        return _repository.Get(id);
    }

    public async Task<int?> Create(int productionOrder, int productId, int quantity, bool waste) 
    {
        var productionItem = await _repository.Create(productionOrder, productId, quantity, waste);

        return productionItem.ProductionItemId;
    }

    public async Task Update(int id, int productionOrder, int productId, int quantity, bool waste) 
    {
        var _ = await _repository.Update(id, productionOrder, productId, quantity, waste) ?? throw new ArgumentException($"Production Item with id {id} does not exist");;        
    }

    public async Task Delete (int id)
    {
        var _ = await _repository.Delete(id) ?? throw new ArgumentException($"Production Item with id {id} does not exist");
    }
}