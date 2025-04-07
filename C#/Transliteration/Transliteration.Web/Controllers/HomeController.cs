using Microsoft.AspNetCore.Mvc;
using Transliteration.Data;
using Transliteration.Data.Models;
using Transliteration.Services.Data.Interfaces;
using Transliteration.Web.ViewModels;

namespace Transliteration.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITransliterationService _transliterationService;

        public HomeController(AppDbContext context, ITransliterationService transliterationService)
        {
            _context = context;
            _transliterationService = transliterationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new NameSearchViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> AddName(string nameOriginal)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var transliterated = _transliterationService.TransliterateCyrToLat(nameOriginal);
            var nameEntry = new NameEntry
            {
                NameOriginal = nameOriginal,
                NameTransliterated = transliterated
            };
            _context.NameEntries.Add(nameEntry);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Името беше успешно добавено!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index");
            }

            LogSearchQuery(query);

            var transliteratedQuery = _transliterationService.TransliterateCyrToLat(query);

            var results = _context.NameEntries
                .Where(n => n.NameOriginal.Contains(query) || n.NameTransliterated.Contains(transliteratedQuery))
                .ToList();

            var model = new NameSearchViewModel
            {
                SearchQuery = query,
                Results = results
            };

            return View("Index", model);
        }

        private void LogSearchQuery(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                var log = new SearchLog
                {
                    Query = query,
                    SearchDate = DateTime.UtcNow
                };

                _context.SearchLogs.Add(log);
                _context.SaveChanges();
            }
        }
    }
}
