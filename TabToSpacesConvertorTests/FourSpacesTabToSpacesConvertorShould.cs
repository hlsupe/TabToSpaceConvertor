using FluentAssertions;
using Xunit;

namespace TabToSpacesConvertorTests
{
	public class FourSpacesTabToSpacesConvertorShould
	{
		private string TabConvertor(string input)
		{
			return new TabToSpacesConvertor.TabToSpacesConvertor(4).Convert(input);
		}

		private string RepeatSpaces(int spacesToAdd)
		{
			return new string(' ', spacesToAdd);
		}

		[FactAttribute]
		public void PreserveMultipleNewLineCharactersBackToBack()
		{
			TabConvertor("Tes\t\n\n\nString\n").Should()
				.Be("Tes" + RepeatSpaces(1) + "\n\n\nString\n");
		}

		[FactAttribute]
		public void PreserveNewLineCharacters()
		{
			TabConvertor("Tes\t\nString\n").Should().Be("Tes" + RepeatSpaces(1) + "\nString\n");
		}

		[FactAttribute]
		public void ReplaceWith1SpacesWhenTabIsAtFourthCharacter()
		{
			TabConvertor("Tes\tString").Should().Be("Tes" + RepeatSpaces(1) + "String");
		}

		[FactAttribute]
		public void ReplaceWith2SpacesWhenTabIsAtThirdCharacter()
		{
			TabConvertor("Te\tString").Should().Be("Te" + RepeatSpaces(2) + "String");
		}

		[FactAttribute]
		public void ReplaceWith3SpacesWhenTabIsAtSecondCharacter()
		{
			TabConvertor("T\tString").Should().Be("T" + RepeatSpaces(3) + "String");
		}


		[FactAttribute]
		public void ReplaceWith4SpacesWhenTabIsAlreadyAtTabStop()
		{
			TabConvertor("Test\tString").Should().Be("Test" + RepeatSpaces(4) + "String");
		}

		[FactAttribute]
		public void ReplaceWith8SpacesWhenTabIsAlreadyAtTabStopAndFollowedByAnotherTab()
		{
			TabConvertor("Test\t\tString").Should().Be("Test" + RepeatSpaces(8) + "String");
		}

		[FactAttribute]
		public void ReturnEmptyStringWhenEmptyStringProvided()
		{
			TabConvertor(string.Empty).Should().BeEmpty();
		}

		[FactAttribute]
		public void ReturnNullStringWhenNullStringProvided()
		{
			TabConvertor(null).Should().BeNull();
		}
	}
}