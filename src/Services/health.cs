public class HealthService {
    private readonly IRepositoryHealth<Health> _repository;

    public HealthService() {
        _repository = new HealthRepository();
    }

    // Change the return type to Task<Health>
    public async Task<Health> Check() {
        Health? createdHealth = await _repository.Create(DateTime.Now);
        // Ensure that createdHealth is not null before accessing its properties
        return createdHealth;
    }
}