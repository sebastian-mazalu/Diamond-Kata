using DiamondConsolePresenter;
using DiamondGame;
using DiamondGame.Contracts;

try
{
	IDiamondLetterReader diamLttrRdr = new DiamondLetterReader();
	IDiamondGenerator diamGen = new DiamondGenerator();
	IDiamondPresenter diamPres = new DiamondPresenter();

	var dk = new DiamondEngine(diamLttrRdr, diamGen, diamPres);

	dk.Initialize(args);

	dk.GenerateDiamond();

	dk.ShowResults();
}
catch(Exception ex)
{
	Console.WriteLine(ex.Message);
}
