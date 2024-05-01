public class CategoryService
{

    private readonly IRepositoryCategory<Category> _repository;

    public CategoryService() 
    {
        _repository = new CategoryRepository();
    }

    public List<Category> List()
    {
        return _repository.List() ?? [];
    }

    public Category Get(int id)
    {
        var category = _repository.Get(id) ?? throw new ArgumentException($"Category with id {id} does not exist");
        return category;
    }

    public int? Create(string name) 
    {
        var existingCategory = _repository.GetByName(name);
        if (existingCategory?.CategoryName == name)
        {
            throw new ArgumentException("Categoria já existe");
        }

         Category createdCategory = _repository.Create(name);
        
         return createdCategory.CategoryId;
    }

    public void Update(int id, string name) 
    {
        var _ = _repository.Update(id, name) ?? throw new ArgumentException($"Category with id {id} does not exist");       
    }

    public void Delete (int id)
    {
        var _ = _repository.Delete(id) ?? throw new ArgumentException($"Category with id {id} does not exist");       
    }
}