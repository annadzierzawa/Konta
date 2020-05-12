using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Stawki
    {
        //klasa zawierająca stawki i progi banku 
        //tworzymy ją jako singleton, gdyż chcemy, żeby mógł istnieć tylko 
        //jeden obiekt tj klasy
        private static Stawki instancja = null;
        internal static Stawki Instancja{
            get { return instancja ?? (instancja = new Stawki()); }
        }
        private Stawki() {
            KosztWyplaty = 5.0M;
            ProgPlatnosciWyplaty = 10_000.0M;
            LimitDzienny = 500.0M;
            ProcentowaPremiaZaWplate = 0.001M;
            ProgPremiowaniaWplaty = 5_000.0M;
        }
        internal decimal KosztWyplaty { get; private set; }
        internal decimal ProcentowaPremiaZaWplate { get; private set; }
        internal decimal LimitDzienny { get; private set; }
        internal decimal ProgPlatnosciWyplaty { get; private set; }
        internal decimal ProgPremiowaniaWplaty { get; private set; } 

    }
}
