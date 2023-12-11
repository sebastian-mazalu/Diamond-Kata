using DiamondGame.Contracts;

namespace DiamondGame;

public class DiamondLetterReader : IDiamondLetterReader
{
	internal const string ArgsNullExceptionMessage = "Value cannot be null. (Parameter 'args')";
	internal const string ArgsTooSmallExceptionMessage = "Invalid arguments: it cannot be empty";
	internal const string ArgsTooLongExceptionMessage = "Invalid arguments: it should contain only one argument";

	internal const string FirstArgNullExceptionMessage = "Value cannot be null. (Parameter 'firstArg')";
	internal const string FirstArgTooSmallExceptionMessage = "Invalid arguments: first argument cannot be empty";
	internal const string FirstArgTooLongExceptionMessage = "Invalid arguments: first argument contains more than one character";
	internal const string FirstArgNotUpperLetterMessage = "Invalid arguments: first argument must be an upper letter";

	public char GetLetterFromArguments(string[] args)
	{
		ValidateArgumentsCollection(args);

		ValidateFirstArgument(args[0]);

		return args[0][0];
	}

	private static void ValidateArgumentsCollection(string[] args)
	{
		ArgumentNullException.ThrowIfNull(args);

		switch (args.Length)
		{
			case 0:
				throw new ArgumentException(ArgsTooSmallExceptionMessage);
			case > 1:
				throw new ArgumentException(ArgsTooLongExceptionMessage);
		}
	}

	private static void ValidateFirstArgument(string firstArg)
	{
		ArgumentNullException.ThrowIfNull(firstArg);
		switch (firstArg.Length)
		{
			case 0: throw new ArgumentException(FirstArgTooSmallExceptionMessage);
			case > 1: throw new ArgumentException(FirstArgTooLongExceptionMessage);				
		}

		if (!char.IsAsciiLetterUpper(firstArg[0]))
		{
			throw new ArgumentException(FirstArgNotUpperLetterMessage);
		}
	}
}