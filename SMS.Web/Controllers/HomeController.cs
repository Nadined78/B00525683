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

    public IActionResult Index() //using an AboutViewModel 
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
            Title = "About  Management",
            Message = "Our mission here at The Good Food Atlas is to provide a community platform for all things FOOD. Recipes, Flavours, Culture, Cuisine, Language or experiences",
            Formed = new DateTime(2012,08,01)
        };
        return View(about);
    }
    
     public IActionResult Privacy() //using PrivacyViewModel
    {
            
        var privacyMessage = new PrivacyViewModel 
        {
            Title = " Our Privacy Statement",
            Aim = "The Good Food Atlas Website is monitored by Admin. The pivacy of our users is very important to us",
            Formed = new DateTime(2012,08,01),
        };
        return View(privacyMessage);   
    }

    public IActionResult Contact() //using ContactViewModel
    {
        var contactMessage = new ContactViewModel
        {   
            Title = "Do You Need Assistance?",
            Message = "To report any technical issues you can contact us in any of the following ways: ",
            Email = "GFAManagement@mail.com",
            Address = "124 Baronscourt Place, Derry City, BT48 9WQ",
            Phone = 02871319386
        };
        return View(contactMessage);
    }

   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
