using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P3
{
    public class Duraklar
    {
        string durakAdi;
        int bosPark, tandemBisiklet, normalBisiklet;
        //Duraklar sınıfında musteriler listesini oluşturdum
        ArrayList musteriler = new ArrayList();
        public Duraklar(string durakAdi, int bosPark, int tandemBisiklet, int normalBisiklet, ArrayList musteriler)
        {
            this.DurakAdi = durakAdi;
            this.BosPark = bosPark;
            this.TandemBisiklet = tandemBisiklet;
            this.NormalBisiklet = normalBisiklet;
            this.musteriler = musteriler;
        }
        public Duraklar(string durakAdi, int bosPark, int tandemBisiklet, int normalBisiklet)
        {
            this.DurakAdi = durakAdi;
            this.BosPark = bosPark;
            this.TandemBisiklet = tandemBisiklet;
            this.NormalBisiklet = normalBisiklet;
        }

        public string DurakAdi { get => durakAdi; set => durakAdi = value; }
        public int BosPark { get => bosPark; set => bosPark = value; }
        public int TandemBisiklet { get => tandemBisiklet; set => tandemBisiklet = value; }
        public int NormalBisiklet { get => normalBisiklet; set => normalBisiklet = value; }
        public ArrayList Musteriler { get => musteriler; set => musteriler = value; }

        public void ToString()
        {
            Console.WriteLine(" "+ durakAdi + " bosPark= " + bosPark + " tandemBisiklet= " + tandemBisiklet + " normalBisiklet= " + normalBisiklet +
                " müsteri sayisi= "+ musteriler.Count);

            foreach (ArrayList musteri in musteriler)
            {
                Console.WriteLine( "  ID:"+musteri[0] +", "+ musteri[1]);
                          
            }
            Console.WriteLine();
        }

    }
}
