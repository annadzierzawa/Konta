using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;


namespace Konta
{
   
    class Program
    {
        static void Main(string[] args)
        {
            Bankier bankier = new Bankier();
            bankier.DodajKonto(new KontoStandard(new Klient("Jan","Kow","Lublin"),"000 000 001",10_000M));
            bankier.DodajKonto(new KontoBiznes(new Klient("Emil", "Justowy", "Wąchock"), "000 000 002", 10_000_980M, 100_000M, Stawki.Instancja));
            bankier.DodajKonto(new KontoBiznes(new Klient("Jas","Fasola","Londyn"),"111 111 111",99_000.99M, 10_000M,Stawki.Instancja));
            bankier.DodajKonto(new KontoStudent(new Klient("Anna", "Dziekaka", "Lupowice"), "111 222 111", 99_000.99M, Stawki.Instancja));

            bankier.DrukujRaport();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Wpłata i wypłata");

            bankier.Wyplata("000 000 002", 87M);
            bankier.Wplata("000 000 001", 87M);

            
            bankier.DrukujRaport();

            Console.WriteLine("--------------------------");
            Console.WriteLine("Premia");

            bankier.Premia(10M);

            
            bankier.DrukujRaport();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Wypłata");
            bankier.Wyplata("111 111 111", 99_999M);
            bankier.DrukujRaport();
            Console.WriteLine("--------------------------");
            bankier.Przelew(30M,"111 111 111","111 222 111");
            bankier.DrukujRaport();
            Console.ReadKey();
        }
    }
}
