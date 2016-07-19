using System.Net;

namespace WinKAS.Api
{
    public class Response
    {
        public readonly HttpStatusCode Code;
        public readonly dynamic Content;
        public readonly WinkasResponse Winkas;

        public Response(HttpStatusCode code, dynamic jsonContent, WinkasResponse winkas)
        {
            Code = code;
            Content = jsonContent;
            Winkas = winkas;
        }
    }

    public class WinkasResponse
    {
        public string WinKasMessage { get; set; }
        public string ApiVersion { get; set; }
        public string WinkasErrorCode { get; set; }
        public string WinKasStatus { get; set; }
        public string WinKasStatusString { get; set; }
        public string ResponseDateTime { get; set; }
        public string ElapsedSeconds { get; set; }
        public string ServerName { get; set; }
    }
}