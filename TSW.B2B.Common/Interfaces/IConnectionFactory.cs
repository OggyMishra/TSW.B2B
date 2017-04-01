namespace TSW.B2B.Common.Interfaces {
	using System.Data;
	public interface IConnectionFactory {
		IDbConnection Create();
	}
}
