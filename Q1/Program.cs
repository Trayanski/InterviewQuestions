using Q1.Exeptions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Q1
{
	class Program
	{
		// Included this to reduce input time
		public const string UnorderedListHTML = "<div class=\"sc-fzoxKX ProductOverviewDesktop__StyledText-sc-1grq9ey-0 dRchrd\">Duck Tape is tough, strong, waterproof, seals, reinforces, bundles and protects. Perfect for fixing, binding &amp; repairing.</div><ul data-test-id=\"list\" class=\"ProductOverviewDesktop__List-sc-1grq9ey-1 YRBQl\"><li class=\"ProductOverviewDesktop__ListItem-sc-1grq9ey-2 hOcehm\"><div class=\"sc-fzoxKX ProductOverviewDesktop__StyledText-sc-1grq9ey-0 dRchrd\">Duck Tape Double Sided is for interior use</div></li><li class=\"ProductOverviewDesktop__ListItem-sc-1grq9ey-2 hOcehm\"><div class=\"sc-fzoxKX ProductOverviewDesktop__StyledText-sc-1grq9ey-0 dRchrd\">Great on smooth flat surfaces</div></li><li class=\"ProductOverviewDesktop__ListItem-sc-1grq9ey-2 hOcehm\"><div class=\"sc-fzoxKX ProductOverviewDesktop__StyledText-sc-1grq9ey-0 dRchrd\">Great for fixing and mounting</div></li><li class=\"ProductOverviewDesktop__ListItem-sc-1grq9ey-2 hOcehm\"><div class=\"sc-fzoxKX ProductOverviewDesktop__StyledText-sc-1grq9ey-0 dRchrd\">Easy to tear</div></li></ul>";
		private const string UlRegexPattern = @"<ul.*?>(.*?)<\/ul>";
		private const string LiRegexPattern = @"<li.*?>(.*?)<\/li>";
		private const string ElementTextRegexPattern = @">([^\<|^\>]+?)<";

		static void Main(string[] args)
		{
			List<string> content = ExtractTextFromHtmlUnorderedList(UnorderedListHTML);

			Console.WriteLine(string.Join("\n", content));
		}

		public static List<string> ExtractTextFromHtmlUnorderedList(string html)
		{
			List<string> result = new List<string>();

			try
			{
				Regex regex = new Regex(UlRegexPattern);
				// find ul element(s)
				MatchCollection matchedUlElements = regex.Matches(html);
				// throws a custom exception if none are provided
				if (matchedUlElements.Count <= 0)
					throw new HtmlElementNotFoundException("ul");

				for (int i = 0; i < matchedUlElements.Count; i++)
				{
					string currentUlHtml = matchedUlElements[i].Value;
					regex = new Regex(LiRegexPattern);
					// find li element(s)
					MatchCollection matchedLiElements = regex.Matches(currentUlHtml);
					// throws a custom exception if none are provided
					if (matchedUlElements.Count <= 0)
						throw new HtmlElementNotFoundException("li");

					for (int j = 0; j < matchedLiElements.Count; j++)
					{
						string currentLiHtml = matchedLiElements[j].Value;
						regex = new Regex(ElementTextRegexPattern);
						// find li element(s)
						MatchCollection matchedContent = regex.Matches(currentLiHtml);
						// throws a custom exception if none are provided
						if (matchedContent.Count <= 0)
							throw new ContentNotFoundException("li");

						for (int k = 0; k < matchedContent.Count; k++)
						{
							string currentContent = matchedContent[k].Value;
							currentContent = currentContent.Substring(1, currentContent.Length - 2);
							result.Add(currentContent);
						}
					}
				}
			}
			catch (HtmlElementNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
			catch (ContentNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}

			return result;
		}
	}
}
