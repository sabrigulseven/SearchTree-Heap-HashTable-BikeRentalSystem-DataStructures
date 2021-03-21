using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P3
{
    class Tree
    {
        public Node Insert(Node root, Duraklar v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v.DurakAdi.CompareTo(root.value.DurakAdi) < 1 ) 
            {
                root.left = Insert(root.left, v);
            }
            else
            {
                root.right = Insert(root.right, v);
            }

            return root;
        }

        public void PrintPreOrder(Node node)//preorder dolaşan metot bu metodu yazdım ama kullanmadım
        {
            if (node == null)
                return;
            node.value.ToString();
            PrintPreOrder(node.left);
            PrintPreOrder(node.right);
        }
        public void PrintInOrder(Node node)//inorder dolaşan metot. Yazdırmak için bu metodu kullandım
        {
            if (node == null)
                return;
            
            PrintInOrder(node.left);
            node.value.ToString();
            PrintInOrder(node.right);
        }
        public int MaxDepth(Node node)//Ağacın derinliğini bulan metot
        {
            if (node == null)
                return 0;
            else
            {
                int lDepth = MaxDepth(node.left);
                int rDepth = MaxDepth(node.right);
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }
        }
        public void FindMusteri(Node node,int arananID)//müşteriyi bulup verilerini yazdıran metot
        {
            if (node == null)
                return;
            foreach (ArrayList musteri in node.value.Musteriler)
            {
                int musteriID = (int)musteri[0];
                if (musteriID == arananID)
                    Console.WriteLine(node.value.DurakAdi+" "+musteri[1]);
            }
            FindMusteri(node.left, arananID);
            FindMusteri(node.right, arananID);
        }

        public void BisikletKiralama(Node node,string durakAdi,ArrayList musteri)
        {//müşteri ve durak adı bilgilerini alarak bisiklet kiralama işlemini gerçekleştirir
            if (node == null)
            {
                return;
            }
            if (node.value.DurakAdi == durakAdi)
            {
                node.value.Musteriler.Add(musteri);
                node.value.NormalBisiklet--;
                node.value.BosPark++;
                Console.WriteLine("eklendi");
                return;
            }
            BisikletKiralama(node.left, durakAdi, musteri);
            BisikletKiralama(node.right, durakAdi, musteri);

        }
    }
}
