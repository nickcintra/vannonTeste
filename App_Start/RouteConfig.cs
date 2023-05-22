using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace vannon_teste
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Home",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            // --------------- ROTAS HOME
            routes.MapRoute(
              name: "Home.Index",
              url: "",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

            // --------------- ROTAS CLIENTE
            routes.MapRoute(
               name: "Cliente.Index",
               url: "cliente",
               defaults: new { controller = "Cliente", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Cliente.CriarCliente",
              url: "cliente/CriarCliente",
              defaults: new { controller = "Cliente", action = "CriarCliente", id = UrlParameter.Optional }
           );

            // --------------- ROTAS FILME
            routes.MapRoute(
               name: "Filme.Index",
               url: "filme",
               defaults: new { controller = "Filme", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "Filme.CriarFilme",
              url: "filme/criarFilme",
              defaults: new { controller = "Filme", action = "CriarFilme", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "Filme.EditarFilme",
              url: "filme/EditarFilme/{id}",
              defaults: new { controller = "Filme", action = "EditarFilme", id = UrlParameter.Optional }
            );

            routes.MapRoute(
            name: "Filme.DeletarFilme",
            url: "filme/DeletarFilme/{id}",
            defaults: new { controller = "Filme", action = "DeletarFilme" }
            );

            //routes.MapRoute(
            //   name: "Locacao.Index",
            //   url: "locacao",
            //   defaults: new { controller = "Locacao", action = "Index", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //   name: "Usuario.Index",
            //   url: "usuario",
            //   defaults: new { controller = "Usuario", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
