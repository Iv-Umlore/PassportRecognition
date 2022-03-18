using MongoDB.Bson;
using MongoDB.Driver;
using Shared.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;

namespace DataService.src.Repository
{
    public class MongoDbRepository : IDbRepository<ExternalObjectModel>
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
        private IMongoCollection<ExternalObjectModel> Documents => db.GetCollection<ExternalObjectModel>("docs");

        public async Task<ExternalObjectModel> AddDocument(ExternalObjectModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(ExternalObjectModel));

            if (await GetDocumentInfo(model.DocNumber) == null)
            {
                await Documents.InsertOneAsync(model);

                return model;
            }

            return model;
        }

        public async Task<ExternalObjectModel> GetDocumentInfo(string documentNumber)
        {
            var filter = new BsonDocument("DocNumber", documentNumber);
            var document = await Documents.Find(filter).FirstOrDefaultAsync();
            return document;
        }

        public async Task<List<ExternalObjectModel>> GetDocuments() =>
             await Documents.Find(new BsonDocument()).ToListAsync();


    }
}
