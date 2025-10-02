using Microsoft.AspNetCore.Mvc;
using SmartFinance.Service.Interfaces;
using SmartFinance.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartFinance.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IBudgetService _budgetService;
        private readonly ICategorieService _categorieService;
        public BudgetController(IBudgetService budgetService, ICategorieService categorieService)
        {
            _budgetService = budgetService;
            _categorieService = categorieService;
        }
        public async Task<IActionResult> Index()
        {
            var Budgets = await _budgetService.GetBudgets();
            return View(Budgets);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categorieService.GetCategoriesAsync(), "Id", "Nom");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Budget budget)
        {
            await _budgetService.DefineBudget(budget);
            return RedirectToAction("Index");
        }
    }
}
