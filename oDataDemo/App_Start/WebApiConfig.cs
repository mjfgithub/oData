using oDataDemo.Models;
using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace oDataDemo
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "oDataDemo";
            builder.ContainerName = "DefaultContainer";
            builder.EntitySet<Person>("People");
            builder.EntitySet<Trip>("Trips");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }



        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes
        //    config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );
        //}
    }
}
