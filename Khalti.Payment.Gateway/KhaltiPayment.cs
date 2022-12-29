using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.InteropServices;
using System.Reflection.Metadata;

namespace Khalti.Payment.Gateway
{
    public class KhaltiPayment
    {
        public string ContentType { get; set; } = "application/json";
        private string GetKhaltiPaymentUrl(KhaltiPaymentUrlType urlType, bool sandBoxMode)
        {
            string methodName = (urlType == KhaltiPaymentUrlType.Initialization) ? KhaltiPaymentUrl.Initialization : KhaltiPaymentUrl.Verification;
            return ((sandBoxMode ? KhaltiPaymentUrl.SandBoxUrl : KhaltiPaymentUrl.Url) + PaymentApi.Version+ methodName);

        }
        public async Task<T> ProcessPayment<T>(string secretKey, bool sandBox, object content)
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                string apiPath = GetKhaltiPaymentUrl(KhaltiPaymentUrlType.Initialization, sandBox);
                string json = JsonConvert.SerializeObject(content);
                httpClient.BaseAddress = new Uri(apiPath);
                httpClient.DefaultRequestHeaders.Add("Authorization", "key " + secretKey);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));
                HttpResponseMessage response = await httpClient.PostAsync(apiPath, new StringContent(json, Encoding.UTF8, ContentType));
                return await GetResult<T>(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<T> GetResult<T>(HttpResponseMessage response)
        {
            T result = default;
            if (response.IsSuccessStatusCode)
            {
                string str = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<T>(str);
            }
            return result;
        }
        public async Task<T> VerifyPayment<T>(string secretKey, bool sandBoxMode, string pidx)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = GetKhaltiPaymentUrl(KhaltiPaymentUrlType.Verification, sandBoxMode);
                    var parameters = new Dictionary<string, string>();
                    parameters["pidx"] = pidx;
                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Add("Authorization", "key " + secretKey);
                    HttpResponseMessage response = await httpClient.PostAsync(url, new FormUrlEncodedContent(parameters));
                    return await GetResult<T>(response);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
