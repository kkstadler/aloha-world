using AlohaWorld.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlohaWorld.Controllers;

public class DashboardController : Controller
{
    private readonly DashboardDataService _data;

    public DashboardController(DashboardDataService data)
    {
        _data = data;
    }

    public IActionResult Index()
    {
        var model = _data.BuildDashboard();
        return View(model);
    }

    // Toggle travel alerts off to demonstrate conditional rendering
    public IActionResult IndexNoAlerts()
    {
        var model = _data.BuildDashboard();
        model.TravelAlerts = null;
        return View("Index", model);
    }
}
