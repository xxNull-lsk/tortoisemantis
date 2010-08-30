using System.Collections;
using System.Windows.Forms;

namespace TortoiseMantis
{
    internal class IssuesListColumnSorter : IComparer
    {
        private int sortColumn;
        private SortOrder sortOrder;
        private CaseInsensitiveComparer objectCompare;

        public IssuesListColumnSorter()
	    {
            sortColumn = 0;
            sortOrder = SortOrder.Ascending;
            objectCompare = new CaseInsensitiveComparer();
	    }

        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem a = (ListViewItem)x;
            ListViewItem b = (ListViewItem)y;
            compareResult = objectCompare.Compare(a.SubItems[sortColumn].Text, b.SubItems[sortColumn].Text);
            if (sortOrder == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (sortOrder == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }

        public int SortColumn
        {
            set
            {
                sortColumn = value;
            }
            get
            {
                return sortColumn;
            }
        }


        public SortOrder SortOrder
        {
            set
            {
                sortOrder = value;
            }
            get
            {
                return sortOrder;
            }
        }

    }
}
