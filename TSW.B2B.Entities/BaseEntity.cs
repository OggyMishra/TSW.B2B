namespace TSW.B2B.Entities {
	using System;
	using System.ComponentModel;
	/// <summary>
	/// Base Entity Class
	/// </summary>
	public class BaseEntity {
		/// <summary>
		///  Gets or sets ID
		/// </summary>
		/// <value>Id Property</value>
		public int Id { get; set; }
		/// <summary>
		/// Who crated the entity
		/// </summary>
		/// <value>Created by Property</value>
		public int CreatedBy { get; set; }
		/// <summary>
		/// When the entity created
		/// </summary>
		/// <value>created date Property</value>
		public DateTime CreatedDate { get; set; }
		/// <summary>
		/// Who modified the entity
		/// </summary>
		/// <value>Modified by Property</value>
		public int ModifiedBy { get; set; }
		/// <summary>
		/// When the entity is modified
		/// </summary>
		/// <value>Modified date Property</value>
		public DateTime ModifiedDate { get; set; }
	}
}