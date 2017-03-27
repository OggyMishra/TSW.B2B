namespace TSW.B2B.Common.Constants {
	/// <summary>
	/// Connection string class for persisting the db connection
	/// </summary>
	public static class ConnectionStrings {
		/// <summary>
		/// The _estimate history
		/// </summary>
		private static string estimateHistory;

		/// <summary>
		/// Gets the estimatehistory.
		/// </summary>
		/// <value>
		/// The estimatehistory.
		/// </value>
		public static string ESTIMATEHISTORY { get; }

		/// <summary>
		/// Resets the estimate history.
		/// </summary>
		/// <param name="connstring">The connstring.</param>
		public static void ResetEstimateHistory(string connstring) {
			estimateHistory = connstring;
		}

		/// <summary>
		/// Sets the ff document history.
		/// </summary>
		/// <param name="connstring">The connstring.</param>
		public static void SetFFDocumentHistory(string connstring) {
			estimateHistory = connstring;
		}
	}
}
