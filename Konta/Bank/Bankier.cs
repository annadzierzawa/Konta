using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Bankier
    {
        private Stawki stawki = Stawki.Instancja;
        private List<KontoStandard> konta = new List<KontoStandard>();

        
        public void DodajKonto(KontoStandard konto)
        {
            konta.Add(konto);
        }

        public void DrukujRaport()
        {
            foreach (var konto in konta)
            {
                Console.WriteLine(konto.DrukujStanKonta());
            }
        }

        public void Wplata(string numer, decimal kwota)
        {
            KontoStandard biezaceKonto = null;
            foreach (var konto in konta)
            {
                if (konto.Numer == numer)
                {
                    biezaceKonto = konto;
                    break;
                }
            }
            try
            {
                biezaceKonto?.Wplata(kwota);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }

        public void Wyplata(string numer, decimal kwota)
        {
            KontoStandard biezaceKonto = null;
            foreach (var konto in konta)
            {
                if (konto.Numer == numer)
                {
                    biezaceKonto = konto;
                    break;
                }
            }
            try
            {
                biezaceKonto?.Wyplata(kwota);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }

        public void Premia(decimal d)
        {
            foreach (var konto in konta)
            {
                konto.Wplata(d);
            }
        }
        public void Przelew(decimal kwota, string numer, string numerOdbiorcy) 
        {
            KontoStandard biezaceKonto = null;
            KontoStandard kontoOdbiorcy = null;

            foreach (var konto in konta)
            {
                if (konto.Numer == numer)
                {
                    biezaceKonto = konto;
                    break;
                }
            }
            foreach (var kontoOdb in konta)
            {
                if (kontoOdb.Numer == numerOdbiorcy)
                {
                    kontoOdbiorcy = kontoOdb;
                    break;
                }
            }


            try
            {
                biezaceKonto?.WyslaniePrzelewu(kwota);
                kontoOdbiorcy?.OdebraniePrzelewu(kwota);
                

            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }

        }
    }
}
