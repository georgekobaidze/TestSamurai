using System;
using NUnit.Framework;

namespace TestSamurai.NUnitTests;

[TestFixture]
public class StackTests
{
    private Stack<string> _stack;

    [SetUp]
    public void SetUp() => _stack = new Stack<string>();

    [Test]
    public void Count_EmptyStack_ReturnsZero()
    {
        var result = _stack.Count;
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void Push_ItemIsNullStackIsEmpty_ThrowsArgumentNullException() 
        => Assert.Throws<ArgumentNullException>(() => _stack.Push(null));

    [Test]
    public void Push_WhenCalled_AddsItemAtTheEndOfTheStack()
    {
        _stack.Push("a");
        _stack.Push("b");
        _stack.Push("c");

        Assert.That(_stack.Count, Is.EqualTo(3));

        var lastItem = _stack.Pop();
        Assert.That(lastItem, Is.EqualTo("c"));
        Assert.That(_stack.Count, Is.EqualTo(2));

        lastItem = _stack.Pop();
        Assert.That(lastItem, Is.EqualTo("b"));
        Assert.That(_stack.Count, Is.EqualTo(1));

        lastItem = _stack.Pop();
        Assert.That(lastItem, Is.EqualTo("a"));
        Assert.That(_stack.Count, Is.EqualTo(0));
    }

    [Test]
    public void Pop_StackIsEmpty_ThrowInvalidOperationException() 
        => Assert.Throws<InvalidOperationException>(() => _stack.Pop());

    [Test]
    public void Pop_StackIsNotEmpty_DeletesAndReturnsLastAddedItem()
    {
        _stack.Push("a");
        _stack.Push("b");
        _stack.Push("c");
        var result = _stack.Pop();

        Assert.That(_stack.Count, Is.EqualTo(2));
        Assert.That(result, Is.EqualTo("c"));
    }

    [Test]
    public void Peek_StackIsEmpty_ThrowInvalidOperationException()
        => Assert.Throws<InvalidOperationException>(() => _stack.Peek());

    [Test]
    public void Peek_StackIsNotEmpty_ReturnsLastAddedItem()
    {
        _stack.Push("a");
        _stack.Push("b");
        _stack.Push("c");
        var result = _stack.Peek();

        Assert.That(_stack.Count, Is.EqualTo(3));
        Assert.That(result, Is.EqualTo("c"));
    }
}
