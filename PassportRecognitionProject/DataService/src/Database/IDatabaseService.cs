using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataService.src.Database
{
    /// <summary>
    /// Интерфейс взаимодействия с базой данных
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// Проверка наличия записи в базе, запись в случае отсутствия
        /// </summary>
        /// <param name="externalModel"> Данные полученные от внешнего сервиса </param>
        /// <returns> Преобразованная информация о документе </returns>
        public Task<ExternalObjectModel> CheckWriteAndReturnDocumentInfo(ExternalObjectModel externalModel);

        /// <summary>
        /// Получение списка уже сохранённых документов
        /// </summary>
        public Task<List<ExternalObjectModel>> GetScannedDocuments();

        /// <summary>
        /// Получение информации по конкретному документу
        /// </summary>
        /// <param name="documentNumber"> Уникальный идентификатор документа </param>
        public Task<ExternalObjectModel> GetDocumentInfo(string documentNumber);
    }
}
