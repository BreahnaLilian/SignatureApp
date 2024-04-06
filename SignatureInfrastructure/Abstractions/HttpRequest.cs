using SignatureInfrastructure.BasicModels;
using SignatureInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SignatureInfrastructure.Abstractions
{
    public abstract class HttpRequest : IHttpRequest
    {
        public string Get(QueryData queryData)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                string content = "";

                if (queryData != null)
                {
                    _httpClient.BaseAddress = new Uri(queryData.Url);
                }

                if (!string.IsNullOrEmpty(queryData.Credentials))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(Encoding.UTF8.GetBytes(queryData.Credentials)));
                }

                var response = _httpClient.GetAsync(_httpClient.BaseAddress).Result;
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    content = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    //TODO: Need to fix this line after some API calls;
                    content = $"{(int)response.StatusCode} ({response.ReasonPhrase})";
                }

                return content;
            }
            catch (Exception ex)
            {
                //TODO: Add logger and change the returns in somethig more specific than string;
                return ex.Message;
            }
        }

        public string Post(QueryDataJsonBody queryDataJsonBody)
        {
            throw new NotImplementedException();
        }

        public string Put(QueryDataJsonBody queryDataJsonBody)
        {
            throw new NotImplementedException();
        }

        public string Delete(QueryData queryData)
        {
            throw new NotImplementedException();
        }
    }
}
