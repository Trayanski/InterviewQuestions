using System;

namespace Q3
{
    class Program
    {
        public static void Drive(Vehicle drive)	// ? represents an object type provided in your solution.
        {
            drive.EngineOn();
            drive.MoveForwardAtKMPH(10);
            drive.MoveForwardAtKMPH(0);
            drive.EngineOff();
        }

        static void Main(string[] args)
        {
            // Create my car, it has 4 wheels and is not a hatchback.

            Car myCar = new Car(4, false);

            // Create my motorbike, it has 2 wheels and a sidecar.

            MotorBike myMotorBike = new MotorBike(2, true);

            // Take both out for a drive!

            Drive(myCar);
            Drive(myMotorBike);
        }
    }
}

