using System;
using System.Collections.Generic;
using System.Text;

namespace Q3
{
	public abstract class Vehicle
	{
		public int NumberOfWeels { get; set; }

		public Vehicle(int numberOfWeels)
		{
			this.NumberOfWeels = numberOfWeels;
		}

		public virtual void EngineOn()
		{
			Console.WriteLine("Vehicle's engine is ON");
		}

		public virtual void MoveForwardAtKMPH(int kmph)
		{
			Console.WriteLine($"Vehicle move forward with {kmph}kmph.");
		}

		public virtual void EngineOff()
		{
			Console.WriteLine("Vehicle's engine is OFF");
		}
	}
}
