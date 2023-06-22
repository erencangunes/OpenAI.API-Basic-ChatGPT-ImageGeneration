using OpenAI.API.ImageGeneration;
using OpenAI.API.ImageGeneration.Services;
using OpenAI.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddOpenAIService(settings => settings.ApiKey = ""MY_OPEN_AI_API_KEY"");
        services.AddHostedService<OpenAIImageService>();

    })
    .Build();

await host.RunAsync();
