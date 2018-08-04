using System;
using static System.Console;

namespace SI._01.CreateClass
{
	public static class MainClass
	{
		public static void Main()
		{
			var kovacs = new Employee("Géza", DateTime.Now, Gender.Male, 1000, "léhűtő");
			kovacs.Room = new Room(111);
			var kovacs2 = (Employee)kovacs.Clone();
			kovacs2.Room.Number = 112;
			WriteLine(kovacs.ToString());
			WriteLine(kovacs2.ToString());
			ReadKey();
		}
	}
}