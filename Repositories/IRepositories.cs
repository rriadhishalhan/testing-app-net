using StreamlitLikeApp.Models;

namespace StreamlitLikeApp.Repositories
{
    public interface IWeatherRepository
    {
        Task<List<WeatherForecast>> GetWeatherForecastAsync();
        Task<WeatherForecast?> GetWeatherByDateAsync(DateTime date);
    }

    public interface IUserRepository
    {
        Task<List<UserData>> GetAllUsersAsync();
        Task<UserData?> GetUserByIdAsync(int id);
        Task<UserData> CreateUserAsync(UserData user);
        Task<UserData?> UpdateUserAsync(int id, UserData user);
        Task<bool> DeleteUserAsync(int id);
    }
}