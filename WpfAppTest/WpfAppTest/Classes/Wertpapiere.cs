using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnrepublic
{
    abstract class Wertpapiere
    {
        private string namen;
        public string Namen
        {
            get { return namen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name nicht angegeben!");
                }
                namen = value;
            }
        }
        private int isin;
        public int ISIN
        {
            get { return isin; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("ISIN nicht angegeben!");
                }
                isin = value;
            }
        }
        public Wertpapiere(string _namen, int _isin)
        {
            ISIN = _isin;
            Namen = _namen;
        }

        public void AnzeigenKurs()
        {

        }
        public void WerteHolen()
        {

        }
    }
}
