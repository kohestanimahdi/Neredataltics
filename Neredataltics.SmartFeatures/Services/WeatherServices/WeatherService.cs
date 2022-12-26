using Grpc.Net.Client;

namespace Neredataltics.SmartFeatures.Services.WeatherServices
{
    public class WeatherService
    {
        private readonly Shared.WeatherService.WeatherServiceClient _weatherServiceClient;
        public WeatherService(GrpcChannel grpcChannel)
        {
            _weatherServiceClient = new Shared.WeatherService.WeatherServiceClient(grpcChannel);
        }
    }
}
