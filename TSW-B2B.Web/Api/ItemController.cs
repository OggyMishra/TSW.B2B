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
		[Route("getitems")]
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
		/// <param name="itemId">The item identifier.</param>
		/// <returns></returns>
		[Route("getitemById/{itemId}")]
		[HttpGet]
		public HttpResponseMessage GetItemById(int itemId) {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.GetItemById(itemId);
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
		/// <param name="pageSize">Size of the page.</param>
		/// <returns></returns>
		[Route("getitems/{pageNo}/{pageSize}")]
		[HttpGet]
		public HttpResponseMessage GetItems(int pageNo, int pageSize) {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.GetItems(pageNo, pageSize);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}
		/// <summary>
		/// Deletes the by identifier.
		/// </summary>
		/// <param name="itemId">The item identifier.</param>
		/// <returns></returns>
		[Route("deleteitembyid/{itemId}")]
		[HttpDelete]
		public HttpResponseMessage DeleteById(int itemId) {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.DeleteById(itemId);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}
		/// <summary>
		/// Creates the item.
		/// </summary>
		/// <param name="itemDetails">The item details.</param>
		/// <returns></returns>
		[HttpPost]
		[Route("createitem/itemDetail")]
		public HttpResponseMessage CreateItem(BusinessObjects.Item itemDetails) {
			HttpResponseMessage response = null;
			try {
				var result = this.itemService.AddItem(itemDetails);
				response = Request.CreateResponse(HttpStatusCode.OK, result);
			} catch (Exception ex) {
				response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
			return response;
		}
	}
}
