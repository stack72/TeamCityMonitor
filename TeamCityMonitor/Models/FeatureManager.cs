using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using BuildMonitor.Models.Entities;
using Simple.Data;

namespace BuildMonitor.Models
{
    public interface IFeatureManager
    {
        string GetSwitchSetting(string featureName);
        bool IsFeatureEnabled(string featureName);
    }

    public class FeatureManager : IFeatureManager
    {
        private static readonly string DatabasePath = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase.Substring(8)),
            "ApplicationData.sdf");

        public string GetSwitchSetting(string featureName)
        {
            using (var context = new ApplicationDataEntities())
            {
                var dbFeatureId = context.FeatureSwitches.FirstOrDefault(x => x.FeatureName == featureName).FeatureSwitchId;

                var message = context.FeatureMessages.FirstOrDefault(x => x.FeatureId == dbFeatureId).Message;

            }

            return string.Empty;
        }

        public bool IsFeatureEnabled(string featureName)
        {
            var feature = GetFeatureByFeatureName(featureName);
            return feature.Enabled;
        }

        private Feature GetFeatureByFeatureName(string featureName)
        {
            var feature = new Feature();
            using (var context = new ApplicationDataEntities())
            {
                var dbFeature = context.FeatureSwitches.FirstOrDefault(x => x.FeatureName == featureName);
                feature.Enabled = dbFeature.Enabled;
                feature.FeatureName = dbFeature.FeatureName;
                feature.FeatureSwitchId = dbFeature.FeatureSwitchId;
            }

            return feature;
        }
    }
}