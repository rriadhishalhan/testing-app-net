namespace StreamlitLikeApp.Models
{
    public class HomeViewModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }

    public class DemoViewModel
    {
        public string UserName { get; set; } = "";
        public double UserAge { get; set; } = 25;
        public string FavoriteColor { get; set; } = "Blue";
        public List<string> ColorOptions { get; set; } = new();
        public List<string> OperationOptions { get; set; } = new();
        public double FirstNumber { get; set; } = 10;
        public double SecondNumber { get; set; } = 5;
        public string SelectedOperation { get; set; } = "Add";
        public int TotalUsers { get; set; } = 0;
        public double AverageAge { get; set; } = 0;
        public string MostPopularColor { get; set; } = "";
    }

    public class WeatherViewModel
    {
        public List<WeatherForecast> Forecasts { get; set; } = new();
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string? Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class UserData
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public int Age { get; set; }
        public string FavoriteColor { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}