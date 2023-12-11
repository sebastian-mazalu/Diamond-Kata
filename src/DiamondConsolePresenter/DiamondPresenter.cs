using DiamondGame.Contracts;

namespace DiamondConsolePresenter
{
	public class DiamondPresenter : IDiamondPresenter
	{
		public void DisplayDiamond(string diamond)
		{
			Console.WriteLine(diamond);
		}
	}
}
