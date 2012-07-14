using System.Collections.Generic;
using System.Web;
using Simple.Data;

namespace BuildMonitor.Models.Repository
{
    public interface IFeatureRepository
    {
        List<Feature> GetAllFeatures();
        Feature GetFeature(int featureId);
        Feature GetFeature(string featureName);
        void Create(Feature feature);
        void Update(Feature feature);
        void Delete(Feature feature);
    }

    public class FeatureRepository : IFeatureRepository
    {
        private static dynamic GetDatabase()
        {
            var dbFile = HttpContext.Current.Server.MapPath("~/App_Data/ApplicationData.db");
            var db = Database.OpenFile(dbFile);

            return db;
        }

        public List<Feature> GetAllFeatures()
        {
            var features = new List<Feature>();
            var queryResponse =  GetDatabase().Feature.All();
            foreach (var response in queryResponse)
            {
                features.Add(new Feature
                                 {
                                     Enabled = response.Enabled,
                                     FeatureId = response.FeatureId,
                                     FeatureName = response.FeatureName
                                 });
            }
            return features;
        }

        public Feature GetFeature(int featureId)
        {
            return GetDatabase().Feature.FindByFeatureId(featureId);
        }

        public Feature GetFeature(string featureName)
        {
            return GetDatabase().Feature.FindByFeatureName(featureName);
        }

        public void Create(Feature feature)
        {
            GetDatabase().Feature.Insert(FeatureName: feature.FeatureName, Enabled: feature.Enabled);
        }
    
        public void Update(Feature feature)
        {
            GetDatabase().Feature.Update(feature);
        }
        
        public void Delete(Feature feature)
        {
            GetDatabase().Feature.Delete(FeatureId: feature.FeatureId);
        }
    }
}