using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojoSurveyClone.Models;

namespace dojoSurveyClone.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public static User FakeUserDb = new();


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {

        return View();
    }

    [HttpPost("process")]
    public IActionResult Process(User NewUser)
    {
        FakeUserDb = NewUser;
        return RedirectToAction("Details");
    }

    [HttpGet("details")]
    public IActionResult Details()
    {

        return View("Details", FakeUserDb);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
