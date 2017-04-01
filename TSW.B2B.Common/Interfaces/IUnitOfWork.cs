namespace TSW.B2B.Common.Interfaces {
	public interface IUnitOfWork {
		void Dispose();
		void SaveChanges();
	}
}
