namespace TSW.B2B.Database {
	/// <summary>
	/// 
	/// </summary>
	public class SqlScript {
		/// <summary>
		/// Gets or sets the version. As of now there is no use of the version. This can be very useful when we have different version of db (like staging/prod/dev)
		/// </summary>
		/// <value>
		/// The version.
		/// </value>
		public string Version { get; set; }
		/// <summary>
		/// </summary>
		/// <value>
		/// The SQL.
		/// </value>
		public string Sql { get; set; }
	}
}
