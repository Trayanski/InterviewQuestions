using System;
using System.Collections.Generic;
using System.Text;

namespace Q3
{
	public class Car : Vehicle
	{
		public bool IsHatchback { get; set; }

		public Car(int numberOfWeels, bool isHatchback) : base(numberOfWeels)
		{
			this.IsHatchback = isHatchback;
		}

		public override void EngineOn()
		{
			Console.WriteLine("Car's engine is ON");
		}

		public override void MoveForwardAtKMPH(int kmph)
		{
			Console.WriteLine($"Car move forward with {kmph}kmph.");
		}

		public override void EngineOff()
		{
			Console.WriteLine("Car's engine is OFF");
		}
	}
}
