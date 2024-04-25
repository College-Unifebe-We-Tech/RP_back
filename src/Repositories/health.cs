using System.Data;
using System.Data.SqlClient;

public interface IRepository<T> {
    Health? Create(DateTime date);
}

public class HealthRepository : IRepository<Health> {
    private readonly SQLServerAdapter<Health> _sql;

    public HealthRepository() {
        _sql = new SQLServerAdapter<Health>(EnvironmentVariables.DBString);
    }

    public Health? Create(DateTime date) {
        return _sql.Get<Health>("INSERT INTO health (sync) OUTPUT inserted.sync VALUES(@date)", [
            new SqlParameter("@date", SqlDbType.DateTime) { Value = date }
        ]);
    }
}
