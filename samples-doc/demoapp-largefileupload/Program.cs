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
      demoAppLargeFileUpload();
    }


    private static void demoAppLargeFileUpload()
    {
      string filename = "example.rar";
      if (!File.Exists(filename))
      {
        Console.WriteLine("file not found");
        return;
      }
      Signer signer = new Signer
      {
        Key = Environment.GetEnvironmentVariable("OTC_SDK_AK"),
        Secret = Environment.GetEnvironmentVariable("OTC_SDK_SK")
      };

      string subdomainName = "<subdomainid>.apic.eu-de.otc.t-systems.com";

      HttpRequest r = new HttpRequest("POST",
          new Uri($"https://{subdomainName}/app2?query=value"));

      // Invoke api in RELEASE environment
      r.headers.Add("x-stage", "RELEASE");

      // set x-sdk-content-sha256 header for large file upload.
      // The value of the header is the SHA256 hash of the file content in hex format.
      string hash = Signer.HexEncodeSHA256HashFile(filename);
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
