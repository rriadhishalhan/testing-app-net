using Microsoft.AspNetCore.Mvc;
using StreamlitLikeApp.Repositories;
using StreamlitLikeApp.Models;
using StreamlitLikeApp.Services;

namespace StreamlitLikeApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StreamlitService _streamlitService;

        public HomeController(ILogger<HomeController> logger, StreamlitService streamlitService)
        {
            _logger = logger;
            _streamlitService = streamlitService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Title = "Welcome to Streamlit-like .NET App",
                Description = "Build interactive web applications with .NET MVC, similar to Python's Streamlit"
            };
            return View(model);
        }

        public IActionResult Demo()
        {
            var model = new DemoViewModel
            {
                UserName = _streamlitService.GetState("userName", ""),
                UserAge = _streamlitService.GetState("userAge", 25.0),
                FavoriteColor = _streamlitService.GetState("favoriteColor", "Blue"),
                ColorOptions = new List<string> { "Red", "Blue", "Green", "Yellow", "Purple", "Orange" },
                OperationOptions = new List<string> { "Add", "Subtract", "Multiply", "Divide" },
                FirstNumber = 10,
                SecondNumber = 5,
                SelectedOperation = "Add",
                TotalUsers = 156,
                AverageAge = 32.4,
                MostPopularColor = "Blue"
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitUserData(string userName, double userAge, string favoriteColor)
        {
            // Save to state management
            _streamlitService.SetState("userName", userName);
            _streamlitService.SetState("userAge", userAge);
            _streamlitService.SetState("favoriteColor", favoriteColor);

            // Return JSON response for AJAX calls
            return Json(new { 
                success = true, 
                message = "Data saved successfully",
                userName = userName,
                userAge = userAge,
                favoriteColor = favoriteColor
            });
        }

        [HttpPost]
        public IActionResult Calculate(double firstNumber, double secondNumber, string operation)
        {
            double result = operation switch
            {
                "Add" => firstNumber + secondNumber,
                "Subtract" => firstNumber - secondNumber,
                "Multiply" => firstNumber * secondNumber,
                "Divide" => secondNumber != 0 ? firstNumber / secondNumber : 0,
                _ => 0
            };

            return Json(new { 
                result = result,
                operation = GetOperationSymbol(operation),
                firstNumber = firstNumber,
                secondNumber = secondNumber
            });
        }

        private string GetOperationSymbol(string operation)
        {
            return operation switch
            {
                "Add" => "+",
                "Subtract" => "-",
                "Multiply" => "×",
                "Divide" => "÷",
                _ => "+"
            };
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}