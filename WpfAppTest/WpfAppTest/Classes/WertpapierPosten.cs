using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUnrepublic;

namespace WpfAppTest
{
    internal class WertpapierPosten
    {
        private Wertpapier wp;
        public Wertpapier WP
        {
            get { return wp; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Wertpapiere nicht Angegeben!");
                }
                wp = value;
            }
        }
        private int anzahl;
        public int Anzahl
        {
            get { return anzahl; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Anzahl nicht angegeben!");
                }
                anzahl = value;
            }
        }
        public WertpapierPosten(int _anzahl, Wertpapier _wp)
        {
            Anzahl = _anzahl;
            WP = _wp;
        }
        public override string ToString()
        {
            return $"Wertpapier: {wp.Namen}, Anzahl: {anzahl}";
        }
    }
}