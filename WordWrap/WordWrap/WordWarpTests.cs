namespace WordWrap
{
    using Shouldly;

    using Xunit;

    public class WordWarpTests
    {
        [Fact]
        public void IndexOutOfRangeReturnsGivenWord()
        {
            string expected = "a";
            WordWrapper.Wrap(expected, 1).ShouldBe(expected);
        }

        [Fact]
        public void NullResultsInNull()
        {
            WordWrapper.Wrap(null, 7).ShouldBe(null);
        }

        [Fact]
        public void SpaceAtMaxLengthIsReplacedByNewLine()
        {
            WordWrapper.Wrap("a b", 1).ShouldBe("a\nb");
        }

        [Fact]
        public void SpaceBeforeMaxLengthIsReplacedByNewLine()
        {
            WordWrapper.Wrap("a ab", 2).ShouldBe("a\nab");
        }

        [Fact]
        public void SpaceAfterMaxLengthIsReplacedByNewLine()
        {
            WordWrapper.Wrap("aa b", 1).ShouldBe("aa\nb");
        }

        [Fact]
        public void OnlySpacesArroundMaxLengthAreReplacedByNewLine()
        {
            WordWrapper.Wrap("a  ab", 2).ShouldBe("a \nab");
        }

        [Fact]
        public void AllSpacesAtEachMaxLengthAreReplacesByNewLine()
        {
            WordWrapper.Wrap("a a b", 1).ShouldBe("a\na\nb");
        }

        [Fact]
        public void StringsLargerMaxLengthAreSeparatedByNewLineAtMaxLength()
        {
            WordWrapper.Wrap("aab", 2).ShouldBe("aa\nb");
        }

        [Fact]
        public void ComplexeExample()
        {
            WordWrapper.Wrap("Heute ist ein schöner Tag, weil ich meinen Job so mag.", 10).ShouldBe("Heute ist\nein schöner\nTag, weil\nich meinen\nJob so mag.");
        }
    }
}
