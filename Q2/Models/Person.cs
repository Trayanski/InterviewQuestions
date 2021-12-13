using Q2.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Q2.Models
{
	public class Person : IValidatableObject
	{
		private const int NumberOfIntegers = 4;
		private const string NameRegexPattern = @"[\w\d]+";

		public string Name { get; set; }

		public int[] FourIntegers { get; set; }

		public Person(string name, int[] integers)
		{
			this.Name = name;
			this.FourIntegers = integers;
		}

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var results = new List<ValidationResult>();
			Validator.TryValidateProperty(this.Name,
				new ValidationContext(this, null, null) { MemberName = "Name" },
				results);
			Validator.TryValidateProperty(this.FourIntegers,
				new ValidationContext(this, null, null) { MemberName = "FourIntegers" },
				results);

			if (string.IsNullOrEmpty(Name) || string.IsNullOrWhiteSpace(Name))
			{
				results.Add(new ValidationResult("Name field is Required."));
			}
			else
			{
				var match = Regex.Match(Name, NameRegexPattern);
				if (!match.Success || match.Value.Length != Name.Length)
				{
					results.Add(new ValidationResult("The name can contain both letters, uppercase and lowercase, and numbers."));
				}
			}

			if (FourIntegers == null || FourIntegers.Length == 0)
			{
				results.Add(new ValidationResult("The stored inteders are Required."));
			}
			else
			{
				if (FourIntegers.Length != NumberOfIntegers)
				{
					results.Add(new ValidationResult($"The stored inteders must be {NumberOfIntegers}."));
				}

				for (int i = 0; i < FourIntegers.Length; i++)
				{
					int currentInteger = FourIntegers[i];
					if (currentInteger <= 0)
					{
						results.Add(new ValidationResult($"The stored inteder {currentInteger} must be a number higher than 0."));
					}
				}
			}

			return results;
		}

		public override string ToString()
		{
			return string.Format("Name: {0}, First num: {1}, Second num: {2}, Third num: {3}, Fourth num: {4}", 
				this.Name, this.FourIntegers[0], this.FourIntegers[1], this.FourIntegers[2], this.FourIntegers[3]);
		}
	}
}
