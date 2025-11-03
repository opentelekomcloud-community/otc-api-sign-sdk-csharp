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

      demoAppLargeFileUpload();
    }
    

    private static void demoAppLargeFileUpload()
    {
      String filename = "example.rar";
      if (!File.Exists(filename))
      {
        Console.WriteLine("file not found");
        return;
      }
      Signer signer = new Signer();

      signer.Key = Environment.GetEnvironmentVariable("OTC_SDK_AK");
      signer.Secret = Environment.GetEnvironmentVariable("OTC_SDK_SK");

      HttpRequest r = new HttpRequest("POST",
          new Uri("https://<ENDPOINT>/app2?query=value"));

      r.headers.Add("x-stage", "RELEASE");
      String hash = Signer.HexEncodeSHA256HashFile(filename);
      r.headers.Add("x-sdk-content-sha256", hash);

      HttpWebRequest req = signer.Sign(r);
      Console.WriteLine(req.Headers.GetValues("x-sdk-date")[0]);
      Console.WriteLine(string.Join(", ", req.Headers.GetValues("authorization")));
      var writer = new BinaryWriter(req.GetRequestStream());
      FileStream fs = new FileStream(filename, FileMode.Open);
      int len = 4096;
      byte[] buffer = new byte[len];
      while (true)
      {
        int readLen = fs.Read(buffer, 0, len);
        if (readLen == 0)
        {
          break;
        }
        writer.Write(buffer, 0, readLen);
      }
      fs.Dispose();
      writer.Flush();
      try
      {
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
