

using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests {

    [TestFixture]
    class StackTests {

        [Test]
        public void Count_StackIsEmpty_ReturnZero() {

            var stack = new Stack<int>();

            var result = stack.Count;

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Count_StackHasElements_ReturnNumberOfElements() {

            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(1);
            stack.Push(1);

            var result = stack.Count;

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Push_ObjectIsNul_ThrowArgumentNullException() {

            var stack = new Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_ElementIsNotNull_AddedToStack() {

            var stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            Assert.That(stack.Count, Is.EqualTo(3));
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowInvalidOperationException() {

            var stack = new Stack<string>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackIsNotEmpty_ReturnRemovedElement() {

            var stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Pop();

            Assert.That(stack.Count, Is.EqualTo(2));
            Assert.That(result, Is.EqualTo("c"));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowInvalidOperationException() {

            var stack = new Stack<string>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackIsNotEmpty_ReturnLastElement() {

            var stack = new Stack<string>();

            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            var result = stack.Peek();

            Assert.That(result, Is.EqualTo("c"));
        }
    }
}
