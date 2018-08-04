using System;

namespace SI._01.CreateClass
{
	public class Person
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

		public override string ToString() => $"{this.GetType().Name}; Name: {Name}; Birth: {BirthDate.Year}-{BirthDate.Month}-{BirthDate.Day}; Gender: {Gender};";
	}
}