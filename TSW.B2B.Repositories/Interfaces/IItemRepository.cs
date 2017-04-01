namespace TSW.B2B.Repositories.Interfaces {
	using System.Collections.Generic;
	public interface IItemRepository {
		IEnumerable<Entities.Item> GetItems();
		IEnumerable<Entities.Item> GetItems(int pageNo, int pageSize);
		Entities.Item GetItemById(int id);
		bool DeleteById(int id);
		bool AddItem(Entities.Item item);
	}
}
