namespace Infrastructure.Config.Options
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string Database {  get; set; } = null!;
    }
}
