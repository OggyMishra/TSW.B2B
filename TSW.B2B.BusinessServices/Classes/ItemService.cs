namespace TSW.B2B.BusinessServices.Classes {
	using System.Collections.Generic;
	using BusinessObjects;
	using Common;
	using Interfaces;
	using Repositories.Interfaces;

	public class ItemService : IItemService {
		private readonly IItemRepository itemRepository;
		public ItemService(IItemRepository itemRepository) {
			this.itemRepository = itemRepository;
		}
		public bool DeleteById(int itemId) {
			return this.itemRepository.DeleteById(itemId);
		}
		public Item GetItemById(int itemId) {
			return EntityConverter.ConvertEntityToModel<Entities.Item, BusinessObjects.Item>(this.itemRepository.GetItemById(itemId));
		}
		public Item GetItemById(Item item) {
			return this.GetItemById(item.Id);
		}
		public IEnumerable<Item> GetItems() {
			return EntityConverter.ConvertEntityToModel<Entities.Item, BusinessObjects.Item>(this.itemRepository.GetItems());
		}
		public IEnumerable<Item> GetItems(int pageNo, int pageSize) {
			return EntityConverter.ConvertEntityToModel<Entities.Item, BusinessObjects.Item>(this.itemRepository.GetItems(pageNo, pageSize));
		}
		public bool AddItem(BusinessObjects.Item item) {
			return this.itemRepository.AddItem(EntityConverter.ConvertModelToEntity<BusinessObjects.Item, Entities.Item>(item));
		}
	}
}
