<!-- Use this file to provide workspace-specific custom instructions to Copilot. For more details, visit https://code.visualstudio.com/docs/copilot/copilot-customization#_use-a-githubcopilotinstructionsmd-file -->

## .NET Web App with Streamlit-like UI Components (MVC Architecture)

This project is a .NET web application built with ASP.NET Core MVC that provides interactive UI components similar to Python's Streamlit library. It follows traditional MVC pattern with Controllers, Views, Models, and Repository pattern.

### Project Status
- [x] Verify that the copilot-instructions.md file in the .github directory is created.
- [x] Clarify Project Requirements  
- [x] Scaffold the Project
- [x] Customize the Project
- [x] Install Required Extensions
- [x] Compile the Project
- [x] Create and Run Task
- [x] Launch the Project
- [x] Ensure Documentation is Complete

### Project Requirements
- .NET 8.0 web application with ASP.NET Core MVC
- Interactive UI components similar to Streamlit
- Repository pattern for API calls and data access
- Controllers for HTTP request handling
- Razor views with real-time updates via AJAX
- Form input components and data display widgets

### Development Guidelines
- Use MVC pattern for clean separation of concerns
- Implement Repository pattern for data access
- Follow .NET best practices and dependency injection
- Use AJAX for real-time interactivity without page refresh
- Include responsive design with Bootstrap

### Available Components & Features
- **Controllers:** HomeController, WeatherController with proper dependency injection
- **Repository Pattern:** IWeatherRepository, IUserRepository for clean data access
- **Streamlit-like UI:** HTML/CSS/JS components that mimic Streamlit behavior
- **Views:** Razor views with real-time interactivity via AJAX
- **Models:** ViewModels for data binding and validation
- **Services:** StreamlitService for state management
- **Responsive Design:** Bootstrap-based mobile-friendly interface

### MVC Architecture
- **Controllers handle:** HTTP requests, business logic, API responses
- **Views handle:** UI rendering, user interactions, real-time updates
- **Models handle:** Data validation, view models, business entities
- **Repositories handle:** External API calls, data access, async operations

### How to Run
1. Run `dotnet build` to compile the project
2. Run `dotnet run` to start the development server
3. Open browser to `http://localhost:5029`
4. Navigate to "/Home/Demo" for interactive demo
5. Navigate to "/Weather" for repository pattern demo