// ***********************************************************************
// <copyright file="DbCommandExtensions.cs" company="FactSet">
//     Copyright © FactSet, All Rights Reserved.
// </copyright>
// <summary>DbCommandExtensions Class</summary>
// ***********************************************************************
namespace TSW.B2B.Repositories.Helper {
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	public static class DbCommandExtensions {
		public static IDbCommand Page(this IDbCommand command, int pageNumber, int pageSize) {
			int offset = pageNumber * pageSize;
			int fetchRows = pageSize;
			command.CommandText = command.CommandText + "ORDER BY Id ASC OFFSET @Offset ROWS FETCH NEXT @FetchRows ROWS ONLY";
			command.AddParameter("@Offset", offset);
			command.AddParameter("@FetchRows", fetchRows);
			return command;
		}
		public static bool HasColumn(this IDataRecord dr, string columnName) {
			try {
				return dr.GetOrdinal(columnName) >= 0;
			} catch (IndexOutOfRangeException) {
				return false;
			}
		}
		public static void AddParameter(this IDbCommand command, string name, object value) {
			var parameter = command.CreateParameter();
			parameter.ParameterName = name;
			parameter.Value = value;
			command.Parameters.Add(parameter);
		}
	}
}
