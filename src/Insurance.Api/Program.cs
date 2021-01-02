using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Insurance.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                //logger creation
                var projectDirctoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
                var insuranceLoggerFilePath = Path.Combine(projectDirctoryPath, "InsuranceLogger.txt");
                Log.Logger = new LoggerConfiguration()
                    .WriteTo
                    .File(insuranceLoggerFilePath, rollingInterval: RollingInterval.Day)
                    .CreateLogger();

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
