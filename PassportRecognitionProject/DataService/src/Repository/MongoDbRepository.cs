using MongoDB.Bson;
using MongoDB.Driver;
using Shared.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DataService.src.Repository
{
    public class MongoDbRepository : IDbRepository<MongoDataModel>
    {
        readonly MongoClient client;
        private readonly IMongoDatabase db;
        private readonly IOptions<MongoDbInfo> _mongoInfo;

        public MongoDbRepository(IOptions<MongoDbInfo> mongoInfo)
        {
            _mongoInfo = mongoInfo;
            client = new MongoClient(_mongoInfo.Value.ConnectionString);
            db = client.GetDatabase(_mongoInfo.Value.DbName);
        }

        private IMongoCollection<MongoDataModel> Documents => db.GetCollection<MongoDataModel>("docs");

        public async Task<MongoDataModel> AddDocument(MongoDataModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(MongoDataModel));

            if (await GetDocumentInfo(model.DocNumber) == null)
            {
                await Documents.InsertOneAsync(model);

                return model;
            }

            return model;
        }

        public async Task<MongoDataModel> GetDocumentInfo(string documentNumber)
        {
            var filter = new BsonDocument("DocNumber", documentNumber);
            var document = await Documents.Find(filter).FirstOrDefaultAsync();
            return document;
        }

        public async Task<List<MongoDataModel>> GetDocuments()
        {
            var models = await Documents.Find(new BsonDocument()).ToListAsync();
            return models.Select(it => new MongoDataModel()
            {
                DocNumber = it.DocNumber,
                PersonName = it.PersonName
            }).ToList();

        }

    }
}
