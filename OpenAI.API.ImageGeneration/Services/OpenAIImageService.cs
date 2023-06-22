using OpenAI.Interfaces;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels.ResponseModels;
using OpenAI.ObjectModels.ResponseModels.ImageResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.API.ImageGeneration.Services
{
    internal class OpenAIImageService : BackgroundService
    {
        readonly IOpenAIService _openAIService;

        public OpenAIImageService(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.Write("::");
                ImageCreateResponse result = await _openAIService.Image.CreateImage(new ImageCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    N = 2,
                    Size = StaticValues.ImageStatics.Size.Size256,
                    ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,
                    User = "test"
                });

                Console.WriteLine(string.Join("\n", result.Results.Select(r => r.Url)));
            }
        }
    }
}
