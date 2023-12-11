using DiamondGame.Contracts;

namespace DiamondGame;

public class DiamondEngine(IDiamondLetterReader diamondLetterReader, IDiamondGenerator diamondGenerator, IDiamondPresenter diamondPresenter)
{
	internal const string ArgsDiamondLetterReaderNullExceptionMessage = $"Value cannot be null. (Parameter '{nameof(diamondLetterReader)}')";
	internal const string ArgsDiamondGeneratorNullExceptionMessage = $"Value cannot be null. (Parameter '{nameof(diamondGenerator)}')";
	internal const string ArgsDiamondPresenterNullExceptionMessage = $"Value cannot be null. (Parameter '{nameof(diamondPresenter)}')";
	internal const string InvalidDiamondSolutionExceptionMessage = "Diamond solution was not found. Please generate diamond first by calling GenerateDiamond method";

	internal char DiamondLetter => diamondLetter;
	internal string Diamon => diamond;

	private char diamondLetter = default;
	private string diamond;

	private readonly IDiamondLetterReader diamondLetterReader = diamondLetterReader ?? throw new ArgumentNullException(nameof(diamondLetterReader));
	private readonly IDiamondGenerator diamondEngine = diamondGenerator ?? throw new ArgumentNullException(nameof(diamondGenerator));
	private readonly IDiamondPresenter diamondPresenter = diamondPresenter ?? throw new ArgumentNullException(nameof(diamondPresenter));

	public void Initialize(string[] args)
	{
		diamondLetter = diamondLetterReader.GetLetterFromArguments(args);
	}

	public void GenerateDiamond()
	{
		diamond = diamondEngine.GenerateDiamond(diamondLetter);
	}

	public void ShowResults()
	{
		if (diamond == null)
		{
			throw new InvalidOperationException(InvalidDiamondSolutionExceptionMessage);
		}

		diamondPresenter.DisplayDiamond(diamond);
	}
}
