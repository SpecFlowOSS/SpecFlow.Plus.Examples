using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace TestApplication.Web
{


    public class KestrelHostBuilder
    {
        public IHostBuilder CreateHostBuilder(string[] args, string hostname = null, string webRoot = null, string assemblyFolder = null)
        {
            var configureWebHostDefaults =
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(
                        webBuilder =>
                        {
                            var appsettingsJsonPath = "appsettings.json";
                            if (!string.IsNullOrWhiteSpace(assemblyFolder))
                            {
                                appsettingsJsonPath = Path.Combine(assemblyFolder, appsettingsJsonPath);
                            }
                            var configuration = new ConfigurationBuilder()
                                .AddCommandLine(args)
                                .AddJsonFile(appsettingsJsonPath, optional: false)
                                .Build();
                            webBuilder.UseConfiguration(configuration);
                            webBuilder.UseKestrel(
                                options =>
                                {
                                    options.Listen(IPAddress.Loopback, configuration.GetValue<int>("Host:Port"),
                                        listenOptions =>
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

                            if (hostname != null)
                            {
                                webBuilder.UseUrls(hostname);
                            }

                            if (webRoot != null)
                            {
                                webBuilder.UseWebRoot(webRoot);
                            }
                        });

            return configureWebHostDefaults;
        }
    }

}