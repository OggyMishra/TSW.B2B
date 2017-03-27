namespace TSW.B2B.Database {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Database;
	using Resources;

	public class CreateTSWDatabase1_0_0Script : BaseUpdateScripts {
		public CreateTSWDatabase1_0_0Script() : base() {
			Add(new SqlScript { Version = "1.0.0", Sql = Scripts.dbCreationScript });
		}
	}
}
