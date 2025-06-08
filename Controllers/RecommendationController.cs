using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using PC4PROGRAMACION.ML;
using PC4PROGRAMACION.Data;
using PC4PROGRAMACION.Models;
using PC4PROGRAMACION.MLRecomendacion;

namespace PC4PROGRAMACION.Controllers
{
    public class RecommendationController : Controller
    {
        private readonly ILogger<RecommendationController> _logger;
        private readonly ApplicationDbContext _context;

        public RecommendationController(ILogger<RecommendationController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

      
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Recommend()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Recommend(float userId)
        {
            // Productos simulados del 101 al 105
            var allProductIds = new List<float> { 101, 102, 103, 104, 105 };

            var recommendations = allProductIds.Select(pid =>
            {
                var input = new MLModelRecomendacion.ModelInput
                {
                    UserId = userId,
                    ProductId = pid
                };

                var result = MLModelRecomendacion.Predict(input);
                return (ProductId: pid, Score: result.Score);
            })
            .OrderByDescending(r => r.Score)
            .Take(5)
            .ToList();

            // Guardar en la base de datos
            foreach (var rec in recommendations)
            {
                var registro = new Recomendacion
                {
                    UserId = userId,
                    ProductId = rec.ProductId,
                    Score = rec.Score
                };

                _context.Recomendaciones.Add(registro);
            }

            _context.SaveChanges();

            var model = new ProductRecommendation
            {
                UserId = userId,
                RecommendedProducts = recommendations
            };

            return View("Index", model);
        }
    }
}