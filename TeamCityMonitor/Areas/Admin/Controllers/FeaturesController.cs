using System.Web.Mvc;
using BuildMonitor.Models;
using BuildMonitor.Models.Repository;

namespace BuildMonitor.Areas.Admin.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly IFeatureRepository _featureRepository;
        public FeaturesController(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public ActionResult Index()
        {
            var features = _featureRepository.GetAllFeatures();
            return View(features);
        }

        public ActionResult Details(int id)
        {
            var feature = _featureRepository.GetFeature(id);
            return View(feature);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Feature feature)
        {
            _featureRepository.Create(feature);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var feature = _featureRepository.GetFeature(id);
            return View(feature);
        }

        [HttpPost]
        public ActionResult Edit(Feature feature)
        {
            _featureRepository.Update(feature);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var feature = _featureRepository.GetFeature(id);
            return View(feature);
        }

        [HttpPost]
        public ActionResult Delete(Feature feature)
        {
            _featureRepository.Delete(feature);
            return RedirectToAction("Index");
        }
    }
}
