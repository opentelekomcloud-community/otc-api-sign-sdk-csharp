using System;
using System.Collections.Generic;
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
      startECSSync();
    }

    private static async void startECSSync()
    {

      // Generate a new signer and enter the configured environment variables
      Signer signer = new Signer();

      // Directly writing AK/SK in code is risky.
      // For security, encrypt your AK/SK and store them in the configuration file or
      // environment variables.
      // In this example, the AK/SK are stored in environment variables for identity 
      // authentication. Before running this example, 
      // set environment variables OTC_SDK_AK and OTC_SDK_SK.
      signer.Key = Environment.GetEnvironmentVariable("OTC_SDK_AK");
      signer.Secret = Environment.GetEnvironmentVariable("OTC_SDK_SK");

      // get project id
      string projectID = Environment.GetEnvironmentVariable("OTC_SDK_PROJECTID");

      // get the id of the ECS instance to be started
      string serverID = Environment.GetEnvironmentVariable("ECS_INSTANCE_ID");

      string ecs_endpoint = "ecs.eu-de.otc.t-systems.com";

      // Generate a new request, and specify the domain name, method, request URI, 
      // and body.
      // The following example demonstrates how to start an ECS instance.

      HttpRequest r = new HttpRequest("POST",
          new Uri("https://" + ecs_endpoint + "/v1/" + projectID + "/cloudservers/action"));

      // Add other headers required for request signing or other purposes.
      // For example, add the 
      // - x-stage header for API environment, 
      // - X-Project-Id header in multi-project scenarios or
      // - X-Domain-Id header for a global service.
      r.headers.Add("X-Project-Id", projectID);

      // content-type is required for POST and PUT requests
      r.headers.Add("Content-Type", "application/json;charset=utf8");

      // add the request body. The body must be in JSON format and follow the API specification.
      r.body = "{\"os-start\": {\"servers\": [ {\"id\": \"" + serverID + "\"}]}}";

      HttpWebRequest req = signer.Sign(r);
      try
      {
        var writer = new StreamWriter(req.GetRequestStream());
        writer.Write(r.body);
        writer.Flush();
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        var reader = new StreamReader(resp.GetResponseStream());
        Console.WriteLine((int)resp.StatusCode + " " + resp.StatusDescription);
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
