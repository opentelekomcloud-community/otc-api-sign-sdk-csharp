using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using OpenTelekomCloud.API.Signing.Core;

namespace DEMO
{
  class Program
  {
    static Semaphore semaphore = new Semaphore(0, 1);
    static void Main(string[] args)
    {

      demoAppAsync();

      semaphore.WaitOne();//wait for async function

    }
    private static async void demoAppAsync()
    {
      Signer signer = new Signer
      {
        Key = Environment.GetEnvironmentVariable("OTC_SDK_AK"),
        Secret = Environment.GetEnvironmentVariable("OTC_SDK_SK")
      };

      string subdomainName ="<subdomainid>.apic.eu-de.otc.t-systems.com";

      HttpRequest r = new HttpRequest("POST",
          new Uri($"https://{subdomainName}/app2?query=value"));

      // Invoke api in RELEASE environment
      r.headers.Add("x-stage", "RELEASE");

      // set body and content-type
      r.headers.Add("content-type", "application/json");
      r.body = "{\"a\":1}";

      // sign the request
      HttpRequestMessage req = signer.SignHttp(r);
      HttpClient client = new HttpClient();
      HttpResponseMessage response = await client.SendAsync(req);
      Console.WriteLine((int)response.StatusCode + " " + response.ReasonPhrase);
      string body = await response.Content.ReadAsStringAsync();
      Console.WriteLine(body);
      Console.WriteLine("----------------");
      semaphore.Release();
    }


  }
}
