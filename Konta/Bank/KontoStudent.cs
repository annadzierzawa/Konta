using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class KontoStudent: KontoStandard
    {
        internal Klient Wlasciciel { get; private set; }
        internal string Numer { get; private set; }
        protected decimal saldo;
        private readonly Stawki _stawki;

        internal KontoStudent(Klient wlasciciel, string numer, decimal saldoPoczatkowe, Stawki stawki) : base(wlasciciel, numer, saldoPoczatkowe)
        {
            Wlasciciel = wlasciciel;
            Numer = numer;
            if (saldoPoczatkowe < 0) throw new Exception("");
            saldo = saldoPoczatkowe;
        }
        internal override bool Wplata(decimal kwota)
        {
            if (kwota < 0) throw new Exception("Niepoprawna kwota");
            if (kwota > _stawki.ProgPremiowaniaWplaty) 
            { 
                saldo = saldo + kwota + (_stawki.ProcentowaPremiaZaWplate*kwota);
                return true; 
            } 
            else 
            {
                saldo += kwota;
                return true; 
            }
        }
        internal override bool Wyplata(decimal kwota)
        {
            if (kwota <= 0) throw new Exception("Niepoprawna kwota");
            if (saldo < kwota) return false;
            if (kwota > _stawki.LimitDzienny) throw new Exception("Przekroczono limit wypłaty");
            saldo -= kwota;
            return true;
        }
        internal override string DrukujStanKonta() => $"{Numer}: saldo {saldo}";
    }
}
