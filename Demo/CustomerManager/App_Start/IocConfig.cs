using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CustomerManager.Models;

namespace CustomerManager.App_Start
{
    public class IocConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            DbConnection connection = Effort.DbConnectionFactory.CreatePersistent("Blubb");
            builder.RegisterInstance(connection);

            // all types which are decorated with [RegisterInstancePerRequest]
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.GetCustomAttributes(typeof(RegisterInstancePerRequestAttribute), false).Any())
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerRequest();

            var container = builder.Build();

            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }
    }
}