public class HealthService {
    private readonly IRepositoryHealth<Health> _repository; // interface to whatever will be the source of data.

    public HealthService() {
        _repository = new HealthRepository(); // in this case it will be this one using sql server.
    }

    public string Check() {
        Health? createdHealth =_repository.Create(DateTime.Now);
                
        return createdHealth.sync.ToLongDateString();
    }
}
