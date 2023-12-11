using DiamondGame;
using FluentAssertions;

namespace DiamondGameTests;

public class DiamondGeneratorTests
{
	private DiamondGenerator sut;

	[SetUp]
	public void Setup()
	{
		sut = new DiamondGenerator();
	}

	[Test]
	[TestCaseSource(nameof(GenerateAllDiamonds))]
	public void When_DiamondGenerator_IsCalled_Proper_Diamond_ShouldBe_Returned((char FirstLetter, bool IncludeWhiteSpaces, string DiamondGeneratedAsString) diamondTestCase)
	{
		// Arrange
		var expectedResult = diamondTestCase.DiamondGeneratedAsString;

		// Act
		var result = sut.GenerateDiamond(diamondTestCase.FirstLetter, diamondTestCase.IncludeWhiteSpaces);

		// Assert
		result.Should().NotBeNull();
		result.Should().Be(expectedResult);
	}

	#region Diamond Test Case Data
	private static IEnumerable<(char FirstLetter, bool IncludeWhiteSpaces, string Diamond)> GenerateAllDiamonds
	{
		get
		{
			yield return (FirstLetter: 'A', IncludeWhiteSpaces: false, Diamond: DiamondExamples.A_False);
			yield return (FirstLetter: 'B', IncludeWhiteSpaces: false, Diamond: DiamondExamples.B_False);
			yield return (FirstLetter: 'C', IncludeWhiteSpaces: false, Diamond: DiamondExamples.C_False);
			yield return (FirstLetter: 'D', IncludeWhiteSpaces: false, Diamond: DiamondExamples.D_False);
			yield return (FirstLetter: 'E', IncludeWhiteSpaces: false, Diamond: DiamondExamples.E_False);

			yield return (FirstLetter: 'A', IncludeWhiteSpaces: true, Diamond: DiamondExamples.A_True);
			yield return (FirstLetter: 'B', IncludeWhiteSpaces: true, Diamond: DiamondExamples.B_True);
			yield return (FirstLetter: 'C', IncludeWhiteSpaces: true, Diamond: DiamondExamples.C_True);
			yield return (FirstLetter: 'D', IncludeWhiteSpaces: true, Diamond: DiamondExamples.D_True);
			yield return (FirstLetter: 'E', IncludeWhiteSpaces: true, Diamond: DiamondExamples.E_True);

			//TO DO : fill remaining diamond test cases up to last letter Z
		}
	}

	#region Diamond String Resources
	private static class DiamondExamples
	{
		internal const string A_False = "A";
		internal const string B_False =
			@" A 
B B
 A ";
		internal const string C_False =
			@"  A  
 B B 
C   C
 B B 
  A  ";
		internal const string D_False =
			@"   A   
  B B  
 C   C 
D     D
 C   C 
  B B  
   A   ";
		internal const string E_False =
			@"    A    
   B B   
  C   C  
 D     D 
E       E
 D     D 
  C   C  
   B B   
    A    ";

		internal const string A_True = "A";
		internal const string B_True =
			@"_ A _ 
B _ B
_ A _ ";
		internal const string C_True =
			@"_ _ A _ _ 
_ B _ B _ 
C _ _ _ C
_ B _ B _ 
_ _ A _ _ ";
		internal const string D_True =
			@"_ _ _ A _ _ _ 
_ _ B _ B _ _ 
_ C _ _ _ C _ 
D _ _ _ _ _ D
_ C _ _ _ C _ 
_ _ B _ B _ _ 
_ _ _ A _ _ _ ";
		internal const string E_True =
			@"_ _ _ _ A _ _ _ _ 
_ _ _ B _ B _ _ _ 
_ _ C _ _ _ C _ _ 
_ D _ _ _ _ _ D _ 
E _ _ _ _ _ _ _ E
_ D _ _ _ _ _ D _ 
_ _ C _ _ _ C _ _ 
_ _ _ B _ B _ _ _ 
_ _ _ _ A _ _ _ _ ";
	}
	#endregion

	#endregion
}
