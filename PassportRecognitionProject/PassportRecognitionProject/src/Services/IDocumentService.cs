using System;
using System.Collections.Generic;

// Временное решение
using DocumentInfoModel = System.Object;
using DocumentShortInfo = System.Object;
using System.Threading.Tasks;
using Shared.Models;

namespace PassportRecognitionProject.src.Services
{
    /// <summary>
    /// Интерфейс взаимодействия с бизнес-логикой
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Расшифровка документа
        /// </summary>
        /// <param name="image"> Исходное изображение </param>
        /// <returns> Информацию об отправляемом документе </returns>
        // object - DocumentInfoModel
        public Task<ExternalObjectModel> RecognitionDocument(byte[] image);

        /// <summary>
        /// Получение информации об сохранённом документе
        /// </summary>
        /// <param name="documentNumber"> уникальный идентификатор документа </param>
        /// <returns> Информация по запрашиваемому документу </returns>
        public Task<ExternalObjectModel> GetDocumentInfo(string documentNumber);

        /// <summary>
        /// Получить список отсканированных документов
        /// </summary>
        /// <returns> Список краткой инормации об готовых документах для последующего выбора </returns>
        public Task<List<ExternalObjectModel>> GetScannedDocument();
    }
}
