using System;
using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Strategies;
using Itmo.ObjectOrientedProgramming.Lab4.StrategiesInterfaces;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Fact]
    public void TestConnect()
    {
        var mockInput = new Mock<IInputStrategy>();
        mockInput.Setup(m => m.Compile()).Returns("connect /Users/ivanbaskatov -m local");
        var mockOutput = new Mock<IOutputStrategy>();
        mockOutput.Setup(m => m.Compile(It.IsAny<string>()));
        var inputContext = new InputContext(mockInput.Object);
        var outputContext = new OutputContext(mockOutput.Object);
        string command = inputContext.CompileStrategy();
        Compilator.Compile(command, mockOutput.Object);
        Assert.Equal("/Users/ivanbaskatov", ConnectStrategy.CurrentDirectory);
    }

    [Fact]
    public void TestDisconnect()
    {
        var mockInput = new Mock<IInputStrategy>();
        mockInput.Setup(m => m.Compile()).Returns("disconnect");
        var mockOutput = new Mock<IOutputStrategy>();
        mockOutput.Setup(m => m.Compile(It.IsAny<string>()));
        var inputContext = new InputContext(mockInput.Object);
        var outputContext = new OutputContext(mockOutput.Object);
        string command = inputContext.CompileStrategy();
        Compilator.Compile(command, mockOutput.Object);
        Assert.Null(ConnectStrategy.CurrentDirectory);
    }

    [Fact]
    public void TestCopy()
    {
        var mockInput = new Mock<IInputStrategy>();
        mockInput.Setup(m => m.Compile()).Returns("connect /Users/ivanbaskatov -m local");
        var output = new StringBuilder();
        var mockOutput = new Mock<IOutputStrategy>();
        mockOutput.Setup(m => m.Compile(It.IsAny<string>())).Callback<string>(s => output.AppendLine(s));
        var inputContext = new InputContext(mockInput.Object);
        var outputContext = new OutputContext(mockOutput.Object);
        string command = inputContext.CompileStrategy();
        Compilator.Compile(command, mockOutput.Object);
        Assert.NotNull(ConnectStrategy.CurrentDirectory);
        Directory.CreateDirectory(Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder"));
        File.WriteAllText(Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "File.txt"), "expected content");
        command = "fileCopy Study/File.txt Study/Folder";
        Compilator.Compile(command, mockOutput.Object);
        string newFilePath = Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder", "File.txt");
        Assert.True(File.Exists(newFilePath));
    }

    [Fact]
    public void TestDelete()
    {
        var mockInput = new Mock<IInputStrategy>();
        mockInput.Setup(m => m.Compile()).Returns("connect /Users/ivanbaskatov -m local");
        var output = new StringBuilder();
        var mockOutput = new Mock<IOutputStrategy>();
        mockOutput.Setup(m => m.Compile(It.IsAny<string>())).Callback<string>(s => output.AppendLine(s));
        var inputContext = new InputContext(mockInput.Object);
        var outputContext = new OutputContext(mockOutput.Object);
        string command = inputContext.CompileStrategy();
        Compilator.Compile(command, mockOutput.Object);
        Assert.NotNull(ConnectStrategy.CurrentDirectory);
        Directory.CreateDirectory(Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder"));
        File.WriteAllText(Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder", "DeleteTestFile.txt"), "expected content");
        string newFilePath = Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder", "DeleteTestFile.txt");
        Assert.True(File.Exists(newFilePath));
        command = "fileDelete Study/Folder/DeleteTestFile.txt";
        Compilator.Compile(command, mockOutput.Object);
        Assert.False(File.Exists(newFilePath));
    }

    [Fact]
    public void TestMove()
    {
        var mockInput = new Mock<IInputStrategy>();
        mockInput.Setup(m => m.Compile()).Returns("connect /Users/ivanbaskatov -m local");
        var output = new StringBuilder();
        var mockOutput = new Mock<IOutputStrategy>();
        mockOutput.Setup(m => m.Compile(It.IsAny<string>())).Callback<string>(s => output.AppendLine(s));
        var inputContext = new InputContext(mockInput.Object);
        var outputContext = new OutputContext(mockOutput.Object);
        string command = inputContext.CompileStrategy();
        Compilator.Compile(command, mockOutput.Object);
        Assert.NotNull(ConnectStrategy.CurrentDirectory);
        Directory.CreateDirectory(Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder"));
        File.WriteAllText(Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder", "File.txt"), "expected content");
        command = "fileMove Study/Folder/File.txt Study";
        Compilator.Compile(command, mockOutput.Object);
        string newFilePath = Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "File.txt");
        Assert.True(File.Exists(newFilePath));
    }

    [Fact]
    public void TestRename()
    {
        var mockInput = new Mock<IInputStrategy>();
        mockInput.Setup(m => m.Compile()).Returns("connect /Users/ivanbaskatov -m local");
        var output = new StringBuilder();
        var mockOutput = new Mock<IOutputStrategy>();
        mockOutput.Setup(m => m.Compile(It.IsAny<string>())).Callback<string>(s => output.AppendLine(s));
        var inputContext = new InputContext(mockInput.Object);
        var outputContext = new OutputContext(mockOutput.Object);
        string command = inputContext.CompileStrategy();
        Compilator.Compile(command, mockOutput.Object);
        Assert.NotNull(ConnectStrategy.CurrentDirectory);
        Directory.CreateDirectory(Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder"));
        File.WriteAllText(Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder", "DeleteTestFile.txt"), "expected content");
        string newFilePath = Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder", "DeleteTestFile.txt");
        Assert.True(File.Exists(newFilePath));
        command = "fileRename Study/Folder/DeleteTestFile.txt TestFileRename.txt";
        Compilator.Compile(command, mockOutput.Object);
        newFilePath = Path.Combine(ConnectStrategy.CurrentDirectory, "Study", "Folder", "TestFileRename.txt");
        Assert.True(File.Exists(newFilePath));
    }

    [Fact]
    public void TestFileShow()
    {
        var input = new Mock<IInputStrategy>();
        input.Setup(m => m.Compile()).Returns("connect /Users/ivanbaskatov/Study -m local");
        var message = new StringBuilder();
        var output = new Mock<IOutputStrategy>();
        output.Setup(m => m.Compile(It.IsAny<string>())).Callback<string>(s => message.AppendLine(s));
        var inputContext = new InputContext(input.Object);
        var outputContext = new OutputContext(output.Object);
        string command = inputContext.CompileStrategy();
        Compilator.Compile(command, output.Object);
        Assert.NotNull(ConnectStrategy.CurrentDirectory);
        Directory.CreateDirectory(Path.Combine(ConnectStrategy.CurrentDirectory, "Folder"));
        File.WriteAllText(Path.Combine(ConnectStrategy.CurrentDirectory, "Folder", "What.txt"), "expected content");
        command = "fileShow Folder/What.txt -m console";
        Compilator.Compile(command, output.Object);
        Assert.Contains("expected content", message.ToString(), StringComparison.Ordinal);
        output.Verify(m => m.Compile(It.IsAny<string>()), Times.AtLeastOnce());
    }
}