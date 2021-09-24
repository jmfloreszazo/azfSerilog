using azfSerilog;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

[assembly: FunctionsStartup(typeof(Startup))]

namespace azfSerilog
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //TODO use with configuration file
            var logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: "{Timestamp} [{Level}] {Message}{NewLine:1}")
                .WriteTo.File("Logs\\log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.ApplicationInsights("d3a662d3-58ae-4c8d-83ba-fddf6648695d", TelemetryConverter.Traces)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithProcessId()
                .Enrich.WithThreadId()
                .CreateLogger();
            builder.Services.AddLogging(lb => lb.AddSerilog(logger));
        }
    }
}