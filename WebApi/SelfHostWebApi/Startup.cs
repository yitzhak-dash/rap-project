using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

namespace SelfHostWebApi
{
    public class Startup
    {
        private IUnityContainer _container;

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            _container = ServiceLocator.Current.GetInstance<IUnityContainer>();

            Mappers();
            RegisterContainerItems(_container);
            RunWebApiConfiguration(appBuilder, config);
            config.DependencyResolver = new UnityResolver(_container);

        }

        private void Mappers()
        {
            //Mapper.CreateMap<QueryResult, QueryResultView>().ReverseMap();
            //Mapper.CreateMap<ActionBase, ActionBaseView>().ReverseMap();
            //Mapper.CreateMap<RequestSingle, RequestSingleView>().ReverseMap();
            //Mapper.CreateMap<BatchRequest, BatchRequestView>().ReverseMap();
            //Mapper.CreateMap<BatchesFilterRequest, BatchFilter>();
        }

        private void RegisterContainerItems(IUnityContainer container)
        {
            //register the services and managers.
            //container.RegisterType<IUnitOfWork, EFContext>();
            //container.RegisterType<IAgentsManager, AgentsManager>();
            //container.RegisterType<IRequestSingleManager, RequestSingleManager>();
            //container.RegisterType<IAgentProfileManager, AgentProfileManager>();
            //container.RegisterType<IBatchesManager, BatchesManager>();
            //container.RegisterType<IActionsManager, ActionsManager>();
            //container.RegisterType<IHelper<AddBatchRequest, int>, AddBatchHelper>(new ContainerControlledLifetimeManager());
            //container.RegisterType<IHelper<BatchesFilterRequest, List<BatchInfoView>>, GetAllBatchesHelper>();
        }

        private void RunWebApiConfiguration(IAppBuilder appBuilder, HttpConfiguration config)
        {
            config.EnableCors();
            config.Routes.MapHttpRoute(name: "DefaultApi",
                                        routeTemplate: "Api/{controller}/{action}/{id}",
                                        defaults: new { id = RouteParameter.Optional });
            ConfigureJsonSerialization(config);
            appBuilder.UseWebApi(config);
            config.EnsureInitialized();
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
