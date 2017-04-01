namespace TSW.B2B.Repositories.Queries {
	public class QueryGenerator {
		#region Item related queries
		public static string GET_ALL_ITEMS = @"SELECT * FROM dbo.[ITEM]";
		public static string GET_ITEM_GIVEN_ID = @"SELECT [ID], [CODE], [DESC], [CATG_ID], [MRP], [RATE], [DISC], [REM] FROM dbo.ITEM WHERE ID=@pItemId ";
		public static string DELETE_ITEM_GIVEN_ID = @"DELETE FROM dbo.[ITEM] where ID=@pItemId";
		public static string INSERT_ITEM = @"INSERT INTO dbo.[ITEM] ([CODE], [DESC], [CATG_ID], [MRP], [RATE], [DISC], [REM]) VALUES(@pCode, @pDesc, @pCatgId, @pMrp, @pRate, @pDisc, @pRemarks)";
		#endregion
	}
}
