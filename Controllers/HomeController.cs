using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using SpinutechAssessment.Models;

namespace SpinutechAssessment.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", true);
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Exercise1(ExercisesViewModel exercise1)
    {
        decimal input;  decimal.TryParse(exercise1.Input, out input);
        exercise1.Output = Utils.NumberToWords(input);
        return View("Index", exercise1);
    }

    public IActionResult Exercise6(ExercisesViewModel exercise6)
    {
        if (exercise6.Input!=null)
        {
            string input = exercise6.Input;
            string reverse = ""; string ret = $"{input} is not a palindrome";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reverse += input.Substring(i, 1);
            }

            if (!string.IsNullOrEmpty(reverse))
                if (reverse.Equals(input)) ret = $"{input} is a palindrome";

            exercise6.Output = ret;
        }

        return View("Exercise6", exercise6);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
