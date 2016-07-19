using System;
using Newtonsoft.Json;
using RestSharp;

namespace WinKAS.Api
{
    public class Request
    {
        private readonly Client _client;

        public Request(Client client)
        {
            _client = client;
        }

        public Response Get(string path,string parms = null)
        {
            SetUrl(path);
            return Exec(Method.GET);
        }

        public Response Post(string path, string parms = null)
        {
            SetUrl(path);
            return Exec(Method.POST, parms);
        }

        public Response Put(string path, string parms = null)
        {
            SetUrl(path);
            return Exec(Method.PUT, parms);
        }

        public Response Patch(string path, string parms = null)
        {
            SetUrl(path);
            return Exec(Method.PATCH, parms);
        }

        public Response Delete(string path, string parms = null)
        {
            SetUrl(path);
            return Exec(Method.DELETE, parms);
        }

        private Response Exec(Method method,object parms = null)
        {
            var request = new RestRequest(method);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json; charset=utf-8");

            var auth = JsonConvert.SerializeObject(new
            {
                Token = this._client._token
            });

            request.AddParameter("application/json; charset=utf-8", auth, ParameterType.RequestBody);

            IRestResponse response = this._client.ch.Execute(request);
            dynamic jsonContent = JsonConvert.DeserializeObject(response.Content);

            return new Response(response.StatusCode,jsonContent,new WinkasResponse
            {
                WinKasMessage = jsonContent.WinKasMessage,
                ApiVersion = jsonContent.ApiVersion,
                WinkasErrorCode = jsonContent.WinkasErrorCode,
                WinKasStatus = jsonContent.WinKasStatus,
                WinKasStatusString = jsonContent.WinKasStatusString,
                ResponseDateTime = jsonContent.ResponseDateTime,
                ElapsedSeconds = jsonContent.ResponseInfo.ElapsedSeconds,
                ServerName = jsonContent.ResponseInfo.ServerName
            });
        }

        protected void SetUrl(string path)
        {
            _client.ch.BaseUrl = new Uri(Constants.ApiUrl + path);
        }

    }
}