using System;
using System.Collections.Generic;
using System.Text;

namespace Q3
{
	public class MotorBike : Vehicle
	{
		public bool HasSidecar { get; set; }

		public MotorBike(int numberOfWeels, bool hasSidecar) : base(numberOfWeels)
		{
			this.HasSidecar = hasSidecar;
		}

		public override void EngineOn()
		{
			Console.WriteLine("MotorBike's engine is ON");
		}

		public override void MoveForwardAtKMPH(int kmph)
		{
			Console.WriteLine($"MotorBike move forward with {kmph}kmph.");
		}

		public override void EngineOff()
		{
			Console.WriteLine("MotorBike's engine is OFF");
		}
	}
}
