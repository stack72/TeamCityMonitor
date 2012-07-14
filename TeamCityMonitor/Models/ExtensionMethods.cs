using System.Web.Mvc;
using BuildMonitor.Models.Repository;

namespace BuildMonitor.Models
{
    public static class FeaturesExtension
    {
        public static bool FeatureSwitchEnabled(this HtmlHelper helper, string featureName)
        {
            var featureManager = new FeatureRepository();
            var feature = featureManager.GetFeature(featureName);

            return feature.Enabled;
        }
    }

    public static class MessagesExtension
    {
        public static string GetMessageDetails(this HtmlHelper helper, string messageName)
        {
            var messagesRepository = new MessageRepository();
            var message = messagesRepository.GetMessage(messageName);

            return message.MessageDetails;
        }
    }
}