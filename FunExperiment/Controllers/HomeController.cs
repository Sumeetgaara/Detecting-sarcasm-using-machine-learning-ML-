using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FunExperiment.Models;
using MLModelSarcasm;

using Microsoft.ML;

using System.Net.Http;
using System.Threading;

namespace FunExperiment.Controllers
{
    public class HomeController : Controller
    {
		public SarcasmOutput FinalResult  = null;
        public IActionResult Index()
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

		[HttpPost]
		public async Task<JsonResult> SarcasmAsync(string param)
		{
			string result = "No Sarcasm";
			await processingAsync(param);
			if (FinalResult.Result) result = "Sarcasm";
			return Json(result);

		}

		public async Task processingAsync(string param)
		{
			PredictionModel<Sarcasm, SarcasmOutput> model = null;
			if (model == null)
			{
				model = await PredictionModel.ReadAsync<Sarcasm, SarcasmOutput>("Model.zip");
			}
			var predictedSentiment = model.Predict(new Sarcasm() { TitleDescription = param });
			FinalResult = predictedSentiment;
		}
    }
}
