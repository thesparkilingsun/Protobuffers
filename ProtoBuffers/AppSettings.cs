namespace ProtoBuffers
{
    public class ConnectionString
    {
        public string ConnectToDatabaseString { get; set; } = default!;
    }
    public class AppSettings
    {
        public ConnectionString ConnectionString { get; set; } = default!;
    }
}
