namespace AnagramGrouperTests;

using System.Collections.Generic;
using AnagramGrouper;

public class AnagramGrouperTest
{
    [Fact]
    public void GroupAnnagrams_BasicCase()
    {
        // arange
        AnagramGrouper grouper = new();
        List<string> words = new() { "ток", "рост", "кот", "торс", "Кто", "фывап", "рок" };

        List<List<string>> expected = new()
        {
            new List<string>() { "ток", "кот", "Кто" },
            new List<string>() { "рост", "торс" },
            new List<string>() { "фывап" },
            new List<string>() { "рок" }
        };

        // act
        var actual = grouper.GroupAnnagrams(words);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GroupAnnagrams_EmptyWordsList()
    {
        // arange
        AnagramGrouper grouper = new();
        List<string> words = new();

        List<List<string>> expected = new();

        // act
        var actual = grouper.GroupAnnagrams(words);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GroupAnnagrams_ExtendedUnicode()
    {
        // arange
        AnagramGrouper grouper = new();
        List<string> words = new() { "こんにちは", "マグサトです", "はちにんこ" };

        List<List<string>> expected = new()
        {
            new List<string>() { "こんにちは", "はちにんこ" },
            new List<string>() { "マグサトです" }
        };

        // act
        var actual = grouper.GroupAnnagrams(words);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GroupAnnagrams_TwoTimesRepeatedCharacters()
    {
        // arange
        AnagramGrouper grouper = new();
        List<string> words = new() { "ток", "кот", "ктоо", "кто", "окот" };

        List<List<string>> expected = new()
        {
            new List<string>() { "ток", "кот", "кто" },
            new List<string>() { "ктоо", "окот" }
        };

        // act
        var actual = grouper.GroupAnnagrams(words);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GroupAnnagrams_MultipleTimesRepeatedCharacters()
    {
        // arange
        AnagramGrouper grouper = new();
        List<string> words = new() { "аааббаа", "абабааа", "бббббаа", "ббаббаб" };

        List<List<string>> expected = new()
        {
            new List<string>() { "аааббаа", "абабааа" },
            new List<string>() { "бббббаа", "ббаббаб" }
        };

        // act
        var actual = grouper.GroupAnnagrams(words);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GroupAnnagrams_AllWordsEmpty()
    {
        // arange
        AnagramGrouper grouper = new();
        List<string> words = new() { "", "", "", "" };

        List<List<string>> expected = new()
        {
            new List<string>() { "", "", "", "" }
        };

        // act
        var actual = grouper.GroupAnnagrams(words);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GroupAnnagrams_SingleEmptyWord()
    {
        // arange
        AnagramGrouper grouper = new();
        List<string> words = new() { "a", "b", "c", "" };

        List<List<string>> expected = new()
        {
            new List<string>() { "a" },
            new List<string>() { "b" },
            new List<string>() { "c" },
            new List<string>() { "" },
        };

        // act
        var actual = grouper.GroupAnnagrams(words);

        // assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GroupAnnagrams_BasicOrder()
    {
        // arange
        AnagramGrouper grouper = new();
        List<string> words = new() { "abcdef", "zxc", "cxz", "xzc" };

        List<List<string>> expected = new()
        {
            new List<string>() { "abcdef" },
            new List<string>() { "zxc", "cxz", "xzc" }
        };

        // act
        var actual = grouper.GroupAnnagrams(words);

        // assert
        Assert.Equal(expected, actual);
    }
}