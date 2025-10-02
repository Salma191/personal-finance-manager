using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartFinance.Models;
using SmartFinance.Service.Interfaces;

namespace SmartFinance.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICompteService _compteService;

    public HomeController(ILogger<HomeController> logger, ICompteService compteService)
    {
        _logger = logger;
        _compteService = compteService;
    }

    public async Task<IActionResult> Index()
    {
        var soldeTotal = await _compteService.CalculerSoldeGlobal();
        return View(soldeTotal);
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    public IActionResult Dashboard()
    {
        return View();
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
