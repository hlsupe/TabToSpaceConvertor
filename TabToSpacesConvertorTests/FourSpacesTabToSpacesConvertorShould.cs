using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TabToSpacesConvertorTests
{
    [TestClass]
    public class FourSpacesTabToSpacesConvertorShould
    {
        [TestMethod]
        public void ReturnEmptyStringWhenEmptyStringProvided()
            => Assert.AreEqual(string.Empty, FourSpacesTabConvertor().Convert(string.Empty));

        [TestMethod]
        public void ReturnNullStringWhenNullStringProvided()
            => Assert.AreEqual(null, FourSpacesTabConvertor().Convert(null));

        [TestMethod]
        public void ReplaceWith4SpacesWhenTabIsAlreadyAtTabStop()
            => Assert.AreEqual("Test" + RepeatSpaces(4) + "String", FourSpacesTabConvertor().Convert("Test\tString"));

        [TestMethod]
        public void ReplaceWith8SpacesWhenTabIsAlreadyAtTabStopAndFollowedByAnotherTab()
            => Assert.AreEqual("Test" + RepeatSpaces(8) + "String", FourSpacesTabConvertor().Convert("Test\t\tString"));

        [TestMethod]
        public void ReplaceWith3SpacesWhenTabIsAtSecondCharacter()
            => Assert.AreEqual("T" + RepeatSpaces(3) + "String", FourSpacesTabConvertor().Convert("T\tString"));

        [TestMethod]
        public void ReplaceWith2SpacesWhenTabIsAtThirdCharacter()
            => Assert.AreEqual("Te" + RepeatSpaces(2) + "String", FourSpacesTabConvertor().Convert("Te\tString"));

        [TestMethod]
        public void ReplaceWith1SpacesWhenTabIsAtFourthCharacter()
            => Assert.AreEqual("Tes" + RepeatSpaces(1) + "String", FourSpacesTabConvertor().Convert("Tes\tString"));

        [TestMethod]
        public void PreserveNewLineCharacters() =>
            Assert.AreEqual("Tes" + RepeatSpaces(1) + "\nString\n",
                FourSpacesTabConvertor().Convert("Tes\t\nString\n"));

        [TestMethod]
        public void PreserveMultipleNewLineCharactersBackToBack() =>
            Assert.AreEqual("Tes" + RepeatSpaces(1) + "\n\n\nString\n",
                FourSpacesTabConvertor().Convert("Tes\t\n\n\nString\n"));

        private TabToSpacesConvertor.TabToSpacesConvertor FourSpacesTabConvertor() =>
            new TabToSpacesConvertor.TabToSpacesConvertor(4);

        private string RepeatSpaces(int spacesToAdd) => new string(' ', spacesToAdd);
    }
}