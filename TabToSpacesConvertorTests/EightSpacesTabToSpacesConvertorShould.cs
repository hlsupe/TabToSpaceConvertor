using FluentAssertions;
using Xunit;

namespace TabToSpaceConvertorTests
{
	public class EightSpacesTabToSpaceConvertorShould
	{
		private string TabConvertor(string input)
		{
			return new TabToSpacesConvertor.TabToSpacesConvertor(8).Convert(input);
		}

		private string RepeatSpaces(int spacesToAdd)
		{
			return new string(' ', spacesToAdd);
		}

		[FactAttribute]
		public void ReplaceWith1SpacesWhenTabIsAtEighthCharacter()
		{
			TabConvertor("TestStr\ting").Should().Be("TestStr" + RepeatSpaces(1) + "ing");
		}

		[FactAttribute]
		public void ReplaceWith7SpacesWhenTabIsAtSecondCharacter()
		{
			TabConvertor("T\tString").Should().Be("T" + RepeatSpaces(7) + "String");
		}

		[FactAttribute]
		public void ReplaceWith8SpacesWhenTabIsAlreadyAtTabStop()
		{
			TabConvertor("TestStri\tng").Should().Be("TestStri" + RepeatSpaces(8) + "ng");
		}
	}
}