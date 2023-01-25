using System;
using FluentAssertions;
using Newtonsoft.Json;
using SquareFinder;
using Xunit;

namespace SquareFinderTest;

public class SquareExceptionTest
{
    [Fact]
    public void CanThrowW()
    {
        var e = new SquareException();

        e.Message.Should().Be($"Exception of type '{typeof(SquareException)}' was thrown.");
    }

    [Fact]
    public void CanThrowWithMessage()
    {
        var e = new SquareException("My message");

        e.Message.Should().Be("My message");
    }

    [Fact]
    public void CanThrowWithMessageAndException()
    {
        var e = new SquareException("My message", new Exception("Another message"));

        e.Message.Should().Be("My message");
        e.InnerException.Should().NotBeNull().And
            .Subject.As<Exception>().Message.Should().Be("Another message");
    }

    [Fact]
    public void CanThrowWithSerialization()
    {
        var exception = new SquareException("My message", new Exception("Another message"));
        var json = JsonConvert.SerializeObject(exception);

        var deserializedException = JsonConvert.DeserializeObject<SquareException>(json);

        deserializedException.Should().BeEquivalentTo(exception);
    }
}
