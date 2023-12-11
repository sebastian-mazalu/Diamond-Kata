using DiamondGame.Contracts;
using System.Runtime.InteropServices;
using System.Text;

namespace DiamondGame;

public class DiamondGenerator : IDiamondGenerator
{
	public string GenerateDiamond(char diamondLetter, bool displayWhiteSpaces = false)
	{
		if (diamondLetter == 'A') return GetDiamondA(displayWhiteSpaces);

		if (diamondLetter == 'B') return GetDiamondB(displayWhiteSpaces);

		return GetDiamond(diamondLetter, displayWhiteSpaces);
	}

	private static string GetDiamondA(bool displayWhiteSpaces) => "A";

	private static string GetDiamondB(bool displayWhiteSpaces) =>
		displayWhiteSpaces ?
			$"_ A _ {Environment.NewLine}B _ B{Environment.NewLine}_ A _ " :
			$" A {Environment.NewLine}B B{Environment.NewLine} A ";

	private static string GetDiamond(char diamondLetter, bool displayWhiteSpaces)
	{
		var diamondBuilder = new StringBuilder();

		diamondBuilder = BuildTheFirstHalfOfTheDiamond(diamondLetter, displayWhiteSpaces, diamondBuilder);

		diamondBuilder = BuildTheMiddleLineOfTheDiamond(diamondLetter, displayWhiteSpaces, diamondBuilder);

		diamondBuilder = BuildTheSecondHalfOfTheDiamond(diamondLetter, displayWhiteSpaces, diamondBuilder);

		return diamondBuilder.ToString().TrimEnd(Environment.NewLine.ToCharArray());
	}

	private static StringBuilder BuildTheFirstHalfOfTheDiamond(char diamondLetter, bool displayWhiteSpaces, StringBuilder diamondBuilder)
	{
		var maxDistanceBetweenLetters = diamondLetter - 'A';
		var currentLetter = 'A';
		var i = maxDistanceBetweenLetters;
		var separator = displayWhiteSpaces ? "_ " : " ";

		for (; i > 0; i--, currentLetter++)
		{
			var spacesToFirstLetter = new StringBuilder().Insert(0, separator, i).ToString();
			var currentLetterTermination = displayWhiteSpaces ? " " : "";

			if (currentLetter == 'A')
			{
				diamondBuilder.AppendLine($"{spacesToFirstLetter}A{currentLetterTermination}{spacesToFirstLetter}");
			}
			else
			{
				var spacesBetweenLetters = new StringBuilder().Insert(0, separator, (maxDistanceBetweenLetters - i) * 2 - 1).ToString();
				var currentLine = string.Format("{0}{1}{2}{3}{1}{2}{0}", spacesToFirstLetter, currentLetter, currentLetterTermination, spacesBetweenLetters);

				diamondBuilder.AppendLine(currentLine);
			}
		}

		return diamondBuilder;
	}

	private static StringBuilder BuildTheMiddleLineOfTheDiamond(char diamondLetter, bool displayWhiteSpaces, StringBuilder diamondBuilder)
	{
		var maxDistanceBetweenLetters = diamondLetter - 'A';
		var separator = displayWhiteSpaces ? "_ " : " ";
		var currentLetterTermination = displayWhiteSpaces ? " " : "";

		var spacesBetweenLetters = new StringBuilder().Insert(0, separator, maxDistanceBetweenLetters * 2 - 1).ToString();
		var currentLine = string.Format("{0}{1}{2}{0}", diamondLetter, currentLetterTermination, spacesBetweenLetters);

		diamondBuilder.AppendLine(currentLine);

		return diamondBuilder;
	}

	private static StringBuilder BuildTheSecondHalfOfTheDiamond(char diamondLetter, bool displayWhiteSpaces, StringBuilder diamondBuilder)
	{
		var maxDistanceBetweenLetters = diamondLetter - 'A';
		var currentLetter = diamondLetter;
		currentLetter--;
		var i = 1;
		var separator = displayWhiteSpaces ? "_ " : " ";

		for (; i <= maxDistanceBetweenLetters; i++, currentLetter--)
		{
			var spacesToFirstLetter = new StringBuilder().Insert(0, separator, i).ToString();
			var currentLetterTermination = displayWhiteSpaces ? " " : "";

			if (currentLetter == 'A')
			{
				diamondBuilder.AppendLine($"{spacesToFirstLetter}A{currentLetterTermination}{spacesToFirstLetter}");
			}
			else
			{
				var spacesBetweenLetters = new StringBuilder().Insert(0, separator, (maxDistanceBetweenLetters - i) * 2 - 1).ToString();
				var currentLine = string.Format("{0}{1}{2}{3}{1}{2}{0}", spacesToFirstLetter, currentLetter, currentLetterTermination, spacesBetweenLetters);

				diamondBuilder.AppendLine(currentLine);
			}
		}

		return diamondBuilder;
	}
}