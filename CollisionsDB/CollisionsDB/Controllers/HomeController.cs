using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CollisionsDB.Models;
using CollisionsDB.Models.ViewModels;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace CollisionsDB.Controllers
{
    [ApiController]
    [Route("/score")]
    public class InferenceController : ControllerBase
    {
        private InferenceSession _session;

        public InferenceController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public ActionResult Score(HousingData data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<float> score = result.First().AsTensor<float>();
            var prediction = new Prediction { PredictedValue = score.First() * 100000 };
            result.Dispose();
            return Ok(prediction);
        }

    }

    public class HomeController : Controller
    {
        private ICollisionRepository repo { get; set; }

        public HomeController (ICollisionRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Summary(int pageNum = 1)
        {
            int pageSize = 100;

            var x = new CollisionsViewModel
            {
                Collisions = repo.Collisions
                    //.Where(c => c.Category == category || category == null)
                    .OrderBy(c => c.CRASH_SEVERITY_ID)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumCrashes =
                        (repo.Collisions.Count()),
                    CrashesPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            return View(x);
        }
    }
}
