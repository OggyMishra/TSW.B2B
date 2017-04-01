namespace TSW.B2B.Repositories.Classes {
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Threading.Tasks;
	using Common.Implementation;
	using Entities;
	using Helper;
	using Interfaces;
	using Queries;

	public class ItemRepository : Repository<Item>, IItemRepository {
		private DbContext context;
		public ItemRepository(DbContext context) : base(context) {
			this.context = context;
		}
		public IEnumerable<Item> GetItems() {
			using (var command = this.context.CreateCommand()) {
				command.CommandType = CommandType.Text;
				command.CommandText = QueryGenerator.GET_ALL_ITEMS;
				return this.ToList(command);
			}
		}
		public IEnumerable<Item> GetItems(int pageNumber, int pageSize) {
			using (var command = this.context.CreateCommand()) {
				command.CommandType = CommandType.Text;
				command.CommandText = QueryGenerator.GET_ALL_ITEMS;
				return this.ToList(command, pageNumber, pageSize);
			}
		}
		public Item GetItemById(int itemId) {
			using (var command = this.context.CreateCommand()) {
				command.CommandType = CommandType.Text;
				command.CommandText = QueryGenerator.GET_ITEM_GIVEN_ID;
				command.AddParameter("@pItemId", itemId);
				var result = this.ToList(command);
				return result.Count() > 0 ? result.FirstOrDefault() : null;
			}
		}
		public bool DeleteById(int itemId) {
			using (var command = this.context.CreateCommand()) {
				command.CommandType = CommandType.Text;
				command.CommandText = QueryGenerator.DELETE_ITEM_GIVEN_ID;
				command.AddParameter("@pItemId", itemId);
				return command.ExecuteNonQuery() > 0;
			}
		}
		public bool AddItem(Item item) {
			using (var command = this.context.CreateCommand()) {
				command.CommandType = CommandType.Text;
				command.CommandText = QueryGenerator.INSERT_ITEM;
				command.AddParameter("@pCode", item.ItemCode);
				command.AddParameter("@pDesc", item.ItemDescription);
				command.AddParameter("@pCatgId", item.CateogryId);
				command.AddParameter("@pMrp", item.ItemMaximumRetailPrice);
				command.AddParameter("@pRate", item.ItemRate);
				command.AddParameter("@pDisc", item.ItemDisc);
				command.AddParameter("@pRemarks", item.Remarks);
				return command.ExecuteNonQuery() > 0;
			}
		}
	}
}
