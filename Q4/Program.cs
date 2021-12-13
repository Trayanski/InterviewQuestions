using System;
using System.Reflection;

namespace Q4
{
	class Program
	{
        public const int Class1MustHavePropertiesCount = 10;
        private const string Class1PropertyTemplate = "IMG_{0}";

        static void Main(string[] args)
		{
            Q4Method(new Class1(), 4);
        }

        public static void Q4Method(Class1 class1, int n)
        {
			try
			{
			    if (n > Class1MustHavePropertiesCount)
                    throw new IndexOutOfRangeException("Provided <n> must be from 1 to 10.");

                Type class1Type = typeof(Class1);

                for (int i = 1; i <= n; i++)
			    {
                    // Change the instance property value with reflection
                    FieldInfo fieldInstance = class1Type.GetField(string.Format(Class1PropertyTemplate, i));
                    // TODO [TK]: [fix error]
                    fieldInstance.SetValue(class1, "Hello");
                }

				for (int i = n + 1; i <= Class1MustHavePropertiesCount; i++)
				{
                    // Change the instance property value with reflection
                    FieldInfo fieldInstance = class1Type.GetField(string.Format(Class1PropertyTemplate, i));
                    fieldInstance.SetValue(class1, string.Empty);
                }

				Console.WriteLine(class1.ToString());
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
	}

    class Class1
    {
        public string IMG_1 = default(string);
        public string IMG_2 = default(string);
        public string IMG_3 = default(string);
        public string IMG_4 = default(string);
        public string IMG_5 = default(string);
        public string IMG_6 = default(string);
        public string IMG_7 = default(string);
        public string IMG_8 = default(string);
        public string IMG_9 = default(string);
        public string IMG_10 = default(string);

        public Class1()
        {

        }

		public override string ToString()
		{
			return string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",
                IMG_1, IMG_2, IMG_3, IMG_4, IMG_5, IMG_6, IMG_7, IMG_8, IMG_9, IMG_10);
		}
	}

}
