namespace TSW.B2B.Database {
	using System.Collections.Generic;
	using System.Text.RegularExpressions;

	public class BaseUpdateScripts : List<SqlScript> {
		protected readonly SqlRunner _mainDbSqlRunner;
		protected BaseUpdateScripts() {
			_mainDbSqlRunner = new SqlRunner();
		}
		public void UpdateDatabase() {
			foreach (var script in this) {
				var statements = SplitScript(script.Sql);
				_mainDbSqlRunner.ExecuteSqlStatementsInTransaction(statements);
			}
		}
		private static IEnumerable<string> SplitScript(string script) {
			const string pattern = @"\r\nGO *\r\n";
			var statements = Regex.Split(script, pattern, RegexOptions.Multiline);
			return new List<string>(statements);
		}
	}
}
