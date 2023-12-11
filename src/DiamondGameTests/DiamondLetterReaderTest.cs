using DiamondGame;
using FluentAssertions;

namespace DiamondGameTests
{
	public class DiamondLetterReaderTest
	{
		DiamondLetterReader sut;

		[SetUp]
		public void Setup()
		{
			sut = new DiamondLetterReader();
		}

		#region GetLetterFromArguments
		[Test]
		public void WhenArgs_AreNull_GetLetterFromArguments_Should_ThrowException()
		{
			// Arrange
			var args = default(string[]);
			var act = () => sut.GetLetterFromArguments(args);

			// Act & Assert
			act.Should().Throw<ArgumentException>().WithMessage(DiamondLetterReader.ArgsNullExceptionMessage);
		}

		[Test]
		public void WhenArgs_AreTooShort_GetLetterFromArguments_Should_ThrowException()
		{
			// Arrange
			var args = new string[0];
			var act = () => sut.GetLetterFromArguments(args);

			// Act & Assert
			act.Should().Throw<ArgumentException>().WithMessage(DiamondLetterReader.ArgsTooSmallExceptionMessage);
		}

		[Test]
		public void WhenArgs_AreTooLong_GetLetterFromArguments_Should_ThrowException()
		{
			// Arrange
			var args = new string[2] { string.Empty, default };
			var act = () => sut.GetLetterFromArguments(args);

			// Act & Assert
			act.Should().Throw<ArgumentException>().WithMessage(DiamondLetterReader.ArgsTooLongExceptionMessage);
		}

		[Test]
		public void WhenFirstArg_IsNull_GetLetterFromArguments_Should_ThrowException()
		{
			// Arrange
			var args = new string[1] { default };
			var act = () => sut.GetLetterFromArguments(args);

			// Act & Assert
			act.Should().Throw<ArgumentException>().WithMessage(DiamondLetterReader.FirstArgNullExceptionMessage);
		}

		[Test]
		public void WhenFirstArg_IsTooShort_GetLetterFromArguments_Should_ThrowException()
		{
			// Arrange
			var args = new string[1] { string.Empty };
			var act = () => sut.GetLetterFromArguments(args);

			// Act & Assert
			act.Should().Throw<ArgumentException>().WithMessage(DiamondLetterReader.FirstArgTooSmallExceptionMessage);
		}

		[Test]
		public void WhenFirstArg_IsTooLong_GetLetterFromArguments_Should_ThrowException()
		{
			// Arrange
			var args = new string[1] { "AA" };
			var act = () => sut.GetLetterFromArguments(args);

			// Act & Assert
			act.Should().Throw<ArgumentException>().WithMessage(DiamondLetterReader.FirstArgTooLongExceptionMessage);
		}

		[Test]
		public void WhenFirstArg_IsNotUpperLetter_GetLetterFromArguments_Should_ThrowException()
		{
			// Arrange
			var args = new string[1] { "a" };
			var act = () => sut.GetLetterFromArguments(args);

			// Act & Assert
			act.Should().Throw<ArgumentException>().WithMessage(DiamondLetterReader.FirstArgNotUpperLetterMessage);
		}

		[Test]
		[TestCase("A")]
		[TestCase("B")]
		[TestCase("C")]
		[TestCase("D")]
		[TestCase("E")]
		[TestCase("F")]
		[TestCase("G")]
		[TestCase("H")]
		[TestCase("I")]
		[TestCase("J")]
		[TestCase("K")]
		[TestCase("L")]
		[TestCase("M")]
		[TestCase("N")]
		[TestCase("O")]
		[TestCase("P")]
		[TestCase("Q")]
		[TestCase("R")]
		[TestCase("S")]
		[TestCase("T")]
		[TestCase("U")]
		[TestCase("V")]
		[TestCase("W")]
		[TestCase("X")]
		[TestCase("Y")]
		[TestCase("Z")]
		public void WhenFirstArg_IsOneUpperLetter_GetLetterFromArguments_Should_Return_TheExpectedResult(string firstArg)
		{
			// Arrange
			var args = new string[1] { firstArg };

			var expectedResult = firstArg[0];

			// Act
			var result = sut.GetLetterFromArguments(args);

			// Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}
		#endregion
	}
}