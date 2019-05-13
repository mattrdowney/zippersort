using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BinaryHeap
{
    // FIXME: in practice, you want to do some safeguarding. I know that I will be switching to insertion sort for e.g. a size-16 heap and smaller, but this should handle begin > end or size 0-15

    // 0-indexed binary heap that contains two single nodes. E.g. siblings per level = 1, 1, 2, 4, 8, 16 ...
    public static void build_forward_minimum_heap(ref List<int> mutable_list, int begin_index, int end_index) // iterative, not recursive
    {
        int size = end_index - begin_index + 1;
        int perfect_row_start = Mathf.NextPowerOfTwo(size)/2;

        // handle the imperfect row (if it exists)
        if (size != perfect_row_start)
        {
            int child_index = size;
            int parent_index = forward_parent(child_index, begin_index, end_index);
            if ((child_index % 2) == 1) // we found an odd child out who doesn't have a sibling
            {
                if (mutable_list[parent_index] > mutable_list[child_index])
                {
                    swap(ref mutable_list, parent_index, child_index);
                }
                child_index -= 1;
                parent_index -= 1;
            }
            while (child_index > perfect_row_start) // this might never run if there was only an odd child out
            {
                int left_child = child_index - 1;
                int right_child = child_index;

                if (mutable_list[left_child] > mutable_list[right_child])
                {
                    swap(ref mutable_list, left_child, right_child);
                }
                if (mutable_list[parent_index] > mutable_list[left_child])
                {
                    swap(ref mutable_list, parent_index, left_child);
                }

                parent_index -= 1;
                child_index -= 2;
            }
        }

        // handle the perfect rows
    }

    // 0-indexed (but negative-valued) binary heap that contains two single nodes. E.g. siblings per level = ... 16, 8, 4, 2, 1, 1
    public static void build_reversed_maximum_heap(ref List<int> mutable_list, int begin_index, int end_index) // iterative, not recursive
    {

    }

    public static void swap(ref List<int> mutable_list, int left, int right)
    {
        int swapper = mutable_list[left];
        mutable_list[left] = mutable_list[right];
        mutable_list[right] = swapper;
    }

    // Helper functions for finding relative nodes -- try not to use in critical sections

    public static int forward_parent(int current, int begin_index, int end_index)
    {
        return (current - begin_index)/2 + begin_index;
    }

    public static int forward_left_child(int current, int begin_index, int end_index)
    {
        return ((current - begin_index)*2 + 0) + begin_index;
    }

    public static int forward_right_child(int current, int begin_index, int end_index)
    {
        return ((current - begin_index)*2 + 1) + begin_index;
    }

    public static int reversed_parent(int current, int begin_index, int end_index)
    {
        return (current - end_index)/2 + end_index;
    }

    public static int reversed_left_child(int current, int begin_index, int end_index)
    {
        return ((current - end_index)*2 - 1) + end_index;
    }

    public static int reversed_right_child(int current, int begin_index, int end_index)
    {
        return ((current - end_index)*2 - 0) + end_index;
    }
}
