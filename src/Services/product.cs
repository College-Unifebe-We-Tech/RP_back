public class ProductService
{

    private readonly IRepositoryProduct<Product> _repository;

    public ProductService() 
    {
        _repository = new ProductRepository();
    }

    public List<Product> List()
    {
        return _repository.List() ?? [];
    }

    public Product? Get(int id)
    {
        return _repository.Get(id);
    }

    public int? Create(string name, int supplier, int category, decimal costPrice, decimal salePrice) 
    {
        var existingProduct = _repository.GetByName(name);
        if (existingProduct?.ProductName == name)
        {
            throw new Exception("Produto já existe");
        }

        var createdProduct = _repository.Create(name, supplier, category, costPrice, salePrice);

        return createdProduct?.ProductId;
    }

    public void Update(int id, string name, int supplier, int category, decimal costPrice, decimal salePrice) 
    {
        _repository.Update(id, name, supplier, category, costPrice, salePrice);        
    }

    public void Delete (int id)
    {
        _repository.Delete(id);
    }
}