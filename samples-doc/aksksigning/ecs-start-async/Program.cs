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
    static Semaphore semaphore = new Semaphore(0, 1);
    static void Main(string[] args)
    {
      startECSAsync();
      semaphore.WaitOne();//wait for async function to complete before exiting the program, otherwise the program may exit before the response is received and printed.
    }

    private static async void startECSAsync()
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

      string serverID = Environment.GetEnvironmentVariable("ECS_INSTANCE_ID");

      // get the id of the ECS instance to be started
      string ecs_endpoint = "ecs.eu-de.otc.t-systems.com";

      HttpRequest r = new HttpRequest("POST",
          new Uri("https://" + ecs_endpoint + "/v1/" + projectID + "/cloudservers/action"));

      // Add other headers required for request signing or other purposes.
      // For example, add the 
      // - x-stage header for API environment, 
      // - X-Project-Id header in multi-project scenarios or
      // - X-Domain-Id header for a global service.

      r.headers.Add("X-Project-Id", projectID);

      // content-type is required for POST and PUT requests
      r.headers.Add("Content-Type", "application/json");

      // add the request body. The body must be in JSON format and follow the API specification.
      r.body = "{\"os-start\": {\"servers\": [ {\"id\": \"" + serverID + "\"}]}}";

      HttpRequestMessage req = signer.SignHttp(r);
      try
      {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.SendAsync(req);
        Console.WriteLine((int)response.StatusCode + " " + response.ReasonPhrase);
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseBody);
      }
      catch (HttpRequestException e)
      {
        Console.WriteLine("Request error: " + e.Message);
      }
      finally
      {
        semaphore.Release();
      }
    }

  }
}
