namespace BuildMonitor.Models
{
    public interface IFeatureManager
    {
        string GetSwitchSetting(string featureName);
        bool IsFeatureEnabled(string featureName);
    }

    public class FeatureManager : IFeatureManager
    {
        public string GetSwitchSetting(string featureName)
        {
            return string.Empty;
        }

        public bool IsFeatureEnabled(string featureName)
        {
            return true;
        }
    }
}