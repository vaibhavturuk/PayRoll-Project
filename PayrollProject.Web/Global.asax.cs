using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using AutoMapper;
using PayrollProject.Web.App_Start;
using Autofac;
using PayrollProject.Repositories.Repositories;
using PayrollProject.Repositories.RepositotyInterfaces;
using PayrollProject.Services.Services;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace PayrollProject.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
               .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            // Setup the Container Builder

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();


            builder.RegisterType<DataBaseFactory>().As<IDataBaseFactory>().InstancePerRequest();

            // Register your repositories all at once using assembly scanning

            builder.RegisterAssemblyTypes(typeof(EmployeeRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(EmployeeService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            

            //register
            //builder.RegisterAssemblyTypes(typeof(RegisterRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();

            //builder.RegisterAssemblyTypes(typeof(RegisterService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            // Register your Web API controllers all at once using assembly scanning

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            // OPTIONAL: Register the Autofac filter providZer.

            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.

            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}