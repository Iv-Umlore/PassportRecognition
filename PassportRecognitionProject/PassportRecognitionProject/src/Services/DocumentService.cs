using System;
using System.Collections.Generic;
using ExternalService.src;
using DataService.src.Database;
using Shared.Models;
using System.Threading.Tasks;

namespace PassportRecognitionProject.src.Services
{
    public class DocumentService : IDocumentService
    {
        private IExternalRecognitionService _externalService;
        private IDatabaseService _databaseService;

        public DocumentService(IDatabaseService databaseService, IExternalRecognitionService externalService)
        {
            _externalService = externalService;
            _databaseService = databaseService;
        }

        public async Task<ExternalObjectModel> RecognitionDocument(byte[] image)
        {
            var externalInfo = await GetRecognitionDocFromExternalService(image);
            return await AddToDataBase(externalInfo);
        }

        public async Task<ExternalObjectModel> GetDocumentInfo(string documentNumber) =>
               await _databaseService.GetDocumentInfo(documentNumber);
         
        public async Task<List<ExternalObjectModel>> GetScannedDocument() =>
               await _databaseService.GetScannedDocuments();

        
        /// <summary>
        /// Получить от внешнего сервиса распознанную информация с изображения документа
        /// </summary>
        /// <param name="image"> исходное изображение </param>
        /// <returns> Информация пришедшая с внешнего сервиса </returns>
        private async Task<ExternalObjectModel> GetRecognitionDocFromExternalService(byte[] document)
        {
            string image = Convert.ToBase64String(document);
            return await _externalService.GetRecognition(image);
        }

        /// <summary>
        /// Отправить полученный ответ от внешнего сервиса в базу данных
        /// </summary>
        /// <param name="externalModel"> Инофрмация полученная от внешнего сервиса </param>
        /// <returns> Расшифрованную и универсальную модель документа </returns>
        private async Task<ExternalObjectModel> AddToDataBase(ExternalObjectModel externalModel)
        {
            return await _databaseService.CheckWriteAndReturnDocumentInfo(externalModel);
        }


    }
}
