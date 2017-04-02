namespace TSW_B2B.Web.Api {
	using System;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;
	using BaseController;
	using TSW.B2B.BusinessServices.Interfaces;

	public class TransactionController : BaseController<TSW.B2B.BusinessObjects.Transaction> {
		private readonly ITransactionService transactionService;
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