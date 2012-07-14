using System.Web.Mvc;
using BuildMonitor.Models.Repository;

namespace BuildMonitor.Models
{
    public static class FeatureSwitchExtension
    {
        public static bool FeatureSwitchEnabled(this HtmlHelper helper, string featureName)
        {
            var featureManager = new FeatureRepository();
            var feature = featureManager.GetFeature(featureName);

            return feature.Enabled;
        }
    }
}