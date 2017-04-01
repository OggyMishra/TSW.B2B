namespace TSW.B2B.Common.Implementation {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Threading;
	using Interfaces;

	public class DbContext : IDbContext, IDisposable {
		private readonly IDbConnection connection;
		private readonly IConnectionFactory connectionFactory;
		private readonly ReaderWriterLockSlim rowLock = new ReaderWriterLockSlim();
		private readonly LinkedList<UnitOfWork> unitOfWorkList = new LinkedList<UnitOfWork>();

		public DbContext(IConnectionFactory connectionFactory) {
			this.connectionFactory = connectionFactory;
			this.connection = this.connectionFactory.Create();
		}
		public IUnitOfWork CreateUnitOfWork() {
			var trasaction = connection.BeginTransaction();
			var dbUnitOfWork = new UnitOfWork(trasaction, RemoveTransaction, RemoveTransaction);

			this.rowLock.EnterWriteLock();
			this.unitOfWorkList.AddLast(dbUnitOfWork);
			this.rowLock.ExitWriteLock();

			return dbUnitOfWork;
		}
		public IDbCommand CreateCommand() {
			var cmd = this.connection.CreateCommand();
			rowLock.EnterReadLock();
			if (unitOfWorkList.Count > 0)
				cmd.Transaction = unitOfWorkList.First.Value.Transaction;
			rowLock.ExitReadLock();
			return cmd;
		}
		private void RemoveTransaction(UnitOfWork obj) {
			this.rowLock.EnterWriteLock();
			this.unitOfWorkList.Remove(obj);
			this.rowLock.ExitWriteLock();
		}
		public void Dispose() {
			this.connection.Dispose();
		}
	}
}
