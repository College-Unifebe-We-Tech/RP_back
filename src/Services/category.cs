public class CategoryService
{

    private readonly IRepositoryCategory<Category> _repository;

    public CategoryService() 
    {
        _repository = new CategoryRepository();
    }

    public Task<List<Category>> List()
    {
        return _repository.List();
    }

    public async Task<Category> Get(int id)
    {
        return await _repository.Get(id) ?? throw new ArgumentException($"Category with id {id} does not exist");
    }

    public async Task<int?> Create(string name) 
    {
        Category? existingCategory = await _repository.GetByName(name);
        if (existingCategory?.CategoryName == name)
        {
            throw new ArgumentException("Categoria já existe");
        }

         Category? createdCategory = await _repository.Create(name);
        
         return createdCategory?.CategoryId;
    }

    public async Task Update(int id, string name) 
    {
        var _ = await _repository.Update(id, name) ?? throw new ArgumentException($"Category with id {id} does not exist");       
    }

    public async Task Delete (int id)
    {
        var _ = await _repository.Delete(id) ?? throw new ArgumentException($"Category with id {id} does not exist");       
    }
}