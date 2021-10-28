// **************************************************************************** //
// This file is not currently used for anything, but could be useful
// in any future revision of the DataGridView columns
// ************************************************************* //

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskKiller
{
    public class MemoryDataRowComparer : System.Collections.IComparer
    {
        private static int sortOrderModifier = 1;
        public MemoryDataRowComparer(SortOrder sortOrder)
        {
            if (sortOrder == SortOrder.Descending)
            {
                sortOrderModifier = -1;
            }
            else if (sortOrder == SortOrder.Ascending)
            {
                sortOrderModifier = 1;
            }
        }

        [Obsolete("This is unimplemented", false)]
        public int Compare(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            return 0;
        }

        [Obsolete("This is too slow for some reason", true)]
        public int Compare_OLD(object x, object y)
        {
            DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
            DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;

            Extend.SizeUnits ExtractedUnit1 = Extend.GetUnit(DataGridViewRow1.Cells[3].Value.ToString());
            Extend.SizeUnits ExtractedUnit2 = Extend.GetUnit(DataGridViewRow2.Cells[3].Value.ToString());

            int CompareResult = -(int)ExtractedUnit1 + (int)ExtractedUnit2;
            if(CompareResult == 0) 
            { 
                CompareResult = Convert.ToInt32(-Extend.RemoveSizeUnit(DataGridViewRow1.Cells[3].Value.ToString()) 
                    + -Extend.RemoveSizeUnit(DataGridViewRow2.Cells[3].Value.ToString())); 
            }

            return CompareResult * sortOrderModifier;
        }
    }
}
