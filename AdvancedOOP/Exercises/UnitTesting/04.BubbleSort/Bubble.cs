namespace _04.BubbleSort
{
    using System;
    using System.Collections.Generic;

    public static class Bubble
    {
        public static void Sort(List<int> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new InvalidOperationException("Collection is empty.");
            }

            bool swapped;
            do
            {
                swapped = false;
                int length = list.Count;
                for (int i = 1; i < length; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        int temp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = temp;
                        swapped = true;
                    }
                }

            } while (swapped);
        }
    }
}