using AutoMapper;
using Socio.Business.MapperProfiles;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Socio
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration
              .Formatters
              .JsonFormatter
              .SerializerSettings
              .ContractResolver = new CamelCasePropertyNamesContractResolver();

            Mapper.Initialize(x =>
            {
                x.AddProfile(new MessageProfile());
                x.AddProfile(new ConversationProfile());
                x.AddProfile(new UserAccountProfile());
                x.AddProfile(new UserProfileProfile());
                x.AddProfile(new FeedMessageProfile());
            });
        }
    }
}
