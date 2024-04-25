using System.Data;
using System.Data.SqlClient;
using System.Reflection;

public class SQLServerAdapter<T> {
    private readonly string _connectionString;

    public SQLServerAdapter(string connectionString) {
        _connectionString = connectionString;
    }

    public void Execute(string query, SqlParameter[] parameters = null) {
        using SqlConnection connection = new(_connectionString);
        using SqlCommand command = new(query, connection);
        if (parameters != null) {
            command.Parameters.AddRange(parameters);
        }

        connection.Open();
        command.ExecuteNonQuery();
    }

    public T? Get<T>(string query, SqlParameter[] parameters = null) where T : new() {
        using (SqlConnection connection = new(_connectionString)) {
            using SqlCommand command = new(query, connection);
            if (parameters != null) {
                command.Parameters.AddRange(parameters);
            }

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()){
                return MapToObject<T>(reader);
            }
        }

        return default;
    }

    public List<T> List<T>(string query, SqlParameter[] parameters = null) where T : new() {
        List<T> result = [];

        using (SqlConnection connection = new(_connectionString)) {
            using SqlCommand command = new(query, connection);
            if (parameters != null) {
                command.Parameters.AddRange(parameters);
            }
            
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()){
                T obj = MapToObject<T>(reader);
                result.Add(obj);
            }
        }

        return result;
    }

    private T MapToObject<T>(IDataRecord record) where T : new() {
        T obj = new();
        
        for (int i = 0; i < record.FieldCount; i++) {
            PropertyInfo property = typeof(T).GetProperty(record.GetName(i));
            if (property != null && record[i] != DBNull.Value) {
                property.SetValue(obj, Convert.ChangeType(record[i], property.PropertyType));
            }
        }

        return obj;
    }
}
