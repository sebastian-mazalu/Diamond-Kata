using DiamondGame;
using DiamondGame.Contracts;
using FluentAssertions;
using Moq;

namespace DiamondGameTests
{
	public class DiamondEngineTest
	{
		private Mock<IDiamondLetterReader> diamondLetterReaderMock;
		private Mock<IDiamondGenerator> diamondGeneratorMock;
		private Mock<IDiamondPresenter> diamondPresenterMock;
		private DiamondEngine sut;

		[SetUp]
		public void Setup()
		{
			diamondLetterReaderMock = new Mock<IDiamondLetterReader>();
			diamondGeneratorMock = new Mock<IDiamondGenerator>();
			diamondPresenterMock = new Mock<IDiamondPresenter>();

			sut = new DiamondEngine(diamondLetterReaderMock.Object, diamondGeneratorMock.Object, diamondPresenterMock.Object);
		}

		#region Ctor tests
		[Test]
		[TestCaseSource(nameof(DefaultCtorTestCases))]
		public void WhenArgs_AreNull_DefaultCtor_Should_ThrowException((IDiamondLetterReader DiamondLetterReader, IDiamondGenerator DiamondGenerator, IDiamondPresenter DiamondPresenter) ctorParams)
		{
			// Arrange
			var errorMessage = GetExceptionMessage(ctorParams);
			var act = () => new DiamondEngine(ctorParams.DiamondLetterReader, ctorParams.DiamondGenerator, ctorParams.DiamondPresenter);

			// Act & Assert
			act.Should().Throw<ArgumentNullException>().WithMessage(errorMessage);
		}

		[Test]
		public void WhenArgs_AreOk_DefaultCtor_Should_Build_ANewInstance()
		{
			// Arrange
			var de = default(DiamondEngine);
			var act = () => de = new DiamondEngine(diamondLetterReaderMock.Object, diamondGeneratorMock.Object, diamondPresenterMock.Object);

			// Act & Assert
			act.Should().NotThrow();
			de.Should().NotBeNull();
		}

		private static string GetExceptionMessage((IDiamondLetterReader DiamondLetterReader, IDiamondGenerator DiamondGenerator, IDiamondPresenter DiamondPresenter) ctorParams)
		{

			var errorMessage = default(string);

			if (ctorParams.DiamondLetterReader == null) errorMessage = DiamondEngine.ArgsDiamondLetterReaderNullExceptionMessage;
			else if (ctorParams.DiamondGenerator == null) errorMessage = DiamondEngine.ArgsDiamondGeneratorNullExceptionMessage;
			else if (ctorParams.DiamondPresenter == null) errorMessage = DiamondEngine.ArgsDiamondPresenterNullExceptionMessage;

			return errorMessage;
		}

		private static IEnumerable<(IDiamondLetterReader, IDiamondGenerator, IDiamondPresenter)> DefaultCtorTestCases
		{
			get
			{
				yield return new(default, new DiamondGenerator(), new DiamondPresenterMock());
				yield return new(new DiamondLetterReader(), default, new DiamondPresenterMock());
				yield return new(new DiamondLetterReader(), new DiamondGenerator(), default);

				yield return new(default, default, new DiamondPresenterMock());
				yield return new(new DiamondLetterReader(), default, default);
				yield return new(default, new DiamondGenerator(), default);


				yield return new(default, default, default);
			}
		}

		private class DiamondPresenterMock : IDiamondPresenter
		{
			public void DisplayDiamond(string diamond)
			{
			}
		}
		#endregion

		#region Initialize tests
		[Test]
		public void When_Initialize_IsCalled_ItShould_Call_DiamondLetterReader_And_SaveResult_InLocalField()
		{
			// Arrange
			var firstLetter = 'A';
			diamondLetterReaderMock.Setup(m => m.GetLetterFromArguments(It.IsAny<string[]>())).Returns(firstLetter);

			// Act
			sut.Initialize(default);

			// Assert
			firstLetter.Should().Be(sut.DiamondLetter);
		}

		[Test]
		public void When_Initialize_IsCalled_ItShould_ThrowAnyException_RaisedBy_DiamondLetterReader()
		{
			// Arrange
			var lowLevelException = new Exception("Some low level message");
			diamondLetterReaderMock.Setup(m => m.GetLetterFromArguments(It.IsAny<string[]>())).Throws(() => lowLevelException);

			// Act
			var act = () => sut.Initialize(default);

			// Assert
			act.Should().ThrowExactly<Exception>().WithMessage(lowLevelException.Message);
		}
		#endregion

		#region ShowResults tests
		[Test]
		public void When_ShowResults_IsCalled_AndWeHave_AValidDiamond_ItShould_Call_DiamondPresenter_And_SaveResult_InLocalField()
		{
			// Arrange
			var diamond = "Some diamond";
			diamondGeneratorMock.Setup(m => m.GenerateDiamond(It.IsAny<char>(), false)).Returns(diamond);
			sut.GenerateDiamond();

			// Act
			sut.ShowResults();

			// Assert
			diamondPresenterMock.Verify(m => m.DisplayDiamond(diamond), Times.Once);
		}

		[Test]
		public void When_ShowResults_IsCalled_AndWeHave_AnInvalidDiamond_ItShould_ThrowProperException()
		{
			// Arrange

			// Act
			var act = () => sut.ShowResults();

			// Assert
			act.Should().ThrowExactly<InvalidOperationException>().WithMessage(DiamondEngine.InvalidDiamondSolutionExceptionMessage);
		}

		[Test]
		public void When_ShowResults_IsCalled_ItShould_ThrowAnyException_RaisedBy_DiamondLetterReader()
		{
			// Arrange
			var diamond = "Some diamond";
			diamondGeneratorMock.Setup(m => m.GenerateDiamond(It.IsAny<char>(), false)).Returns(diamond);
			sut.GenerateDiamond();

			var lowLevelException = new Exception("Some low level message");
			diamondPresenterMock.Setup(m => m.DisplayDiamond(It.IsAny<string>())).Throws(() => lowLevelException);

			// Act
			var act = () => sut.ShowResults();

			// Assert
			act.Should().ThrowExactly<Exception>().WithMessage(lowLevelException.Message);
		}
		#endregion
	}
}