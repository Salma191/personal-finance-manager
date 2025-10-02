using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartFinance.Models;
using SmartFinance.Service.Interfaces;

namespace SmartFinance.Controllers
{
    public class CategorieController : Controller
    {
        private readonly ICategorieService _categorieService;
        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categorieService.GetCategoriesAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Parent = new SelectList(await _categorieService.GetCategoriesAsync(), "Id", "Nom");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categorie categorie)
        {
            await _categorieService.AddCategorieAsync(categorie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categorie = await _categorieService.GetCategorieAsync(id);
            if (categorie == null) return NotFound();
            return View(categorie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categorie categorie) 
        {
            await _categorieService.UpdateCategorieAsync(categorie);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categorieService.DeleteCategorieAsync(id);
            return RedirectToAction("Index");
        }

    }

}