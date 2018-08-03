using System;
using static System.Console;

namespace SI._01.CreateClass
{
	public enum Gender
	{
		Male, Female
	}

	internal class Person
	{
		public string Name { get; set; }
		public DateTime BirthDate { get; }
		public Gender Gender { get; }

		public Person(string name, DateTime birthDate, Gender gender)
		{
			Name = name;
			BirthDate = birthDate;
			Gender = gender;
		}

		public override string ToString() => $"{typeof(Person).Name}; {Name}; {BirthDate.Year}-{BirthDate.Month}-{BirthDate.Day}; {Gender}";

		private static void Main()
		{
			var person = new Person("Jenő", new DateTime(1990, 01, 01), Gender.Male);
			WriteLine(person);
			ReadKey();
		}
	}
}