using System.Web.Mvc;
using BuildMonitor.Models;
using BuildMonitor.Models.Entities;

namespace BuildMonitor.Areas.Admin.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly FeatureRepository featuresRepo;

        public FeaturesController()
        {
            featuresRepo = new FeatureRepository();
        }
        //
        // GET: /Admin/Features/

        public ActionResult Index()
        {
            var features = featuresRepo.GetAllFeatures();
            return View(features);
        }

        public ActionResult FeatureDetails(int featureId)
        {
            var feature = featuresRepo.GetFeature(featureId);
            return View(feature);
        }

        public ActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeature(Feature feature)
        {
            var successful = featuresRepo.AddFeature(feature);
            return View();
        }

    }
}
