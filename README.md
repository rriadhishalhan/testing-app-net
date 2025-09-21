# 🚀 Streamlit-like .NET Web App (MVC Architecture)

A .NET web application built with ASP.NET Core MVC that provides interactive UI components similar to Python's Streamlit library. This project follows the traditional MVC pattern with Controllers, Views, Models, and Repository pattern for clean separation of concerns.

## ✨ Features

### Interactive Components
- **StTextInput** - Real-time text input with data binding
- **StSlider** - Interactive range slider for numeric input
- **StButton** - Customizable buttons with click events
- **StSelectbox** - Dropdown selection component
- **StMetric** - Display key metrics with delta indicators
- **StChart** - Chart visualization placeholder (ready for Chart.js integration)
- **StContainer** - Organized content containers with titles

### Architecture Benefits
- �️ **MVC Pattern** - Controllers handle HTTP requests, Views render UI, Models manage data
- 📡 **Repository Pattern** - Clean abstraction for data access and API calls
- 🔄 **Dependency Injection** - Proper service registration and injection
- ⚡ **Real-time Updates** - AJAX-powered interactions without page refreshes
- 🎯 **Simple API** - Streamlit-like component interface in Razor views
- 📱 **Responsive Design** - Bootstrap-based responsive components
- 🛠️ **Extensible** - Easy to add new controllers, views, and repositories

## 🚀 Getting Started

### Prerequisites
- .NET 8.0 SDK or later
- Visual Studio 2022 or VS Code
- A modern web browser

### Installation & Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd testing-app-net
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open your browser**
   Navigate to `https://localhost:5001` or `http://localhost:5000`

## 🎮 Usage Examples

### Controller with Repository Pattern
```csharp
[HttpGet]
public async Task<IActionResult> GetWeatherData()
{
    try
    {
        var forecasts = await _weatherRepository.GetWeatherForecastAsync();
        return Json(forecasts);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error fetching weather data");
        return Json(new { error = "Failed to fetch weather data" });
    }
}
```

### Streamlit-like Components in Views
```html
<!-- Text Input -->
<div class="st-input-group">
    <label for="userName" class="form-label">Enter your name</label>
    <input type="text" id="userName" class="form-control" 
           placeholder="Type here..." value="@Model.UserName" />
</div>

<!-- Interactive Slider -->
<div class="st-slider-group">
    <label for="userAge" class="form-label">Age: <span id="ageValue">@Model.UserAge</span></label>
    <input type="range" id="userAge" class="form-range" 
           min="0" max="120" step="1" value="@Model.UserAge" />
</div>

<!-- Metric Display -->
<div class="st-metric-container">
    <div class="metric-card">
        <div class="metric-label">Total Users</div>
        <div class="metric-value">@Model.TotalUsers</div>
        <div class="metric-delta delta-positive">
            <span class="positive">↗️ +12</span>
        </div>
    </div>
</div>
```

### Repository Implementation
```csharp
public class WeatherRepository : IWeatherRepository
{
    private readonly HttpClient _httpClient;
    
    public async Task<List<WeatherForecast>> GetWeatherForecastAsync()
    {
        // Call external API
        var response = await _httpClient.GetAsync("api/weather");
        // Process and return data
        return forecasts;
    }
}
```

## 📊 Demo Application

The project includes comprehensive demos accessible through:

1. **Home Page** (`/`) - Overview and features
2. **Interactive Demo** (`/Home/Demo`) - Streamlit-like UI components with:
   - User input forms with real-time validation
   - Interactive sliders and dropdowns
   - Live calculation results
   - Metrics dashboard with KPIs
   - AJAX-powered updates without page refresh
3. **Weather Demo** (`/Weather`) - Repository pattern demonstration with:
   - External API integration
   - Async data fetching
   - Error handling and loading states
   - Real-time data updates

## 🏗️ Project Structure

