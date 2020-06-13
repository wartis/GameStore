using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using GameStore.Domain.Abstract;
using GameStore.Domain.Concrete;
using GameStore.Domain.Entities;
using Moq;
using Ninject;

namespace GameStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //Mock<IGameRepository> mock = new Mock<IGameRepository>();
            //mock.Setup(m => m.Games).Returns(new List<Game>
            //{
            //    new Game() { Name = "GTA 5", Price=1499 }, 
            //    new Game() { Name = "The last of us", Price=999}, 
            //    new Game() { Name = "Civilisation 6", Price=2999}
            //});

            //kernel.Bind<IGameRepository>().ToConstant(mock.Object); 
            // Здесь размещаются привязки
            kernel.Bind<IGameRepository>().To<EFGameRepository>(); 
        }
    }
}