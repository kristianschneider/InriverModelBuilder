using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;

namespace InriverModelBuilder
{
    public class InriverApiConnector
    {
        private const string BaseUrl = "https://apieuw.productmarketingcloud.com";
        private readonly string _apiKey;
        public InriverApiConnector(string apikey)
        {
            _apiKey = apikey;
        }

        public string GetEntityTypesJson()
        {
            const string endpoint = "/api/v1.0.0/model/entitytypes";

            return FetchEndpoint(endpoint);
        }

        private string FetchEndpoint(string endpoint)
        {
            var client = new RestClient($"{BaseUrl}");
            var request = new RestRequest(endpoint, Method.GET);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("X-inRiver-APIKey", _apiKey);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return content;
        }

        public string GetCvls()
        {
            const string endpoint = "/api/v1.0.0/model/cvls";
            return FetchEndpoint(endpoint);

        }
    }
}
