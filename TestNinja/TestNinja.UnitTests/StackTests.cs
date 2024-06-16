using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    internal class StackTests
    {
        [Test]
        public void Push_WhenCalled_ObjectNull()
        {
            var stack = new Stack<string>();
            Assert.Throws<ArgumentNullException>(() => stack.Push(null), "Null element");
        }

        [Test]
        public void Push_WhenCalled_ObjectNotNull()
        {

            var stack = new Stack<string>();
            var newElement = "random element";

            stack.Push(newElement);
            Assert.That(stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();
            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public void Pop_StackWithFewObjects_ReturnObjectOnTheTop()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");
            
            var result = stack.Pop();
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Pop_StackWithFewObjects_RemoveTopOfStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();
            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_EmptyStack_ThrowInvalidOperationException()
        {
            var stack = new Stack<string>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void Peek_StackWithFewObjects_ReturnObjectOnTopOfTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();
            Assert.That(result, Is.EqualTo("c"));
        }

        public void Peek_StackWithFewObjects_DoesNotRemoveTopOfStack()
        {
            var stack = new Stack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();
            Assert.That(stack.Count, Is.EqualTo(3));
        }
    }
}
