using NUnit.Framework;

namespace TestAndLearn.Tests.Sorting
{
    [TestFixture()]
    class BubbleSort
    {
        [Test]
        public void Bubble_Sort_Big_O()
        {
            var input = new[] {23, 1, 3, 4, 2, 12};
            BubbleSortImpl(input);
            CollectionAssert.AreEqual(input,(new[] {1, 2, 3, 4, 12,23}));
        }

        private void BubbleSortImpl(int[] input)
        {
            for (int i = 0; i < input.Length-1; i++)
            {
                for (int j = 1; j < input.Length-i; j++)
                {
                    if (input[j-1] > input[j])
                    {
                        var tmp = input[j];
                        input[j] = input[j-1];
                        input[j-1] = tmp;
                    }
                }
            }
        }

    }
}
