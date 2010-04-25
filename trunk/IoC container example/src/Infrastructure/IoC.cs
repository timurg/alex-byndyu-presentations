using Castle.Windsor;

namespace Infrastructure
{
    public static class IoC
    {
        private static WindsorContainer windsorContainer;

        public static void Init(WindsorContainer container)
        {
            windsorContainer = container;
        }

        public static TService Resolve<TService>(object initParams)
        {
            return windsorContainer.Resolve<TService>(initParams);
        }
    }
}