public class ProductService
{

    private readonly IRepositoryProduct<Product> _repository;

    public ProductService() 
    {
        _repository = new ProductRepository();
    }

    public Task<List<Product>> List()
    {
        return _repository.List();
    }

    public Task<Product?> Get(int id)
    {
        return _repository.Get(id);
    }

    public async Task<int?> Create(string name, int supplier, int category, decimal costPrice, decimal salePrice) 
    {
        var existingProduct = await _repository.GetByName(name);
        if (existingProduct?.ProductName == name)
        {
            throw new Exception("Produto já existe");
        }

        var createdProduct = await _repository.Create(name, supplier, category, costPrice, salePrice);

        return createdProduct?.ProductId;
    }

    public async Task Update(int id, string name, int supplier, int category, decimal costPrice, decimal salePrice) 
    {
        var _ = await _repository.Update(id, name, supplier, category, costPrice, salePrice) ?? throw new ArgumentException($"Product with id {id} does not exist");        
    }

    public async Task Delete (int id)
    {
        var _ = await _repository.Delete(id) ?? throw new ArgumentException($"Product with id {id} does not exist");
    }
}