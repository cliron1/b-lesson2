using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Website.Models;

namespace Website.Controllers;
public class HomeController : Controller {
    private readonly IConfiguration config;
    private readonly ILogger<HomeController> _logger;

    public HomeController(
        IConfiguration config,
        ILogger<HomeController> logger
    ) {
        this.config = config;
        _logger = logger;
    }

    public IActionResult Index([FromServices] IOptionsSnapshot<CustomSettings> settings) {
        //var appName = config["Custom:AppName"];

        // option 1
        var custom = config.GetSection("Custom").Get<CustomSettings>();
        //return View(custom.Port);

        // option 2
        var custom2 = new CustomSettings();
        config.Bind("Custom", custom2);
        //return View(custom2.Port); 

        var emailSettings = config.GetSection("Custom:Email")
            .Get<EmailSettings>();

        var portAsValueInt = config.GetValue<int>("Custom:Email:Port");

        return View(settings.Value.Port);
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
