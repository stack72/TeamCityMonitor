using Autofac;
using Autofac.Integration.Mvc;

namespace BuildMonitor.Models.Repository
{
    public class RepositoriesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new FeatureRepository()).As<IFeatureRepository>().InstancePerHttpRequest();
            builder.Register(c => new MessageRepository()).As<IMessageRepository>().InstancePerHttpRequest();
        }
    }
}