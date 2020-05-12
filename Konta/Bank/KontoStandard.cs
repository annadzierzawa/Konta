using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class KontoStandard
    {
        internal Klient Wlasciciel { get; private set; }
        internal string Numer { get; private set; }
        protected decimal saldo;
        internal KontoStandard(Klient wlasciciel, string numer, decimal saldoPoczatkowe)
        {
            Wlasciciel = wlasciciel;
            Numer = numer;
            if (saldoPoczatkowe < 0) throw new Exception("");
            saldo = saldoPoczatkowe;
        }
        internal virtual bool Wplata(decimal kwota)
        {
            if (kwota < 0) throw new Exception("Niepoprawna kwota");
            saldo += kwota;
            return true;
        }
        internal virtual bool OdebraniePrzelewu(decimal kwota)
        {
            if (kwota < 0) throw new Exception("Niepoprawna kwota");
            saldo += kwota;
            return true;
        }
        internal virtual bool WyslaniePrzelewu(decimal kwota)
        {
            if (kwota <= 0) throw new Exception("Niepoprawna kwota");
            if (saldo < kwota) return false;
            saldo -= kwota;
            return true;
        }
        internal virtual bool Wyplata(decimal kwota)
        {
            if (kwota <= 0) throw new Exception("Niepoprawna kwota");
            if (saldo < kwota) return false;
            saldo -= kwota;
            return true;
        }
        internal virtual string DrukujStanKonta() => $"{Numer}: saldo {saldo}";
    }
}
