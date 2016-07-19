Winkas CSHARP REST CLIENT
======================

http://winkas.dk/developer-network/winkas-creditiel-system/

UNDER DEVELOPMENT - DONT USE


### Access Notifications/AllNotApproved

```csharp
var client = new WinkasRestClient("user","password","agrement");

var data = client.Request.Post("Notifications/AllNotApproved");

if (data.Code == HttpStatusCode.OK)
{
    foreach (var demo in data.Content.Notifications)
    {
        System.Console.WriteLine(demo);
    }

    System.Console.Read();
}

```