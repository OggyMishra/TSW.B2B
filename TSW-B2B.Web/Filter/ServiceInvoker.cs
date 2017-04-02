namespace TSW_B2B.Web.Filter {
	using System.Net;
	using System.Net.Http;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Web.Http.Controllers;

	public class ServiceInvoker : ApiControllerActionInvoker {

		/// <summary>
		/// Asynchronously invokes the specified action by using the specified controller context.
		/// </summary>
		/// <param name="actionContext">The controller context.</param>
		/// <param name="cancellationToken">The cancellation token.</param>
		/// <returns>
		/// The invoked action.
		/// </returns>
		public override Task<HttpResponseMessage> InvokeActionAsync(HttpActionContext actionContext, CancellationToken cancellationToken) {
			var result = base.InvokeActionAsync(actionContext, cancellationToken);
			var message = $"URL: {actionContext.Request.RequestUri}";
			if (cancellationToken.IsCancellationRequested) {
				return Task.Run<HttpResponseMessage>(() => actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request Cancelled!"));
			}
			if (result.Exception != null && result.Exception.GetBaseException() != null) {
				try {
					// Add logging here 
				} catch {
					throw;
				}
				return Task.Run<HttpResponseMessage>(() =>
				actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "UnhandledException"));
			}
			return result;
		}
	}
}