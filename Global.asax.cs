using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;
using vannon_teste.Controllers;
using vannon_teste.Data;
using vannon_teste.Migrations;
using vannon_teste.Repositories;
using vannon_teste.Services;

namespace vannon_teste
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigureDependencyInjection();
        }

        private void ConfigureDependencyInjection()
        {
            // Criar o contêiner de injeção de dependência
            var builder = new ContainerBuilder();

            // Registrar os serviços e repositórios
            builder.RegisterType<vannonDBContext>().InstancePerRequest();
            builder.RegisterType<FilmeRepository>().InstancePerRequest();
            builder.RegisterType<FilmeService>().InstancePerRequest();
            builder.RegisterType<ClienteService>().InstancePerRequest();
            builder.RegisterType<ClienteRepository>().InstancePerRequest();

            // Configurar o DependencyResolver
            var resolver = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(resolver));
        }
    }
}
