using System;
using System.Security.Cryptography;
using System.Text;

namespace de.brockhausag.saltAndPepper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MD5 und SHA Beispiel - Salt & Pepper");
            Console.WriteLine("====================================");            

            //sollte aus einer anderen Quelle gelesen werden. Der Einfachheit halber wird ein String verwendet
            var pepper = "@ktdRdotewStee31223!!!33sdrt532sv224vvl420094";

            //Eingabe lesen und in ein Byte-Array verwandeln
            var salt = Salt("Benutzer");
            var bytes = new ASCIIEncoding().GetBytes(string.Format("{0}{1}{2}",Input(), salt, pepper));
  
            //MD5
            var md5 = new MD5Cng();
            string md5Hash = BitConverter.ToString(md5.ComputeHash(bytes)).Replace("-", "").ToLower();
            Console.WriteLine("MD5-Hash:\t{0}", md5Hash);

            //SHA1
            var sha1Cng = new SHA1Cng();
            string sha1Hash = BitConverter.ToString(sha1Cng.ComputeHash(bytes)).Replace("-","").ToLower();
            Console.WriteLine("SHA1-Hash:\t{0}", sha1Hash);

            //SHA256
            var sha256 = new SHA256Cng();
            string sha256Hash = BitConverter.ToString(sha256.ComputeHash(bytes)).Replace("-", "").ToLower();
            Console.WriteLine("SHA256-Hash:\t{0}", sha256Hash);

            Console.WriteLine("Beliebige Taste drücken zum beenden");
            Console.ReadKey();
        }

        private static string Input()
        {
            Console.Write("Bitte ein Kennwort eingeben: ");
            var password = string.Empty;

            while (string.IsNullOrEmpty(password))
                password = Console.ReadLine();
            return password;
        }

        //Ermittelt das Salt für den Benutzer
        private static string Salt(string benutzer)
        {
            //Das Salt muss für jeden Benutzer einzigartig sein
            //Zu Demozwecken wird hier nur eine feste Zeichenkette zurück gegeben           
            return "DemoSalt";
        }
    }
}
