namespace TSW_B2B.Web.Api {
	using System;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;
	using BaseController;
	using TSW.B2B.BusinessServices.Interfaces;
	/// <summary>
	/// Controller for transaction related api
	/// </summary>
	/// <seealso cref="TSW_B2B.Web.BaseController.BaseController{TSW.B2B.BusinessObjects.Transaction}" />
	[RoutePrefix("api")]
	public class TransactionController : BaseController<TSW.B2B.BusinessObjects.Transaction> {
		/// <summary>
		/// The transaction service
		/// </summary>
		private readonly ITransactionService transactionService;
		/// <summary>
		/// Initializes a new instance of the <see cref="TransactionController"/> class.
		/// </summary>
		/// <param name="transactionService">The transaction service.</param>
		public TransactionController(ITransactionService transactionService) {
			this.transactionService = transactionService;
		}

		/// <summary>
		/// Gets transaction details by identifier.
		/// </summary>
		/// <param name="tranId">The tran identifier.</param>
		/// <returns></returns>
		[Route("transaction/{tranid}")]
		[HttpGet]
		public HttpResponseMessage GetItemById(int tranId) {
			HttpResponseMessage response = null;
			try {
				var result = this.transactionService.GetTransaction(tranId);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}

	}
}