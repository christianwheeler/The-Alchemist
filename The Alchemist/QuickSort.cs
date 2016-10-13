using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Alchemist
{
    /*
     * This class is an implementation of the quick sort algorithm.
     * In our case it will be used to sort the user list according to a defined
     * filter.
     */
    public class QuickSort
    {
        private Random random;                                                                                                // Random number generator to choose a pivot at random
        private UserList.SortBy sortBy;                                                                                       // Determines how to sort the user list

        public QuickSort()
        {
            random = new Random();
        }

        /*
         * Start the recursive function call.
         */
        public void sort(UserList users, UserList.SortBy sortBy)
        {
            this.sortBy = sortBy;
            partition(users, 0, users.Count - 1);
        }

        /*
         * Partition list into upper and lower sections for Quick Sort.
         */
        private void partition(UserList users, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex) return;                                                                                 // If the start index overshoots the last index, then stop partition

            int pivotIndex = choosePivotIndex(users, startIndex, endIndex);
            User pivot = users[pivotIndex];

            swap(users, startIndex, pivotIndex);                                                                                // Swap pivot and first element

            int partitionIndex = startIndex + 1;
            for (int frontierIndex = partitionIndex; frontierIndex <= endIndex; frontierIndex++)
            {
                switch (sortBy)
                {
                    case UserList.SortBy.HighestLevelDesc:
                        if (users[frontierIndex].UserHighestScore.HighestLevel > pivot.UserHighestScore.HighestLevel)           // If the pivot has a lower highest level, then swap
                        {
                            swap(users, frontierIndex, partitionIndex);
                            partitionIndex++;
                        }
                        break;

                    case UserList.SortBy.HighestLevelAsc:
                        if (users[frontierIndex].UserHighestScore.HighestLevel < pivot.UserHighestScore.HighestLevel)           // If the pivot has a greater highest level, then swap
                        {
                            swap(users, frontierIndex, partitionIndex);
                            partitionIndex++;
                        }
                        break;

                    case UserList.SortBy.HighestLevelDateDesc:
                        if (users[frontierIndex].UserHighestScore.HighestLevelDate > pivot.UserHighestScore.HighestLevelDate)   // If the pivot has a lower highest level date, then swap
                        {
                            swap(users, frontierIndex, partitionIndex);
                            partitionIndex++;
                        }
                        break;

                    case UserList.SortBy.HighestLevelDateAsc:
                        if (users[frontierIndex].UserHighestScore.HighestLevelDate > pivot.UserHighestScore.HighestLevelDate)   // If the pivot has a greater highest level, then swap
                        {
                            swap(users, frontierIndex, partitionIndex);
                            partitionIndex++;
                        }
                        break;

                    case UserList.SortBy.NameDesc:
                        if (users[frontierIndex].UserName.CompareTo(pivot.UserName) < 0)                                        // If the pivot has a lower alphabetical position, then swap
                        {
                            swap(users, frontierIndex, partitionIndex);
                            partitionIndex++;
                        }
                        break;

                    case UserList.SortBy.NameAsc:
                        if (users[frontierIndex].UserName.CompareTo(pivot.UserName) > 0)                                        // If the pivot has a greater alphabetical position, then swap
                        {
                            swap(users, frontierIndex, partitionIndex);
                            partitionIndex++;
                        }
                        break;

                    default:
                        if (users[frontierIndex].UserHighestScore.HighestLevel > pivot.UserHighestScore.HighestLevel)           // If something went wrong, sort according to highest level descending
                        {
                            swap(users, frontierIndex, partitionIndex);
                            partitionIndex++;
                        }
                        break;
                }
            }

            users[startIndex] = users[partitionIndex - 1];                                                                      // Place the pivot back in the list
            users[partitionIndex - 1] = pivot;

            partition(users, startIndex, partitionIndex - 2);                                                                   // Recursively sort left half
            partition(users, partitionIndex, endIndex);                                                                         // Recursively sort right half
        }

        /*
         * Choose the next pivot at random.
         */
        protected virtual int choosePivotIndex(UserList users, int startIndex, int endIndex)
        {
            return random.Next(startIndex, endIndex);
        }

        /*
         * Swap users at specifeid indices (parameters).
         */
        private void swap(UserList users, int aIndex, int bIndex)
        {
            User temp = users[aIndex];
            users[aIndex] = users[bIndex];
            users[bIndex] = temp;
        }
    }
}
