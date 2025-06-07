using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PC4PROGRAMACION.Models;
using PC4PROGRAMACION.ML;
using PC4PROGRAMACION.Data;

namespace PC4PROGRAMACION.Controllers
{
   
    public class SentimentController : Controller
    {
        private readonly ILogger<SentimentController> _logger;
        private readonly ApplicationDbContext _context;

        public SentimentController(ILogger<SentimentController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SentimentModel SentimentModel)
        {
            if (SentimentModel.Mensaje == null || SentimentModel.Mensaje.Trim() == "")
            {
                ModelState.AddModelError("Mensaje", "El mensaje no puede estar vacío.");
                return View("Index");
            }

            // Aquí puedes realizar el análisis de sentimiento del mensaje
            var sampleData = new MLModelSentimentalAnalysis.ModelInput()
            {
                Comentario = SentimentModel.Mensaje,
            };

            //Load model and predict output
            var result = MLModelSentimentalAnalysis.Predict(sampleData);
            var predictedLabel = result.PredictedLabel;
            var scorePositive = result.Score[0];
            var scoreNegative = result.Score[1];
            //Check if the result is positive or negative
            if (predictedLabel == "1")
            {
                SentimentModel.Prediction = "Positivo";
                SentimentModel.Score = scorePositive;
            }
            else
            {
                SentimentModel.Prediction = "Negativo";
                SentimentModel.Score = scoreNegative;
            }

            _context.Sentimiento.Add(SentimentModel);
            await _context.SaveChangesAsync();

            return View("Index", SentimentModel);
        }
            
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}