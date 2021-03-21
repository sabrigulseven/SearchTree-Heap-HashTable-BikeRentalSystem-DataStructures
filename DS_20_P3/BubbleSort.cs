using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P3
{
    class BubbleSort
    {
        List<int> list = new List<int>();

        public BubbleSort(List<int> list)
        {
            this.list = list;
        }
        public void BubbleSortInc()//artan sırada sıralayan bubbleSort yöntemi
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                bool sıralı = true;
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] >list[j+1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        sıralı = false;
                    }
                }
                if (sıralı) //eğer liste sıralandığında çıkış yapmasaydık time complexity sürekli worst case O(n^2) olacaktı
                    break;
            }
        }
        public void BubbleSortDec()//azalan sırada sıralayan bubbleSort yöntemi
        {
            bool sıralı = true;
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - 1; j++)
                {
                    if (list[j] < list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                        sıralı = false;
                    }
                }
                if (sıralı) //eğer liste sıralandığında çıkış yapmasaydık time complexity sürekli worst case O(n^2) olacaktı
                    break;
            }
        }

    }
}
