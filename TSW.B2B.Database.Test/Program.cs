namespace TSW.B2B.Database.Test {
	using System;
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Executing db scripts..");
			Console.WriteLine("Create tsw db script executing..");
			var createDb = new CreateTSWDatabase1_0_0Script();
			try {
				createDb.UpdateDatabase();
				Console.WriteLine("tsw db created successfully");
			} catch (Exception ex) { Console.WriteLine("There is some error while creating tsw db " + ex.Message); }
			Console.WriteLine("Enter to exit the program");
			Console.ReadLine();
			Console.WriteLine("Exiting main program..");
		}
	}
}
