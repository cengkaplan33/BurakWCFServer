using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace BurakClientConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BurakWcfService.ServiceHelloClient client = new BurakWcfService.ServiceHelloClient();

            client.Open();
            var str = client.HelloWorld();
            //Console.Write("servis cevabı : " + );
            client.Close();

            Console.Write("servis cevabı : " +str );
            Console.WriteLine(" çıkmak için bir tuşa basınız...");
            Console.ReadKey();
        }
    }
}
