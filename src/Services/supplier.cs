public class SupplierService
{

    private readonly IRepositorySupplier<Supplier> _repository;

    public SupplierService() 
    {
        _repository = new SupplierRepository();
    }

    public List<Supplier> List()
    {
        return _repository.List() ?? [];
    }

    public Supplier? Get(int id)
    {
        return _repository.Get(id);
    }

    public int? Create(string name, string cnpj, string address, string email) 
    {
        var existingSupplier = _repository.GetByName(name);
        if (existingSupplier?.SupplierName == name)
        {
            throw new Exception("Produto já existe");
        }

        var createdSupplier = _repository.Create(name, cnpj, address, email);

        return createdSupplier?.SupplierId;
    }

    public void Update(int id, string name, string cnpj, string address, string email) 
    {
        _repository.Update(id, name, cnpj, address, email);        
    }

    public void Delete (int id)
    {
        _repository.Delete(id);
    }
}