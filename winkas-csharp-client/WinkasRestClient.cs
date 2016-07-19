using WinKAS.Api;

namespace WinKAS.Api
{
	public class WinkasRestClient
    {
        public Request Request;

        public WinkasRestClient(string userName = "", string userPassword = "", string userContractCode = "")
        {
            var client = new Client(userName, userPassword, userContractCode);
            this.Request = new Request(client);
        }
    }
}
