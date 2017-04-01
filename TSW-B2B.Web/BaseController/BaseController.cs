using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TSW_B2B.Web.BaseController {
	public class BaseController<T> : ApiController where T : class {
		public BaseController() {

		}
		public virtual IEnumerable<T> Get() {
			return null;
		}
		public virtual IEnumerable<T> Get(int id) {
			return null;
		}
		public virtual void Post([FromBody] T value) {

		}
		public virtual void Put([FromBody] T value) {

		}
		public virtual void Delete(int id) {

		}
		public virtual void Delete([FromBody] T value) {

		}
	}
}
