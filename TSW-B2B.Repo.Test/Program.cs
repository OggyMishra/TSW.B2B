using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSW.B2B.Common.Implementation;
using TSW.B2B.Entities;
using TSW.B2B.Repositories.Classes;

namespace TSW_B2B.Repo.Test {
	class Program {
		static void Main(string[] args) {
			while (Console.ReadLine() != "q") {
				Console.WriteLine("Test project for verifying repo behaviour");
				Console.WriteLine("Calling item repo to return every records");
				try {
					var itemRepo = new ItemRepository(new DbContext(new DbConnectionFactory("EstimateHistory")));
					var newItem = new Item
					{
						ItemCode = "afs",
						CateogryId = 100000,
						ItemDescription = "asdfas",
						ItemDisc = 12,
						ItemMaximumRetailPrice = 12.98M,
						ItemRate = 12,
						Remarks = "SRB ROCKS"
					};
					var items = itemRepo.GetItems();
					Console.WriteLine("No of items present in item table is " + items.Count());
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
				Console.WriteLine("Presss Q for closing the app");
			}
		}
	}
}
