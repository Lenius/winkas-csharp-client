using Newtonsoft.Json;
using RestSharp;

namespace WinKAS.Api
{

    public class Client
    {
        private readonly string _userName;
        private readonly string _userPassword;
        private readonly string _userContractCode;

        public string _token;

        public RestClient ch;

        public Client(string userName = "", string userPassword = "", string userContractCode = "" )
        {
            _userName = userName;
            _userPassword = userPassword;
            _userContractCode = userContractCode;

            this.Authenticate();
        }

        private void Authenticate()
        {
            var auth = JsonConvert.SerializeObject(new
            {
                UserName = _userName,
                UserPassword = _userPassword,
                UserContractCode = _userContractCode
            });

            ch = new RestClient("https://api.winkas.net/api/Authentication/Authenticate");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json; charset=utf-8");
            request.AddParameter("application/json; charset=utf-8",auth,ParameterType.RequestBody);
            IRestResponse response = ch.Execute(request);
            dynamic _jsonContent = JsonConvert.DeserializeObject(response.Content);
            _token = _jsonContent.WinKasData.CurrentToken;

            if (string.IsNullOrEmpty(_token))
            {
                throw new System.Exception("Authentication failed");
            }
        }

        public void Shutdown()
        {
            if (ch!=null)
            {
                ch = null;
            }
        }
    }
}
