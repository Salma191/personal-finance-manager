using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartFinance.Models;
using SmartFinance.Service.Interfaces;
using System.Threading.Tasks;

namespace SmartFinance.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ICompteService _compteService;
        private readonly ICategorieService _categorieService;
        public TransactionController(ITransactionService transactionService, ICompteService compteService, ICategorieService categorieService)
        {
            _transactionService = transactionService;
            _compteService = compteService;
            _categorieService = categorieService;
        }
        public async Task<IActionResult> Index()
        {
            var transactions = await _transactionService.GetTransactionsAsync();
            return View(transactions);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await _categorieService.GetCategoriesAsync(), "Id", "Nom");
            ViewBag.Comptes = new SelectList(await _compteService.GetComptesAsync(), "Id", "Nom");
            ViewBag.TypeTransactions = new SelectList(Enum.GetValues(typeof(TypeTransaction)));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Transaction transaction)
        {
            await _transactionService.AddTransaction(transaction);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var transaction = await _transactionService.GetTransactionAsync(id);
            if (transaction == null) return NotFound();
            ViewBag.Categories = new SelectList(await _categorieService.GetCategoriesAsync(), "Id", "Nom");
            ViewBag.Comptes = new SelectList(await _compteService.GetComptesAsync(), "Id", "Nom");
            ViewBag.TypeTransactions = new SelectList(Enum.GetValues(typeof(TypeTransaction)));
            return View(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Transaction transaction)
        {
            await _transactionService.UpdateTransaction(transaction);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _transactionService.DeleteTransaction(id);
            return RedirectToAction("Index");
        }


    }
}
