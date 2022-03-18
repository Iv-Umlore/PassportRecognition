using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataService.src.Repository;

namespace DataService.src.Database
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDbRepository<MongoDataModel> _dbRepository;
        public DatabaseService(IDbRepository<MongoDataModel> dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<MongoDataModel> CheckWriteAndReturnDocumentInfo(ExternalObjectModel externalModel, byte[] image)
        {
            MongoDataModel model = new MongoDataModel()
            {
                DocNumber = externalModel.DocNumber,
                PersonName = externalModel.FirstSecondName,
                DocInfo = externalModel,
                Image = image
            };

            return await _dbRepository.AddDocument(model);
        }
        
        public async Task<MongoDataModel> GetDocumentInfo(string documentNumber) =>
              await _dbRepository.GetDocumentInfo(documentNumber);

        public async Task<List<MongoDataModel>> GetScannedDocuments() =>
               await _dbRepository.GetDocuments();


    }
}


