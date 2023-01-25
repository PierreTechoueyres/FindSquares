using System;
using System.IO;
using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;
using SquareFinder;
using Xunit;

namespace SquareFinderTest;

public class ProgramTest
{
    [Fact]
    public void Run_Main_WithoutParams()
    {
        var exitCode = Program.Main(Array.Empty<string>());
        exitCode.Should().Be(1);
    }

    [Fact]
    public void Run_Main_WithParams()
    {
        var fileName = "dummyEmptyFile";
        var fs = new MockFileSystem();
        fs.AddFile(fileName, new MockFileData(""));
        Program.FileSystem = fs;
        var exitCode = Program.Main(new[] { fileName });
        exitCode.Should().Be(0);
    }

    [Fact]
    public void Run_FindSquares_WithoutParams()
    {
        var exitCode = Program.FindSquares(new MockFileSystem(), "");
        exitCode.Should().Be(1);
    }

    [Fact]
    public void Run_FindSquares_WithNonExistentFile()
    {
        var fs = new MockFileSystem();
        var exitCode = Program.FindSquares(fs, "dummyFile");
        exitCode.Should().Be(1);
    }

    [Fact]
    public void Run_FindSquares_WithEmptyFile()
    {
        var fileName = "dummyEmptyFile";
        var fs = new MockFileSystem();
        fs.AddFile(fileName, new MockFileData(""));
        var exitCode = Program.FindSquares(fs, fileName);
        exitCode.Should().Be(0);
    }

    [Fact]
    public void Run_FindSquares_WithInvalidData()
    {
        var fileName = "dummyFileWithData";
        var fs = new MockFileSystem();
        fs.AddFile(fileName, new MockFileData("1 a"));
        var exitCode = Program.FindSquares(fs, fileName);
        exitCode.Should().Be(0);
        File.Delete(fileName);
    }

    [Fact]
    public void Run_FindSquares_WithData()
    {
        var fileName = "dummyFileWithData";
        var fs = new MockFileSystem();
        fs.AddFile(fileName, new MockFileData("1 1"));
        var exitCode = Program.FindSquares(fs, fileName);
        exitCode.Should().Be(0);
        File.Delete(fileName);
    }
}
