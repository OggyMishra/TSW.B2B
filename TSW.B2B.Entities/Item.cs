namespace TSW.B2B.Entities {
	using System.ComponentModel;
	public class Item : BaseEntity {
		[DisplayNameAttribute("CODE")]
		public string ItemCode { get; set; }
		[DisplayNameAttribute("DESC")]
		public string ItemDescription { get; set; }
		[DisplayNameAttribute("CATG_ID")]
		public int CateogryId { get; set; }
		[DisplayNameAttribute("MRP")]
		public decimal ItemMaximumRetailPrice { get; set; }
		[DisplayNameAttribute("RATE")]
		public decimal ItemRate { get; set; }
		[DisplayNameAttribute("DISC")]
		public int ItemDisc { get; set; }
		[DisplayNameAttribute("REM")]
		public string Remarks { get; set; }
	}
}
