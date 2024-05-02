public class ProductionItemService
{

    private readonly IRepositoryProductionItem<ProductionItem> _repository;

    public ProductionItemService() 
    {
        _repository = new ProductionItemRepository();
    }

    public List<ProductionItem> List()
    {
        return _repository.List() ?? [];
    }

    public ProductionItem? Get(int id)
    {
        return _repository.Get(id);
    }

    public int? Create(int productionOrder, int productId, int quantity, bool waste) 
    {
        var productionItem = _repository.Create(productionOrder, productId, quantity, waste);
        return productionItem.ProductionItemId;
    }

    public void Update(int id, int productionOrder, int productId, int quantity, bool waste) 
    {
        _repository.Update(id, productionOrder, productId, quantity, waste);        
    }

    public void Delete (int id)
    {
        _repository.Delete(id);
    }
}