```
StreamlitLikeApp/
├── Controllers/                 # MVC Controllers
│   ├── HomeController.cs       # Main app controller
│   └── WeatherController.cs    # Weather data controller
├── Models/                     # Data models and ViewModels
│   └── ViewModels.cs           # View models for data binding
├── Views/                      # Razor views
│   ├── Home/
│   │   ├── Index.cshtml        # Home page
│   │   └── Demo.cshtml         # Streamlit demo page
│   ├── Weather/
│   │   └── Index.cshtml        # Weather with repository demo
│   └── Shared/
│       └── _Layout.cshtml      # Main layout
├── Repositories/               # Repository pattern implementation
│   ├── IRepositories.cs        # Repository interfaces
│   └── Repositories.cs         # Repository implementations
├── Services/                   # Business services
│   └── StreamlitService.cs     # State management service
├── wwwroot/                    # Static files
│   ├── css/
│   │   └── streamlit-components.css  # Streamlit-style CSS
│   └── js/
│       └── streamlit-components.js   # Interactive JavaScript
└── Components/                 # Legacy Blazor components (can be removed)
```

## 🔧 Component API Reference

### StTextInput
- `Label` (string) - Display label
- `Placeholder` (string) - Input placeholder text
- `Value` (string) - Bound value
- `ValueChanged` (EventCallback<string>) - Value change event

### StSlider
- `Label` (string) - Display label
- `Min` (double) - Minimum value
- `Max` (double) - Maximum value
- `Step` (double) - Step increment
- `Value` (double) - Bound value
- `ValueChanged` (EventCallback<double>) - Value change event

### StButton
- `Text` (string) - Button text
- `ButtonType` (string) - Button style (primary, secondary, success, etc.)
- `Icon` (string) - Optional icon class
- `Disabled` (bool) - Disabled state
- `OnClick` (EventCallback) - Click event

### StSelectbox
- `Label` (string) - Display label
- `Options` (IEnumerable<string>) - Available options
- `SelectedValue` (string) - Bound selected value
- `SelectedValueChanged` (EventCallback<string>) - Selection change event

### StMetric
- `Label` (string) - Metric label
- `Value` (string) - Metric value
- `Delta` (string) - Change indicator
- `DeltaColor` (string) - Delta color (normal, positive, negative)
- `Help` (string) - Help text

### StContainer
- `Title` (string) - Container title
- `ChildContent` (RenderFragment) - Container content

## 🛠️ Extending the Library

### Adding New Components

1. Create a new `.razor` file in `Components/StreamlitLike/`
2. Follow the naming convention: `St[ComponentName].razor`
3. Include appropriate styling and parameters
4. Add to the demo page for testing

### State Management

Use the `StreamlitService` for application state:

```csharp
@inject StreamlitService St

// Get state
var value = St.GetState("key", defaultValue);

// Set state
St.SetState("key", value);
```

## 🎨 Customization

### Styling
All components include scoped CSS. Modify component styles directly in the `.razor` files or add global styles in `wwwroot/css/site.css`.

### Themes
Components use Bootstrap classes by default. Customize by:
1. Modifying Bootstrap variables
2. Adding custom CSS classes
3. Creating theme-specific component variants

## 🚀 Deployment

### Local Development
```bash
dotnet run
```

### Production Build
```bash
dotnet publish -c Release
```

### Docker Support
Create a `Dockerfile` for containerized deployment:
```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0
COPY bin/Release/net8.0/publish/ app/
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "StreamlitLikeApp.dll"]
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Add your component or improvement
4. Include tests and documentation
5. Submit a pull request

## 📝 License

This project is licensed under the MIT License - see the LICENSE file for details.

## 🙏 Acknowledgments

- Inspired by [Streamlit](https://streamlit.io/) - The Python library for creating data apps
- Built with [Blazor Server](https://docs.microsoft.com/en-us/aspnet/core/blazor/) - Microsoft's web UI framework
- Styled with [Bootstrap](https://getbootstrap.com/) - Popular CSS framework

## 📞 Support

For questions and support:
- Open an issue on GitHub
- Check the demo application for examples
- Review the component API documentation above

---

**Happy coding! 🎉**