using NUnit.Framework;

namespace TestAndLearn.Tests.Sorting
{
    [TestFixture()]
    class InsertionSort
    {
        [Test]
        public void Insertion_Sort_Big_O()
        {
            var input = new[] {23, 1, 3, 4, 2, 12};
            InsertionSortImpl(input);
            CollectionAssert.AreEqual(input, (new[] {1, 2, 3, 4, 12, 23}));
        }

        private void InsertionSortImpl(int[] input)
        {
            for (int i = 1; i < input.Length; i++)
            {
                var j = i-1;
                var anchor = input[i];
                while (j>=0 && anchor < input[j])
                {
                    var tmp = input[j];
                    input[j] = input[j+1];
                    input[j+1] = tmp;
                    j--;
                }
            }

        }
    }
}