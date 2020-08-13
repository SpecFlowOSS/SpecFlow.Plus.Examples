using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TestApplication.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new KestrelHostBuilder().CreateHostBuilder(args).Build().Run();
        }
    }
}
