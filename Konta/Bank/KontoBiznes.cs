using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class KontoBiznes:KontoStandard
    {
        private readonly Stawki _stawki;
        internal decimal Debet { get; set; }
        internal KontoBiznes(Klient klient, string numer, decimal saldoPoczatkowe, decimal debet, Stawki stawki) :
                    base(klient, numer, saldoPoczatkowe)
        { 
            _stawki = stawki;
            if (debet < 0) 
                throw new Exception("Niewłaściwa kwota debetu");
            Debet = debet;
        }
        internal override string DrukujStanKonta() => $"{base.DrukujStanKonta()} limit debetu {Debet}";
        
        internal override bool Wyplata(decimal kwota)
        {
            if (kwota <= 0)
                throw new Exception("Niewłaściwa kwota");
           
            if (kwota <= _stawki.ProgPlatnosciWyplaty)
            {
                if (saldo + Debet + _stawki.KosztWyplaty < kwota)
                    return false;
                saldo -= _stawki.KosztWyplaty;
            }
            else
               if (saldo + Debet  < kwota)
                    return false;
            saldo -= kwota;
            return true;
        }

    }
}
