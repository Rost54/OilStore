using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Moq;
using Ninject;
using OilStore.Domain.Abstract;
using OilStore.Domain.Entities;

namespace OilStore.WebUi.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>()
            {
                new Product{Name = "Pento Super Performance III 5W-30", Description = "High Performance Engine Oil for low SAPS-requirements by VW,Mercedes etc.", Price = 1500},
                new Product{Name = "Pentosynth 5W-50", Description = "Fully Synthetic Extended Viscosity Range Motor Oil", Price = 2000},
                new Product{Name = "Pento Superoil 0W-40", Description = "High Performance Multigrade Oil", Price = 2500}
            }.AsQueryable());

            ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);
        }
    }
}