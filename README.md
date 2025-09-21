# 🚀 Streamlit-like .NET Web App

A .NET web application built with Blazor Server that provides interactive UI components similar to Python's Streamlit library. This project demonstrates how to create data-driven web applications with minimal code using familiar Streamlit-style components.

## ✨ Features

### Interactive Components
- **StTextInput** - Real-time text input with data binding
- **StSlider** - Interactive range slider for numeric input
- **StButton** - Customizable buttons with click events
- **StSelectbox** - Dropdown selection component
- **StMetric** - Display key metrics with delta indicators
- **StChart** - Chart visualization placeholder (ready for Chart.js integration)
- **StContainer** - Organized content containers with titles

### Key Benefits
- 🎯 **Simple API** - Streamlit-like component interface
- ⚡ **Real-time Updates** - Blazor Server provides instant UI updates
- 🔄 **State Management** - Built-in state management service
- 📱 **Responsive Design** - Bootstrap-based responsive components
- 🛠️ **Extensible** - Easy to add new components and features

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

### Basic Text Input
```csharp
<StTextInput Label="Enter your name" 
           Placeholder="Type here..." 
           @bind-Value="userName" />
```

### Interactive Slider
```csharp
<StSlider Label="Select age" 
        Min="0" Max="120" Step="1" 
        @bind-Value="userAge" />
```

### Dropdown Selection
```csharp
<StSelectbox Label="Choose color" 
           Options="@colorOptions" 
           @bind-SelectedValue="selectedColor" />
```

### Metric Display
```csharp
<StMetric Label="Total Users" 
        Value="@totalUsers.ToString()" 
        Delta="+12" 
        DeltaColor="positive" />
```

### Button with Event
```csharp
<StButton Text="Submit" 
        ButtonType="primary" 
        OnClick="ProcessData" />
```

### Container Grouping
```csharp
<StContainer Title="User Input">
    <!-- Your components here -->
</StContainer>
```

## 📊 Demo Application

The project includes a comprehensive demo at `/streamlit-demo` that showcases:

1. **User Input Form** - Text input, sliders, and dropdowns
2. **Live Results Display** - Real-time updates based on user input
3. **Metrics Dashboard** - Key performance indicators with delta changes
4. **Interactive Calculator** - Real-time calculations with sliders
5. **Chart Visualization** - Placeholder for data charts

## 🏗️ Project Structure

```
StreamlitLikeApp/
├── Components/
│   └── StreamlitLike/          # Streamlit-style components
│       ├── StTextInput.razor
│       ├── StSlider.razor
│       ├── StButton.razor
│       ├── StSelectbox.razor
│       ├── StMetric.razor
│       ├── StChart.razor
│       └── StContainer.razor
├── Services/
│   └── StreamlitService.cs     # State management service
├── Pages/
│   ├── Index.razor             # Home page
│   └── StreamlitDemo.razor     # Demo page
├── Shared/                     # Shared components
├── Data/                       # Data services
└── wwwroot/                    # Static files
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