using MongoDB.Bson;
namespace Shared.Models
{
    public class MongoDataModel
    {
        public ObjectId Id { get; set; }

        public string DocNumber { get; set; }

        public string PersonName { get; set; }

        public ExternalObjectModel DocInfo { get; set; }

        public byte[] Image { get; set; }
    }
}
