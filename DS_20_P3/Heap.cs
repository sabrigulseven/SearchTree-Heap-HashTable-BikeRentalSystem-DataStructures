using System;
using System.Collections.Generic;

namespace DS_20_P3
{
    public class HeapMax
    {
        public List<Duraklar> heapDizisi = new List<Duraklar>();

        public void InsertElementInHeap(Duraklar value)
        {  
            heapDizisi.Add(value);
            TrickleUp(heapDizisi.Count-1);
            //Console.WriteLine(" " + value.DurakAdi + "  Heap'e eklendi");
        }

        public void TrickleUp(int index)//sona eklenen elemanı parentıyla kıyaslayıp kaldıran metot
        {
            int parent = (index-1) / 2;
            if (index < 1)
                return;
            if (heapDizisi[index].NormalBisiklet > heapDizisi[parent].NormalBisiklet)
            {
                Duraklar tmp = heapDizisi[index];
                heapDizisi[index] = heapDizisi[parent];
                heapDizisi[parent] = tmp;
            }
            TrickleUp(parent);
        }
        public Duraklar remove()
        {
            if (heapDizisi.Count == 0)
            {
                Console.WriteLine("Heap ağacı boş");
                return null;
            }
            else
            {
                Console.WriteLine("Silinen durak: " + heapDizisi[0].DurakAdi + "   Normal bisiklet sayısı: "+heapDizisi[0].NormalBisiklet);
                Duraklar removed = heapDizisi[0];
                heapDizisi[0] = heapDizisi[heapDizisi.Count - 1];
                heapDizisi.RemoveAt(heapDizisi.Count-1);
                TrickleDown(0);
                return removed;
            }
        }
        public void TrickleDown(int index)//başa eklenen değeri childlarıyla kıyaslayıp kaydıran metot
        {
            int left = (index * 2)+1;
            int right = (index * 2) + 2;
            int largestChild = 0;
            if (heapDizisi.Count-1 < left)
                return;
            else if (heapDizisi.Count-1 == left)
            { //Eğer sadece left child'i varsa çalışır   
                if (heapDizisi[index].NormalBisiklet < heapDizisi[left].NormalBisiklet)
                {
                    Duraklar tmp = heapDizisi[index];
                    heapDizisi[index] = heapDizisi[left];
                    heapDizisi[left] = tmp;
                }
                return;
            }
            else
            { //Child' lardan büyük olanı bulur 
                if (heapDizisi[left].NormalBisiklet > heapDizisi[right].NormalBisiklet)
                {   
                    largestChild = left;
                }
                else
                {
                    largestChild = right;
                }
                if (heapDizisi[index].NormalBisiklet < heapDizisi[largestChild].NormalBisiklet)
                {   
                    Duraklar tmp = heapDizisi[index];
                    heapDizisi[index] = heapDizisi[largestChild];
                    heapDizisi[largestChild] = tmp;
                }
            }
            TrickleDown(largestChild);
        } 

    }
}
