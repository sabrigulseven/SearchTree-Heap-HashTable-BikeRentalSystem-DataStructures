using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P3
{
    class QuickSort
    {
        List<int> list = new List<int>();

        public QuickSort(List<int> list)
        {
            this.list = list;
        }
        public int Partition( int low,int high)
        {
            int pivot = list[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    int temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
            int temp1 = list[i + 1];
            list[i + 1] = list[high];
            list[high] = temp1;
            return i + 1;
        }

        public void quickSort( int low, int high)
        {
            if (low < high)
            {
                int partition = Partition(low, high);
                quickSort( low, partition - 1);
                quickSort( partition + 1, high);
            }
        }
    }
}
