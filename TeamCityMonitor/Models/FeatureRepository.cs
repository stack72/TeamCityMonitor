using System.Collections.Generic;
using System.Linq;
using BuildMonitor.Models.Entities;

namespace BuildMonitor.Models
{
    public class FeatureRepository
    {
        public List<Feature> GetAllFeatures()
        {
            var featureList = new List<Feature>();
            using (var context = new ApplicationDataEntities())
            {
                var features = context.FeatureSwitches;
                featureList.AddRange(features.Select(feature => new Feature
                                                                    {
                                                                        Enabled = feature.Enabled, FeatureName = feature.FeatureName, FeatureSwitchId = feature.FeatureSwitchId
                                                                    }));
            }
            return featureList;
        }

        public Feature GetFeature(int featureId)
        {
            var feature = new Feature();
            using (var context = new ApplicationDataEntities())
            {
                var dbFeature = context.FeatureSwitches.FirstOrDefault(x => x.FeatureSwitchId == featureId);
                feature.Enabled = dbFeature.Enabled;
                feature.FeatureName = dbFeature.FeatureName;
                feature.FeatureSwitchId = dbFeature.FeatureSwitchId;
            }
            return feature;
        }

        public bool AddFeature(Feature feature)
        {
            try
            {
                using (var context = new ApplicationDataEntities())
                {
                    var features = context.FeatureSwitches;
                    features.Attach(new FeatureSwitch
                                        {
                                            Enabled = feature.Enabled,
                                            FeatureName = feature.FeatureName,
                                            FeatureSwitchId = feature.FeatureSwitchId
                                        });
                    context.SaveChanges();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}