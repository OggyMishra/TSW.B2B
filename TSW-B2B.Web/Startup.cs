using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using TSW_B2B.Web.App_Start;
using TSW_B2B.Web.Filter;
using Unity.WebApi;

[assembly: OwinStartup(typeof(TSW_B2B.Web.Startup))]
namespace TSW_B2B.Web {
	public partial class Startup {
		public void Configuration(IAppBuilder app) {
			var webApiConfiguration = ConfigureWebApi();
			app.UseCors(CorsOptions.AllowAll);
			app.UseWebApi(webApiConfiguration);
		}
		private HttpConfiguration ConfigureWebApi() {
			var config = new HttpConfiguration();
			config.Formatters.Clear();
			config.Formatters.Add(new JsonMediaTypeFormatter());
			config.Services.Replace(typeof(IHttpActionInvoker), new ServiceInvoker());
			config.DependencyResolver = new UnityDependencyResolver(UnityConfiguration.GetConfiguredContainer());
			SwaggerConfig.Register(config);
			// TODO: Put different type of filters
			config.MapHttpAttributeRoutes();
			return config;
		}
	}
}
