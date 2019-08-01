using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TabToSpaceConvertorTests
{
    [TestClass]
    public class EightSpacesTabToSpaceConvertorShould
    {
        [TestMethod]
        public void ReplaceWith8SpacesWhenTabIsAlreadyAtTabStop()
            => Assert.AreEqual("TestStri" + RepeatSpaces(8) + "ng", EightSpacesTabConvertor().Convert("TestStri\tng"));

        [TestMethod]
        public void ReplaceWith7SpacesWhenTabIsAtSecondCharacter()
            => Assert.AreEqual("T" + RepeatSpaces(7) + "String", EightSpacesTabConvertor().Convert("T\tString"));

        [TestMethod]
        public void ReplaceWith1SpacesWhenTabIsAtEighthCharacter()
            => Assert.AreEqual("TestStr" + RepeatSpaces(1) + "ing", EightSpacesTabConvertor().Convert("TestStr\ting"));

        private TabToSpacesConvertor.TabToSpacesConvertor EightSpacesTabConvertor() =>
            new TabToSpacesConvertor.TabToSpacesConvertor(8);

        private string RepeatSpaces(int spacesToAdd) => new string(' ', spacesToAdd);
    }
}