namespace Shared.Models
{
    /// <summary>
    /// Данные для подключения к MongoDb.
    /// </summary>
    public class MongoDbInfo
    {
        public string ConnectionString { get; set; }
        public string DbName { get; set; }
    }
}