using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataService.src.Repository;

namespace DataService.src.Database
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDbRepository<ExternalObjectModel> _dbRepository;
        public DatabaseService(IDbRepository<ExternalObjectModel> dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task<ExternalObjectModel> CheckWriteAndReturnDocumentInfo(ExternalObjectModel externalModel) => 
               await _dbRepository.AddDocument(externalModel);
        
        public async Task<ExternalObjectModel> GetDocumentInfo(string documentNumber) =>
              await _dbRepository.GetDocumentInfo(documentNumber);

        public async Task<List<ExternalObjectModel>> GetScannedDocuments() =>
               await _dbRepository.GetDocuments();


    }
}


