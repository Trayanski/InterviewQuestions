using System;
using System.ComponentModel.DataAnnotations;

namespace Q2.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    sealed public class FourIntegersValidationAttribute : ValidationAttribute
    {
		private const int NumberOfIntegers = 4;

		public override bool IsValid(object value)
        {
            var inputValue = value as int[];
            var isValid = true;

			if (inputValue.Length != NumberOfIntegers)
			{
				throw new ValidationException($"The stored inteders must be {NumberOfIntegers}.");
			}

			for (int i = 0; i < NumberOfIntegers; i++)
			{
				int currentInteger = inputValue[i];
				if (currentInteger <= 0)
				{
					throw new ValidationException($"The stored inteder {currentInteger} must be a number higher than 0.");
				}
			}

			return isValid;
        }
    }
}
