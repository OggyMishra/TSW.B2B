namespace TSW_B2B.Web {
	using System.Web.Http;
	using Swashbuckle.Application;

	public class SwaggerConfig {
		public static void Register(HttpConfiguration config) {
			config.EnableSwagger(c =>
			{
				c.SingleApiVersion("v1", "tswb2bservices");
				c.IncludeXmlComments(string.Format(@"{0}\bin\tswb2bservices.XML", System.AppDomain.CurrentDomain.BaseDirectory));
				c.DescribeAllEnumsAsStrings();
				c.UseFullTypeNameInSchemaIds();
			}).EnableSwaggerUi();
		}
	}
}
