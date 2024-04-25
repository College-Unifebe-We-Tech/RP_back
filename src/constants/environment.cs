using dotenv.net.Utilities;

public static class EnvironmentVariables {
    public static string DBString { get; } = EnvReader.GetStringValue("DBString");
}
