using ExternalService.Model.Requests;
using ExternalService.Model.Responses;
using System.Threading.Tasks;

namespace ExternalService.src
{
    public interface IRequestSender
    {
        Task<IExternalServiceResponse> Send(string URL, IExternalServiceRequest externalServiceRequest);
    }
}
