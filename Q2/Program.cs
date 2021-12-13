using Q2.Attributes;
using Q2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Q2
{
	class Program
	{
		private const string Separator = "_";
		// Included this to reduce input time
		public const string Input = "00003452279_021_015_194_PlantPot";

		static void Main(string[] args)
		{
			Person person = PersonBuilder(Input);
		}

		public static Person PersonBuilder(string identifier)
		{
			Person person = null;

			try
			{
				//print provided identifier
				Console.WriteLine(identifier);

				// extract identifier components
				string[] personComponents = identifier.Split(Separator);
				if (personComponents.Length != 5)
				{
					// no time for custom exception
					throw new Exception("Provided identifier componens must be 5.");
				}

				// fill object
				person = new Person(personComponents[4], new int[4] { 
					int.Parse(personComponents[0]), 
					int.Parse(personComponents[1]), 
					int.Parse(personComponents[2]), 
					int.Parse(personComponents[3]) });

				// validation
				var validationResults = new List<ValidationResult>();
				bool isValid = Validator.TryValidateObject(
					person,
					new ValidationContext(person, null, null),
					validationResults);

				// print validation result
				Console.WriteLine(string.Format("Object is {0}valid", isValid ? "" : "not "));
				if (!isValid)
				{
					// print validation messeges
					Console.WriteLine(string.Join("\n", validationResults));
				}
				// print object
				Console.WriteLine(person.ToString());
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}

			return person;
		}
	}
}
