using ExternalService.Model.Requests;
using ExternalService.Model.Responses;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using Shared.Enums;

namespace ExternalService.src
{
    public class RegulaRequestSender: IRequestSender
    {
        public async Task<IExternalServiceResponse> Send(string URL, IExternalServiceRequest externalServiceRequest)
        {
            string responseRes;

            var json = JsonConvert.SerializeObject(externalServiceRequest);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(URL, data);

                responseRes = response.Content.ReadAsStringAsync().Result;                
            };

            switch (externalServiceRequest.GetType())
            {
                case ExternalTypeEnum.Regula: return JsonConvert.DeserializeObject<RegulaResponse>(responseRes);
                default: throw new Exception("Непредвиденный тип запроса сервиса");
            }
        }
    }
}
