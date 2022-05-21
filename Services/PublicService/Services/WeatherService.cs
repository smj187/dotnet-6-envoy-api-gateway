namespace PublicService.Services
{
    public class WeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly string _weather;

        public WeatherService()
        {
            _weather = Summaries[Random.Shared.Next(Summaries.Length)];
        }

        public string GetWeather() => _weather;
    }
}