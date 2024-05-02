public class EmployeeService
{

    private readonly IRepositoryEmployee<Employee> _repository;

    public EmployeeService() 
    {
        _repository = new EmployeeRepository();
    }

    public List<Employee> List()
    {
        return _repository.List() ?? [];
    }

    public Employee? Get(int id)
    {
        return _repository.Get(id);
    }

    public int? Create(string name, string address, string email) 
    {
        var existingEmployee = _repository.GetByName(name);
        if (existingEmployee?.EmployeeName == name)
        {
            throw new Exception("Funcionario já existe");
        }

        var createdEmployee = _repository.Create(name, address, email);

        return createdEmployee?.EmployeeId;
    }

    public void Update(int id, string name, string address, string email) 
    {
        _repository.Update(id, name, address, email);        
    }

    public void Delete (int id)
    {
        _repository.Delete(id);
    }
}