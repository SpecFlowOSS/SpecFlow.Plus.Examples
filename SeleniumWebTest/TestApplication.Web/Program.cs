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
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var configureWebHostDefaults =
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(
                        webBuilder =>
                        {
                            var configuration = new ConfigurationBuilder()
                                                .AddCommandLine(args)
                                                .AddJsonFile("appsettings.json", optional: false)
                                                .Build();
                            webBuilder.UseConfiguration(configuration);
                            webBuilder.UseKestrel(
                                options =>
                                {
                                    options.Listen(IPAddress.Loopback, configuration.GetValue<int>("Host:Port"), listenOptions =>
                                    {
                                        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                                        listenOptions.UseHttps();
                                    });
                                    options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                                    {
                                        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                                        listenOptions.UseHttps();
                                    });
                                    options.Listen(IPAddress.Loopback, 5000, listenOptions =>
                                    {
                                        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                                        listenOptions.UseHttps();
                                    });
                                });
                            webBuilder.UseStartup<Startup>();
                        });

            return configureWebHostDefaults;
        }
    }
}
