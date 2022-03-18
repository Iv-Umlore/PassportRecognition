using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace DataService.src.Repository
{
    public interface IDbRepository<T>
    {

        public Task<T> AddDocument(MongoDataModel model);
        public Task<T> GetDocumentInfo(string documentNumber);
        public Task<List<T>> GetDocuments();

    }
}
