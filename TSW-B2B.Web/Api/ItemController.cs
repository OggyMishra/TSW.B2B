namespace TSW_B2B.Web.Api {
	using System;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;
	using TSW.B2B.BusinessServices.Interfaces;
	using TSW_B2B.Web.BaseController;
	using BusinessObjects = TSW.B2B.BusinessObjects;
	/// <summary>
	/// Api Controller for items
	/// </summary>
	/// <seealso cref="TSW_B2B.Web.BaseController.BaseController{TSW.B2B.BusinessObjects.Item}" />
	[RoutePrefix("api")]
	public class ItemController : BaseController<BusinessObjects.Item> {
		/// <summary>
		/// The item service
		/// </summary>
		private readonly IItemService itemService;
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemController"/> class.
		/// </summary>
		/// <param name="itemService">The item service.</param>
		public ItemController(IItemService itemService) {
			this.itemService = itemService;
		}
		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <returns></returns>
		[Route("items")]
		[HttpGet]
		public HttpResponseMessage GetItems() {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.GetItems();
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}

		/// <summary>
		/// Gets the item by id.
		/// </summary>
		/// <param name="itemid">The item identifier.</param>
		/// <returns></returns>
		[Route("item/{itemid}")]
		[HttpGet]
		public HttpResponseMessage GetItemById(int itemid) {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.GetItemById(itemid);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}

		/// <summary>
		/// Gets the items using pageSize.
		/// </summary>
		/// <param name="pageNo">The page no.</param>
		/// <param name="pagesize">Size of the page.</param>
		/// <returns></returns>
		[Route("items/{pageno}/{pagesize}")]
		[HttpGet]
		public HttpResponseMessage GetItems(int pageno, int pagesize) {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.GetItems(pageno, pagesize);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}
		/// <summary>
		/// Deletes the by identifier.
		/// </summary>
		/// <param name="itemid">The item identifier.</param>
		/// <returns></returns>
		[Route("delete/{itemid}")]
		[HttpDelete]
		public HttpResponseMessage DeleteById(int itemid) {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.DeleteById(itemid);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}
		/// <summary>
		/// Creates the item.
		/// </summary>
		/// <param name="itemdetail">The item details.</param>
		/// <returns></returns>
		[HttpPost]
		[Route("create/itemdetail")]
		public HttpResponseMessage CreateItem(BusinessObjects.Item itemdetail) {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.AddItem(itemdetail);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}
	}
}
