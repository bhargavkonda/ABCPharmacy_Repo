using ABCPharmacyAPI.Interfaces;
using ABCPharmacyAPI.Processor;
using ABCPharmacyAPI.Repository;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

namespace ABCPharmacyAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IABCPharamacyProcessor, ABCPharmacyProcessor>();
            container.RegisterType<IABCPharamacyRepository, ABCPharamacyRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}