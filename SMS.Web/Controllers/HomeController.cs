using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SMS.Web.ViewModels;

namespace SMS.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() //using AboutViewModel 
    {
        var homeMessage = new AboutViewModel {      
                Title = "Welcome to the Good Food Atlas",
                Message = "Connecting Food Lovers World-Wide bi bi-globe2 ",
            };
            return View(homeMessage);
    }

    public IActionResult About() //using AboutViewModel
    {
        var about = new AboutViewModel {
            Title = "About Us at The Good Food Atlas",
            Message = "Our mission here at The Good Food Atlas is to provide a community platform for all things FOOD. Recipes, Flavours, Culture, Cuisine, Language or experiences. ",
        };
        return View(about);
    }
    
     public IActionResult Privacy() //using PrivacyViewModel
    {
            
        var privacyMessage = new PrivacyViewModel 
        {
            Title = " Our Privacy Statement",
            Aim = "This web application is monitored by an Administrator at The Good Food Atlas. The privacy of our users is extremely important to us therefore, we encourage all users to read our privacy policy carefully",
        };
        return View(privacyMessage);   
    }

    public IActionResult Contact() //using ContactViewModel
    {
        var contactMessage = new ContactViewModel
        {   
            Title = "Do You Need Assistance?",
            Message = "Please use the form below for an queries",
        };
        return View(contactMessage);
    }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
