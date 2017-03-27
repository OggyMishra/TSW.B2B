namespace TSW.B2B.Entities {
	public class Group : BaseEntity {
		public int GroupId { get; set; }
		public string Description { get; set; }

		public int Nature { get; set; }

		public int Subled { get; set; }

		public string Remarks { get; set; }
	}
}
