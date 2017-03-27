namespace TSW.B2B.Database {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using Common.Constants;

	public interface ISqlRunner {
		T ExecuteScalar<T>(string query);
		void ExecuteSqlStatementsInTransaction(IEnumerable<string> statements);
	}

	public class SqlRunner : ISqlRunner {
		public T ExecuteScalar<T>(string query) {
			using (var connection = GetSqlConnection()) {
				connection.Open();
				using (var cmd = new SqlCommand(query, connection)) {
					return (T)cmd.ExecuteScalar();
				}
			}
		}

		public void ExecuteSqlStatementsInTransaction(IEnumerable<string> statements) {
			using (var connection = GetSqlConnection()) {
				connection.Open();
				var trans = connection.BeginTransaction();
				try {
					foreach (var statement in statements) {
						ExecuteSqlStatement(statement, connection);
					}
					trans.Commit();
				} catch (Exception ex) {
					trans.Rollback();
					throw;
				}
			}
		}

		private static SqlConnection GetSqlConnection() {
			return new SqlConnection(ConnectionStrings.ESTIMATEHISTORY);
		}
		private static SqlConnection GetSqlConnection(string sqlConnectionString) {
			return new SqlConnection(sqlConnectionString);
		}
		private static void ExecuteSqlStatement(string sql, IDbConnection connection) {
			try {
				using (var cmd = connection.CreateCommand()) {
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = sql;
					cmd.ExecuteNonQuery();
				}
			} catch (Exception e) {
				throw new Exception("Error in " + sql, e);
			}
		}
	}
}
