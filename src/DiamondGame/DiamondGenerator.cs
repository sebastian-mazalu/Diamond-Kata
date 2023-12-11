using DiamondGame.Contracts;

namespace DiamondGame;

public class DiamondGenerator : IDiamondGenerator
{
	public string GenerateDiamond(char diamondLetter, bool displayWhiteSpaces = false)
	{
		return @"
_ _ A _ _
_ B _ B _
C _ _ _ C
_ B _ B _
_ _ A _ _
";
	}
}