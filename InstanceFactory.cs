using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Releasers;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using System;
using System.IO;
using System.Text;

namespace CodingArchitect.Spikes.WindsorWcfService
{
    public class InstanceFactory
    {
        private static IWindsorContainer _container;

        public static void InitializeContainer()
        {
            StringBuilder basePath = new StringBuilder(AppDomain.CurrentDomain.BaseDirectory);
            if (basePath.ToString().EndsWith("\\") == false)
                basePath.Append("\\");
            if (!File.Exists(Path.Combine(basePath.ToString(), @"IOC\InstanceConfiguration.xml")))
            {
                if (basePath.ToString().Contains(@"\bin") == false)
                    basePath.Append(@"bin\");
            }
            basePath.Append(@"IOC\InstanceConfiguration.xml");
            _container = new WindsorContainer(new XmlInterpreter(basePath.ToString()));
            _container.AddFacility<WcfFacility>(f => f.CloseTimeout = TimeSpan.Zero);
            var kernel = _container.Kernel;
            kernel.ReleasePolicy = new NoTrackingReleasePolicy();
            kernel.Resolver.AddSubResolver(new CollectionResolver(kernel));
            //DefaultServiceHostFactory.RegisterContainer(_container);
        }

        public static void Register<TComponent, TService>()
            where TComponent : class
            where TService : TComponent
        {
            _container.Register(Component.For<TComponent>()
                            .ImplementedBy<TService>()
                            .LifestyleTransient());
        }

        public static T Resolve<T>()
            where T : class
        {
            return _container.Resolve<T>();
        }

        public static void Release<T>(T service)
            where T : class
        {
            _container.Release(service);
        }
    }
}