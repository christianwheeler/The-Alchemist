using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace The_Alchemist
{
    /*
     * This class will function as a list for user objects...
     * particularly for, although not limited to, use as a binding list. 
     */
    public class UserList : List<User>
    {
        /*
         * Enumeartion for determining how to sort the user list.
         */
        public enum SortBy
        {
            HighestLevelDesc,
            HighestLevelAsc,
            HighestLevelDateDesc,
            HighestLevelDateAsc,
            NameDesc,
            NameAsc
        }

        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ *
         *                         Attributes                              *
         * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
        private QuickSort sorter = new QuickSort();                                                                     // Responsible for sorting the list

        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ *
         *                          Functions                              *
         * ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */

        /*
         * Sorts the user list with the quick sort attribute object.
         * @param sortBy: determines how to sort the user list.
         */
        public void quickSort(SortBy sortBy)
        {
            sorter.sort(this, sortBy);
        }
    }
}
