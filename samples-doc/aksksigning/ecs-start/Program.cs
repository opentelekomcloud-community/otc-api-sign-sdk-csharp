using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading;
using OTC_API_SIGN_SDK;

namespace DEMO
{
  class Program
  {
    static Semaphore semaphore = new Semaphore(0, 1);
    static void Main(string[] args)
    {
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

      startECSAsync();
      semaphore.WaitOne();//wait for async function

      startECS();
    }

    private static async void startECSAsync()
    {
      Signer signer = new Signer();

      signer.Key = Environment.GetEnvironmentVariable("OTC_SDK_AK");
      signer.Secret = Environment.GetEnvironmentVariable("OTC_SDK_SK");


      string projectID = Environment.GetEnvironmentVariable("OTC_SDK_PROJECTID");
      string serverID = Environment.GetEnvironmentVariable("ECS_INSTANCE_ID");

      string ecs_endpoint = "ecs.eu-de.otc.t-systems.com";

      HttpRequest r = new HttpRequest("POST",
          new Uri("https://" + ecs_endpoint + "/v1/" + projectID + "/cloudservers/action"));

      r.headers.Add("X-Project-Id", projectID);

      r.headers.Add("Content-Type", "application/json");

      r.body = "{\"os-start\": {\"servers\": [ {\"id\": \"" + serverID + "\"}]}}";

      HttpRequestMessage req = signer.SignHttp(r);
      HttpClient client = new HttpClient();
      HttpResponseMessage response = await client.SendAsync(req);
      Console.WriteLine((int)response.StatusCode + " " + response.ReasonPhrase);
      string body = await response.Content.ReadAsStringAsync();
      Console.WriteLine(body);
      Console.WriteLine("----------------");
      semaphore.Release();
    }

    private static void startECS()
    {
      Signer signer = new Signer();

      signer.Key = Environment.GetEnvironmentVariable("OTC_SDK_AK");
      signer.Secret = Environment.GetEnvironmentVariable("OTC_SDK_SK");

      string projectID = Environment.GetEnvironmentVariable("OTC_SDK_PROJECTID");
      string serverID = Environment.GetEnvironmentVariable("ECS_INSTANCE_ID");

      string ecs_endpoint = "ecs.eu-de.otc.t-systems.com";

      HttpRequest r = new HttpRequest("POST",
          new Uri("https://" + ecs_endpoint + "/v1/" + projectID + "/cloudservers/action"));

      r.headers.Add("X-Project-Id", projectID);
      r.headers.Add("Content-Type", "application/json;charset=utf8");
      r.body = "{\"os-start\": {\"servers\": [ {\"id\": \"" + serverID + "\"}]}}";


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
      Console.WriteLine("----------------");
    }


  }
}
