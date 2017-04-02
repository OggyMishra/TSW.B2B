// ***********************************************************************
namespace TSW.B2B.BusinessServices.Interfaces {
	using BusinessObjects;

	public interface ITransactionService {
		Transaction GetTransaction(int tranId);
	}
}
