namespace TSW.B2B.Common.Implementation {
	using System;
	using System.Data;
	using Interfaces;

	public class UnitOfWork : IUnitOfWork {
		private IDbTransaction transaction;
		private readonly Action<UnitOfWork> rollBackTransaction;
		private readonly Action<UnitOfWork> commitedTransaction;

		public UnitOfWork(IDbTransaction transaction, Action<UnitOfWork> rolledBack, Action<UnitOfWork> comitted) {
			Transaction = transaction;
			this.transaction = transaction;
			this.rollBackTransaction = rolledBack;
			this.commitedTransaction = commitedTransaction;
		}

		public IDbTransaction Transaction
		{
			get; private set;
		}

		public void Dispose() {
			if (this.transaction == null)
				return;

			this.transaction.Rollback();
			this.transaction.Dispose();
			this.rollBackTransaction(this);
			this.transaction = null;
		}

		public void SaveChanges() {
			if (this.transaction == null)
				throw new InvalidOperationException("Don't entertain further this point");

			this.transaction.Commit();
			this.commitedTransaction(this);
			this.transaction = null;
		}
	}
}
