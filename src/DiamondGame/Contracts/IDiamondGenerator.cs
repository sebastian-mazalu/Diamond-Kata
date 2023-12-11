namespace DiamondGame.Contracts;

public interface IDiamondGenerator
{
    string GenerateDiamond(char diamondLetter, bool displayWhiteSpaces = false);
}