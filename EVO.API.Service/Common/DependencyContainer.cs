using SimpleInjector;
using System;
using EVO.API.Service.Interfaces;
using EVO.API.Service.Repository;
using SimpleInjector.Lifestyles;

namespace EVO.API.Service.Common
{
    public sealed class DependencyContainer
    {
        private readonly Container container;

        private DependencyContainer()
        {
            container = new Container();
        }

        private static readonly Lazy<DependencyContainer> instance = new Lazy<DependencyContainer>(() => new DependencyContainer());

        public static DependencyContainer Instance { get { return instance.Value; } }

        private void RegisterRepository()
        {
            container.Register<IContactInfoRepository, ContactInfoRepository>();
        }

        public Container Container { get { return container; } }

        public void Register()
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            RegisterRepository();
        }
    }
}