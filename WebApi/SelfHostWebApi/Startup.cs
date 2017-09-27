using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;
using WebApi.DataAccess;
using WebApi.Filters;
using WebApi.Models;

namespace SelfHostWebApi
{
    public class Startup
    {
        private IUnityContainer _container;

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            _container = new UnityContainer();

            Mappers();
            RegisterContainerItems(_container);
            RunWebApiConfiguration(appBuilder, config);
            config.DependencyResolver = new UnityResolver(_container);

        }

        private void Mappers()
        {
        }

        private void RegisterContainerItems(IUnityContainer container)
        {
            // register the services.
            container.RegisterType<IDataProvider<Product>, ProductDataProvider>(new ContainerControlledLifetimeManager());
        }

        private void RunWebApiConfiguration(IAppBuilder appBuilder, HttpConfiguration config)
        {
            config.EnableCors();
            config.Routes.MapHttpRoute(name: "DefaultApi",
                                        routeTemplate: "api/{controller}/{action}/{id}",
                                        defaults: new { id = RouteParameter.Optional });
            ConfigureJsonSerialization(config);
            appBuilder.UseWebApi(config);
            config.EnsureInitialized();
            config.Filters.Add(new ValidateModelAttribute());
        }

        private void ConfigureJsonSerialization(HttpConfiguration config)
        {
            var jsonSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.PreserveReferencesHandling = PreserveReferencesHandling.All;
            jsonSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
