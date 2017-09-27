using Microsoft.Owin.Hosting;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi;
using WebApi.Controllers;

namespace SelfHostWebApi
{
    class Program
    {
        static void Main(string[] args)
        {
            // owin hack
            new Class1();

            string baseAddress = ConfigurationManager.AppSettings["BaseAddress"];
            IUnityContainer container = new UnityContainer();
            InitializeServiceLocator(container);
            Console.Title = "Web Api";
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine($"Listening on {baseAddress}");
            Console.WriteLine("hit <enter> to exit...");
            Console.ReadLine();

        }

        private static void InitializeServiceLocator(IUnityContainer container)
        {
            //set unity as the service locator. This is required for the membership classes
            //UnityServiceLocator serviceLocator = new UnityServiceLocator(container);
            //ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }
}
