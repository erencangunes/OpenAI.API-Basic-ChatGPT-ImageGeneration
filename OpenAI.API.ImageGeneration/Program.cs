using OpenAI.API.ImageGeneration;
using OpenAI.API.ImageGeneration.Services;
using OpenAI.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = "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");
        services.AddHostedService<OpenAIImageService>();

    })
    .Build();

await host.RunAsync();
