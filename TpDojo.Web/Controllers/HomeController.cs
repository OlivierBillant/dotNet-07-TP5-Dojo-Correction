namespace TpDojo.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TpDojo.Web.Extensions;
using TpDojo.Web.Models;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) => this._logger = logger;

    public IActionResult Index()
    {

        /*var dateAout = Extensions.Août(31, 2022);

        var newDateAout = 31.Août(2022);*/


        return this.View();
    }

    public IActionResult Privacy()
    {
        return this.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
