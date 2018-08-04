using System;

namespace SI._01.CreateClass
{
	public class Employee : Person, ICloneable
	{
		public string Profession { set; get; }

		public Room Room { set; get; }
		private int _salary;

		public int Salary
		{
			get => _salary;

			set =>
				_salary = value > 0 ? value : 0;
		}

		public Employee(string name, DateTime birthDate, Gender gender, int salary, string profession) : base(name, birthDate, gender)
		{
			Salary = salary;
			Profession = profession;
		}

		public override string ToString() => base.ToString() + $" Salary: {Salary}; Profession: {Profession}; Room: {Room.Number}";

		public object Clone()
		{
			var newEmployee = (Employee)this.MemberwiseClone();
			newEmployee.Room = new Room(Room.Number);
			return newEmployee;
		}
	}
}