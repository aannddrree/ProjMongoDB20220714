namespace ProjMongoDB20220714.Utils
{
    public interface IProjMongoDotnetDatabaseSettings
    {
        string ClientCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
