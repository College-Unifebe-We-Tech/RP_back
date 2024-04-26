public class CategoryService
{

    private readonly IRepositoryCategory<Category> _repository;

    public CategoryService() 
    {
        _repository = new CategoryRepository();
    }

    public Category? Get(int id)
    {
        return _repository.Get(id);
    }

    public int? Create(string name) 
    {
        var existingCategory = _repository.GetByName(name);
        if (existingCategory?.CategoryName == name)
        {
            throw new Exception("Categoria já existe");
        }

        var createdCategory = _repository.Create(name);

        return createdCategory?.CategoryId;
    }

    public void Update(int id, string name) 
    {
        _repository.Update(id, name);        
    }

    public void Delete (int id)
    {
        _repository.Delete(id);
    }
}