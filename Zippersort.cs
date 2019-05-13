using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This sort should be unreasonably bad at sorting nearly-sorted data -- O(n^2)
// To (negligibly) compensate for this, make sure the left and right child comparison is never wasted (by removing an odd number of sorted elements at all times, even if that means keeping a sorted element)

public static class Zippersort
{
    private enum ZipperDirection { Left, Right }

    public static void sort(ref List<int> mutable_list)
    {
        int left_iterator = 0;
        int right_iterator = mutable_list.Count - 1;

        ZipperDirection direction = ZipperDirection.Left;

        while (left_iterator < right_iterator)
        {
            if (right_iterator - left_iterator < 16) // It's hard to know how often this would happen or if the number could be much higher (due to how sorting works)
            {
                // Insertion-Sort()
            }
            if (direction == ZipperDirection.Left)
            {
                // Build-Forward-Min-Heap()
                // Forward-Lazy-Insertion-Sort()
                // skip to 2n and Bubble-Sort-Back()
            }
            else // if (direction == ZipperDirection.Right)
            {
                // Build-Reversed-Max-Heap()
                // Backward-Lazy-Insertion-Sort()
                // skip to 2n and Bubble-Sort-Forward()
            }
        }
    }
}