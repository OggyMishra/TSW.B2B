namespace TSW.B2B.Common.Interfaces {
	using System.Data;
	public interface IDbContext {
		IUnitOfWork CreateUnitOfWork();
		IDbCommand CreateCommand();
	}
}
