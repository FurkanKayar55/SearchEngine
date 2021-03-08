using Helper.Interfaces;
using RestSharp;
using System;
using System.Net;

namespace Helper
{
    public class RequestService : IRequestService
    {
        private readonly string _url = string.Empty;
        public readonly int _num;

        public RequestService(string url, int num)
        {
            _url = url;
            _num = num;
        }

        public string SendRequest<T>(object data)
        {
            try
            {
                string _apiUrl = "";
                var request = new RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json");
                var queryProp = data.GetType().GetProperty("Query");
                object val = queryProp.GetValue(data, null);
                if (val != null)
                {
                    _apiUrl = _url + string.Format("?num={0}&q={1}", _num, val.ToString().Replace(" ", "+"));
                }
                var client = new RestClient(_apiUrl);
                var result = client.Execute<T>(request);
                if (result.StatusCode == HttpStatusCode.OK) return result.Content;
                else return result.StatusDescription;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}