using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace berek
{
    struct berek
    {
        public string nev;
        public string nem;
        public string reszleg;
        public int belep;
        public int ber;
    }
    class Program
    {
        static void p() { Console.ReadKey(); }
        static void print(string s) { Console.WriteLine(s.ToString()); }
        static void f(int x) { Console.WriteLine(x + ". Feladat."); }
        static void Main(string[] args)
        {
            List<berek> berL = new List<berek>();
            string[] txt = File.ReadAllLines("berek2020.txt", Encoding.UTF8);
            List<string> tipus = new List<string>();
            for (int i = 0; i < txt.Count(); i++)
            {
                if ((txt[i].Length > 0) && (i > 0))
                {
                    string[] adat = txt[i].Split(';');
                    berek uj = new berek();
                    uj.nev = adat[0];
                    uj.nem = adat[1];
                    uj.reszleg = adat[2];
                    uj.belep = Convert.ToInt32(adat[3]);
                    uj.ber = Convert.ToInt32(adat[4]);
                    berL.Add(uj);
                }

                if (i == 0)
                {
                    string[] adatF = txt[i].Split(';');
                    tipus.Add(adatF[0]); tipus.Add(adatF[1]); tipus.Add(adatF[2]); tipus.Add(adatF[3]); tipus.Add(adatF[4]);
                }
            }
            f(1);
            f(2);
            print("Adatok beolvasva .");
            f(3);
            print("Az beolvaott állomány: " + berL.Count() + "dolgozó adatát tartalmaza.".ToString());
            int öszber = 0;
            List<string> reszlegek = new List<string>() { berL[0].reszleg };
            int[] db = new int[9];
            for (int j = 0; j < berL.Count(); j++)
            {
                öszber += (berL[j].ber);
                if (reszlegek.Contains(berL[j].reszleg) == false) { reszlegek.Add(berL[j].reszleg); }
                f(4);
                double atlag = öszber / berL.Count();
                Console.WriteLine("AZ átlag bér: " + Math.Round(atlag * 0.001, 2) + " ezer forint.");
                f(5);
                print("Részlegek: ");
                foreach (string r in reszlegek) { Console.WriteLine(" " + r); }
                Console.Write("Adjon meg egy Részleg nevet: ");
                string[] sz = new string[tipus.Count];
                string be = Console.ReadLine();
                int lt = 0;
                for (int j = 0; j < berL.Count(); j++)
                {
                    for (int R = 0; R < reszlegek.Count(); R++) { if (berL[j].reszleg == reszlegek[R]) { db[R]++; } }
                    if (berL[j].reszleg == be)
                    {
                        if (berL[j].ber > berL[lt].ber)
                        {
                            lt = j;
                            sz[0] = " " + tipus[0] + " : " + berL[lt].nev;
                            sz[1] = " " + tipus[1] + " : " + berL[lt].nem;
                            sz[2] = " " + tipus[2] + " : " + berL[lt].reszleg;
                            sz[3] = " " + tipus[3] + " : " + berL[lt].belep;
                            sz[4] = " " + tipus[4] + " : " + berL[lt].ber + " Ft.";
                        }
                    }

                    if (reszlegek.Contains(be) == false) { sz[0] = " NINCS megjeleníthető adat: - Az megadott Részleg nem létezik a cégnél. ".ToString(); }
                }
                f(6);
                print("A legtöbb pénzt kap az adott részlegen: ");
                foreach (string ki in sz) { Console.WriteLine(ki); }
                f(7);
                print("Statisztika: ");
                for (int k = 0; k < reszlegek.Count(); k++)
                { Console.WriteLine(reszlegek[k] + " - " + db[k] + " fő."); }
                p();
            }
        }
    }
}


