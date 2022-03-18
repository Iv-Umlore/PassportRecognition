using ExternalService.Model.Requests;
using Microsoft.Extensions.Options;
using Shared.Models;
using System;
using System.Threading.Tasks;
using ImageObject = System.Object;

namespace ExternalService.src
{
    public class ExternalRecognitionService : IExternalRecognitionService
    {
        private readonly IOptions<ExternalServiceInfo> _externalServiceInfo;
        private readonly IRequestSender _requestSender;

        public ExternalRecognitionService(IOptions<ExternalServiceInfo> externalServiceURL, IRequestSender requestSender)
        {
            _externalServiceInfo = externalServiceURL;
            _requestSender = requestSender;
        }

        public async Task<ExternalObjectModel> GetRecognition(string image)
        {
            var response = await _requestSender.Send(_externalServiceInfo.Value.URL, new RegulaServiceRequest(image));

            return response.ConverToCommonType();
        }
    }
}
