namespace TSW.B2B.Repositories.Classes {
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using Common.Implementation;
	using Common.Interfaces;
	using Helper;

	public abstract class Repository<TEntity> where TEntity : new() {
		private const int pageSize = 50;
		private const int pageNumber = 0;
		private IDbContext context;
		public Repository(IDbContext context) {
			this.context = context;
		}
		protected IDbContext Context
		{
			get
			{
				return this.context;
			}
		}
		protected IEnumerable<TEntity> ToList(IDbCommand command, int pageNo = pageNumber, int pageSize =pageSize) {
			command = command.Page(pageNo, pageSize);
			using (var record = command.ExecuteReader()) {
				List<TEntity> items = new List<TEntity>();
				while (record.Read()) {
					items.Add(Map<TEntity>(record));
				}
				return items;
			}
		}
		protected TEntity Map<TEntity>(IDataRecord record) {
			var objT = Activator.CreateInstance<TEntity>();
			foreach (var property in typeof(TEntity).GetProperties()) {
				var attributeDesc = property.GetCustomAttributes(false);
				var colName = attributeDesc.Length > 0 ? ((DisplayNameAttribute)attributeDesc[0]).DisplayName : property.Name;
				if (record.HasColumn(colName) && !record.IsDBNull(record.GetOrdinal(colName))) {
					property.SetValue(objT, record[colName]);
				}
			}
			return objT;
		}
	}
}
