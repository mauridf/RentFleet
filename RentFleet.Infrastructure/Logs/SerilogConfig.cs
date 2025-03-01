using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace RentFleet.Infrastructure.Logs
{
    public static class SerilogConfig
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = "rentfleet-logs-{0:yyyy.MM.dd}"
                })
                .WriteTo.File(
                    path: "logs/rentfleet-log-.txt", // Caminho do arquivo de log
                    rollingInterval: RollingInterval.Day, // Cria um arquivo por dia
                    retainedFileCountLimit: 7, // Mantém os últimos 7 arquivos
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
                )
                .CreateLogger();
        }
    }
}