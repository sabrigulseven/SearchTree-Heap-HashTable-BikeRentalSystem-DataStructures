using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.a
            string[] duraklar = { "İnciraltı,28,2,10", "Sahilevleri,8,1,11", "Doğal Yaşam Parkı,17,1,6",
            "Bostanlı İskele,7,0,11" , "Karşıyaka iskele,11,0,9", "Bayraklı Nikah Salonu,5,2,7",
            "Liman,6,0,12","Alsancak İskele,10,0,13","Pasaport İskele,10,1,15"};
            Node node = null;
            Random rastgele = new Random();
            Tree tree = new Tree();
            //saat bilgisini rastgele olarak ürettim

            int hours = rastgele.Next(24);
            int minutes = rastgele.Next(60);
            //duraklar dizisindeki durak bilgilerinden Durak nesnesi oluşturmak ve Binary Search Tree'ye eklemek için for döngüsü kullandım
            for (int i = 0; i < duraklar.Length; i++)
            {
                string[] durak = duraklar[i].Split(',');

                //Rastgele sayıda Musteri için müsteriler listesi oluşturuldu
                ArrayList musteriler = new ArrayList();
                int musteriSayisi = rastgele.Next(1, 11);

                //random müşteri sayısı kadar müşteri oluşturmak için for döngüsü kullandım
                for (int j = 0; j < musteriSayisi ; j++)
                {
                    ArrayList musteri = new ArrayList();                 
                    //müşteri id'sini 1-20 arasında rastgele olarak üretttim
                    //proje dökümanında belirtilmediği için aynı müşteri id'sinin birden fazla olma durumuna ve 
                    //yeterli sayıda bisikletin olup olmadığına dikkat etmedim
                    musteri.Add(rastgele.Next(1, 21));
                    hours = rastgele.Next(24);
                    minutes = rastgele.Next(60);
                    musteri.Add(hours+":"+minutes);
                    musteriler.Add(musteri);
                }

                //Durak nesnesi oluşturuldu
                Duraklar yeniDurak = new Duraklar(durak[0], int.Parse(durak[1]), int.Parse(durak[2]), int.Parse(durak[3]),musteriler);

                //Duraktaki boş park ve bisiklet sayısı güncellendi
                yeniDurak.BosPark += musteriSayisi;
                yeniDurak.NormalBisiklet -= musteriSayisi;

                //yeniDurak nesnesi Binary Search Tree'ye eklendi
                node = tree.Insert(node,yeniDurak);
                //yeniDurak.ToString();

            }
            // 1.b
            Console.WriteLine(" Ağacın derinliği: {0}", tree.MaxDepth(node));
            tree.PrintInOrder(node);

            // 1.c
            int arananID;
            Console.WriteLine("bulunmasını istediğiniz müşterinin ID' sini giriniz (1 ile 20 arasında tam sayı giriniz)");
            arananID = Int32.Parse(Console.ReadLine());
            tree.FindMusteri(node, arananID);

            // 1.d Kiralama
            Console.WriteLine("kiralama yapan müşterinin Idsini giriniz");
            int kiralayanID = Int32.Parse(Console.ReadLine());
            ArrayList kiralayanMusteri=new ArrayList();
            kiralayanMusteri.Add(kiralayanID);
            kiralayanMusteri.Add(hours + ":" + minutes);
            Console.WriteLine("kiralama yapılan durak adını giriniz");
            string kiralananDurak = Console.ReadLine();
            tree.BisikletKiralama(node, kiralananDurak, kiralayanMusteri);

            // 2.a
            // Burada Dictionary Classını kullanmak için Aybars hocadan izin aldım. İzin verdiğini belirtmemi istediler. 
            Dictionary<char[], ArrayList> HashTable = new Dictionary<char[], ArrayList>();
            for (int i = 0; i < duraklar.Length; i++)
            {
                string[] durak = duraklar[i].Split(',');
                ArrayList yeniDurak = new ArrayList();
                yeniDurak.Add(durak[0]);
                yeniDurak.Add(int.Parse(durak[1]));
                yeniDurak.Add(int.Parse(durak[2]));
                yeniDurak.Add(int.Parse(durak[3]));
                HashTable.Add(durak[0].ToCharArray(0,1), yeniDurak);
                
            }
            // 2.b
            // Boş Park sayısı 5 ten büyük her istasyona 5 bisiklet eklendi 
            foreach (var item in HashTable)
            {             
                if ((int)item.Value[1] > 5)
                {
                    item.Value[1] = (int)item.Value[1] - 5;
                    item.Value[3] = (int)item.Value[3] + 5;
                }
            }
            // 3.ab
            HeapMax heapMax = new HeapMax();
            for (int i = 0; i < duraklar.Length; i++)
            {
                string[] durak = duraklar[i].Split(',');
                Duraklar yeniDurak = new Duraklar(durak[0], int.Parse(durak[1]), int.Parse(durak[2]), int.Parse(durak[3]));
                heapMax.InsertElementInHeap(yeniDurak);
            }
            //foreach (Duraklar item in heapMax.heapDizisi)
            //{
            //    Console.WriteLine(item.NormalBisiklet);
            //}

            // 3.c
            heapMax.remove();
            heapMax.remove();
            heapMax.remove();

            //heapMax.remove();
            //heapMax.remove();
            //heapMax.remove();
            //heapMax.remove();
            //heapMax.remove();
            //heapMax.remove();
            //heapMax.remove();

            // 4.a
            List<int> list = new List<int>();
            list.Add(3); list.Add(7); list.Add(9); list.Add(1); list.Add(4); list.Add(2); list.Add(8); list.Add(6); list.Add(5);
            List<int> blist = new List<int>(list);
            BubbleSort bubbleSort = new BubbleSort(blist);
            bubbleSort.BubbleSortInc();
            //bubbleSort.BubbleSortDec();

            // 4.b
            List<int> qlist = new List<int>(list);
            QuickSort quickSort = new QuickSort(qlist);
            quickSort.quickSort(0,qlist.Count-1);
        }
    }
}
