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

    static void Main(string[] args)
    {
      demoApp();
    }


    private static void demoApp()
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
      HttpWebRequest req = signer.Sign(r);
      try
      {
        var writer = new StreamWriter(req.GetRequestStream());
        writer.Write(r.body);
        writer.Flush();
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        var reader = new StreamReader(resp.GetResponseStream());
        Console.WriteLine(reader.ReadToEnd());
      }
      catch (WebException e)
      {
        HttpWebResponse resp = (HttpWebResponse)e.Response;
        if (resp != null)
        {
          Console.WriteLine((int)resp.StatusCode + " " + resp.StatusDescription);
          var reader = new StreamReader(resp.GetResponseStream());
          Console.WriteLine(reader.ReadToEnd());
        }
        else
        {
          Console.WriteLine(e.Message);
        }
      }
    }

  }
}
