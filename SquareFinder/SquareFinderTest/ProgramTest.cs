using System;
using System.IO;
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
    public void Run_Main_WithNonExistentFile()
    {
        var exitCode = Program.Main(new []{ "dummyFile"});
        exitCode.Should().Be(1);
    }

    [Fact]
    public void Run_Main_WithEmptyFile()
    {
        // TODO: use System.IO.Abstractions (https://github.com/TestableIO/System.IO.Abstractions)
        var fileName = "dummyEmptyFile";
        File.WriteAllLines(fileName, Array.Empty<string>());
        var exitCode = Program.Main(new []{ fileName});
        exitCode.Should().Be(0);
        File.Delete(fileName);
    }

    [Fact]
    public void Run_Main_WithDummyFile()
    {
        // TODO: use System.IO.Abstractions (https://github.com/TestableIO/System.IO.Abstractions)
        var fileName = "dummyFileWithData";
        File.WriteAllLines(fileName, new []{ "1 1" });
        var exitCode = Program.Main(new []{ fileName});
        exitCode.Should().Be(0);
        File.Delete(fileName);
    }
}
