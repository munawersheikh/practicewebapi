namespace PracticeJenkinsAndWebApi
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.55);

        public string? Summary { get; set; }
    }
}
