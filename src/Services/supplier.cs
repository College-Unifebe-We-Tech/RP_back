public class SupplierService
{

    private readonly IRepositorySupplier<Supplier> _repository;

    public SupplierService() 
    {
        _repository = new SupplierRepository();
    }

    public Task<List<Supplier>> List()
    {
        return _repository.List();
    }

    public Task<Supplier?> Get(int id)
    {
        return _repository.Get(id);
    }

    public async Task<int?> Create(string name, string cnpj, string address, string email) 
    {
        var existingSupplier = await _repository.GetByName(name);
        if (existingSupplier?.SupplierName == name)
        {
            throw new Exception("Produto já existe");
        }

        var createdSupplier = await _repository.Create(name, cnpj, address, email);

        return createdSupplier?.SupplierId;
    }

    public async Task Update(int id, string name, string cnpj, string address, string email) 
    {
        var _ = await _repository.Update(id, name, cnpj, address, email) ?? throw new ArgumentException($"Supplier with id {id} does not exist");        
    }

    public async Task Delete (int id)
    {
        var _ = await _repository.Delete(id) ?? throw new ArgumentException($"Supplier with id {id} does not exist");
    }
}