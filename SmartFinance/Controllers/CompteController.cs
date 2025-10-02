using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartFinance.Models;
using SmartFinance.Service.Interfaces;
using System.Threading.Tasks;

namespace SmartFinance.Controllers
{
    public class CompteController : Controller
    {
        private readonly ICompteService _compteService;
        public CompteController(ICompteService compteService) {
            _compteService = compteService;
        }
        public async Task<IActionResult> Index()
        {
            var comptes = await _compteService.GetComptesAsync();
            return View(comptes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var Compte = await _compteService.GetCompteAsync(id);
            if (Compte == null) return NotFound();
            return View(Compte);
        }

        public async Task<IActionResult> SoldeGlobal()
        {
            var solde = await _compteService.CalculerSoldeGlobal();
            ViewBag.SoldeGlobal = solde;
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.TypeCompte = new SelectList(Enum.GetValues(typeof(TypeCompte)));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Compte compte)
        {
            await _compteService.AddCompteAsync(compte);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var compte = await _compteService.GetCompteAsync(id);
            if (compte == null) return NotFound();
            ViewBag.TypeCompte = new SelectList(Enum.GetValues(typeof(TypeCompte)));
            return View(compte);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Compte compte)
        {
            await _compteService.UpdateCompteAsync(compte);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _compteService.DeleteCompteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
