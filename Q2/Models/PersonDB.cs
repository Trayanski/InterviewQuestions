using Q2.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Q2.Models
{
	public class PersonDB
	{
		[Required, RegularExpression(@"[\w\d]+", ErrorMessage = "The name can contain both letters, uppercase and lowercase, and numbers.")]
		public string Name { get; set; }

		[Required, FourIntegersValidation]
		public int[] FourIntegers { get; set; }

		public PersonDB(string name, int[] integers)
		{
			this.Name = name;
			this.FourIntegers = integers;
		}
	}
}
