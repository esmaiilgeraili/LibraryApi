namespace LibraryManagement.Shared.Contracts.ConfigurationDTO
{
    public class ConfigurationModel
    {
        public ConnectionStringModel ConnectionString { get; set; }
    }
    public class ConnectionStringModel
    {
        public string LibraryContextDB { get; set; }
    }
}
