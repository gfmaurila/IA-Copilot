using Kit.Consumer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

// Bootstrap logging first, for the same reason as in Kit.Api: a failure while
// building the container must still be visible.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("Confluent.Kafka", LogEventLevel.Error)
    .Enrich.FromLogContext()
    .WriteTo.Console(outputTemplate:
        "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
    .CreateBootstrapLogger();

try
{
    var builder = Host.CreateApplicationBuilder(args);

    builder.Configuration.AddEnvironmentVariables("KIT_");

    builder.Logging.ClearProviders();

    builder.Services.AddSerilog((services, configuration) => configuration
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("Application", "Kit.Consumer")
        .WriteTo.Console(outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}"));

    builder.Services.Configure<KafkaConsumerOptions>(
        builder.Configuration.GetSection(KafkaConsumerOptions.SectionName));

    // Handlers are resolved per event from a scope, so each one may depend on
    // scoped services (a DbContext, a cache, an HTTP client) without sharing
    // state between events.
    builder.Services.AddScoped<IDomainEventHandler, Kit.Consumer.Handlers.SecurityEventAuditHandler>();
    builder.Services.AddScoped<IDomainEventHandler, Kit.Consumer.Handlers.AttentionRequiredHandler>();

    builder.Services.AddSingleton<Microsoft.Extensions.Hosting.BackgroundService>(provider =>
        ActivatorUtilities.CreateInstance<KafkaEventConsumer>(provider));

    var host = builder.Build();

    var messagingEnabled = builder.Configuration.GetValue<bool>($"{KafkaConsumerOptions.SectionName}:Enabled");
    var consumerGroup = builder.Configuration.GetValue<string>($"{KafkaConsumerOptions.SectionName}:ConsumerGroup")
                        ?? "kit-consumer";

    Log.Information(
        "Kit.Consumer iniciado. Messaging habilitado: {MessagingEnabled}. Grupo: {ConsumerGroup}.",
        messagingEnabled,
        consumerGroup);

    await host.RunAsync();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Kit.Consumer terminou com uma falha irrecuperavel.");
    throw;
}
finally
{
    await Log.CloseAndFlushAsync();
}