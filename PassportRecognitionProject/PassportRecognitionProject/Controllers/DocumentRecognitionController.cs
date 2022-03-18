using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PassportRecognitionProject.src.Services;
using System.Threading.Tasks;

namespace PassportRecognitionProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DocumentRecognitionController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentRecognitionController(IDocumentService docService)
        {
            _documentService = docService;
        }

        /// <summary>
        /// Получить расшифровку документа
        /// </summary>
        /// <param name="docScan"> Исходное изображение документа </param>
        [HttpPost]
        public async Task<IActionResult> RecognitionNewDocument([FromForm] IFormFile docScan)
        {
            using var fileStream = docScan.OpenReadStream();
            byte[] image = new byte[fileStream.Length];
            fileStream.Read(image, 0, (int)fileStream.Length);
            return Ok(await _documentService.RecognitionDocument(image));
        }

        /// <summary>
        /// Получить информацию по конкретному документу
        /// </summary>
        /// <param name="documentId"> Уникальный идентификатор документа </param>
        /// <param name="pages"> Номера необходимых страниц(по умолчанию все)</param>
        /// <returns></returns>
        [HttpGet]
        [Route("info")]
        public async Task<IActionResult> GetDocumentInfo(string documentNumber)
        {
            return Ok(await _documentService.GetDocumentInfo(documentNumber));
        }

        /// <summary>
        /// Получить список всех расшифрованных документов
        /// </summary>
        [HttpGet]
        [Route("scanned")]
        public async Task<IActionResult> GetScannedDocuments()
        {
            return Ok( await _documentService.GetScannedDocument());
        }
    }
}
