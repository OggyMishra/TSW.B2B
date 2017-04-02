namespace TSW.B2B.BusinessServices.Classes {
	using BusinessObjects;
	using Interfaces;

	public class TransactionService : ITransactionService {
		public Transaction GetTransaction(int tranId) {
			return new Transaction();
		}
	}
}
