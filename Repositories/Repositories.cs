using StreamlitLikeApp.Models;
using System.Text.Json;

namespace StreamlitLikeApp.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherRepository> _logger;

        // Sample data for demo purposes
        private static readonly string[] Summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherRepository(HttpClient httpClient, ILogger<WeatherRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<WeatherForecast>> GetWeatherForecastAsync()
        {
            try
            {
                // In a real app, this would call an external API
                // For demo, we'll generate sample data
                await Task.Delay(100); // Simulate API call delay

                var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();

                return forecasts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weather forecast");
                return new List<WeatherForecast>();
            }
        }

        public async Task<WeatherForecast?> GetWeatherByDateAsync(DateTime date)
        {
            try
            {
                // Simulate API call
                await Task.Delay(50);

                return new WeatherForecast
                {
                    Date = date,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weather for date {Date}", date);
                return null;
            }
        }
    }

    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<UserRepository> _logger;
        
        // In-memory storage for demo (in real app, this would be a database)
        private static readonly List<UserData> _users = new();
        private static int _nextId = 1;

        public UserRepository(HttpClient httpClient, ILogger<UserRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<UserData>> GetAllUsersAsync()
        {
            try
            {
                // In a real app, this could call an external API or database
                await Task.Delay(50); // Simulate async operation
                return _users.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all users");
                return new List<UserData>();
            }
        }

        public async Task<UserData?> GetUserByIdAsync(int id)
        {
            try
            {
                await Task.Delay(25);
                return _users.FirstOrDefault(u => u.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching user with ID {UserId}", id);
                return null;
            }
        }

        public async Task<UserData> CreateUserAsync(UserData user)
        {
            try
            {
                await Task.Delay(50);
                
                user.Id = _nextId++;
                user.CreatedAt = DateTime.UtcNow;
                _users.Add(user);
                
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
                throw;
            }
        }

        public async Task<UserData?> UpdateUserAsync(int id, UserData user)
        {
            try
            {
                await Task.Delay(50);
                
                var existingUser = _users.FirstOrDefault(u => u.Id == id);
                if (existingUser == null) return null;

                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Age = user.Age;
                existingUser.FavoriteColor = user.FavoriteColor;

                return existingUser;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user with ID {UserId}", id);
                return null;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                await Task.Delay(25);
                
                var user = _users.FirstOrDefault(u => u.Id == id);
                if (user == null) return false;

                _users.Remove(user);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user with ID {UserId}", id);
                return false;
            }
        }
    }
}