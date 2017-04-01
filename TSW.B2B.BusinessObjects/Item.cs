namespace TSW.B2B.BusinessObjects {
	public class Item {
		public int Id { get; set; }
		public string ItemCode { get; set; }
		public string ItemDescription { get; set; }
		public int CateogryId { get; set; }
		public decimal ItemMaximumRetailPrice { get; set; }
		public decimal ItemRate { get; set; }
		public int ItemDisc { get; set; }
		public string Remarks { get; set; }
	}
}
