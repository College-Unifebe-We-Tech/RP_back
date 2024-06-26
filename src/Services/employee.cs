public class EmployeeService
{

    private readonly IRepositoryEmployee<Employee> _repository;

    public EmployeeService() 
    {
        _repository = new EmployeeRepository();
    }

    public Task<List<Employee>> List()
    {
        return _repository.List();
    }

    public async Task<Employee> Get(int id)
    {
        return await _repository.Get(id) ?? throw new ArgumentException($"Employee with id {id} does not exist");
    }

    public async Task<int?> Create(string name, string address, string email) 
    {
        Employee? existingEmployee = await _repository.GetByName(name);
        if (existingEmployee?.EmployeeName == name)
        {
            throw new ArgumentException("Funcionário já existe");
        }

         Employee? createdEmployee = await _repository.Create(name, address, email);
        
         return createdEmployee?.EmployeeId;
    }

    public async Task Update(int id, string name, string address, string email) 
    {
        var _ = await _repository.Update(id, name, address, email) ?? throw new ArgumentException($"Employee with id {id} does not exist");       
    }

    public async Task Delete (int id)
    {
        var _ = await _repository.Delete(id) ?? throw new ArgumentException($"Employee with id {id} does not exist");       
    }
}