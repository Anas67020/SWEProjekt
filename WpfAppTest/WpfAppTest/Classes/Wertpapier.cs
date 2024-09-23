using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeUnrepublic;

namespace WpfAppTest
{
    abstract class Wertpapier
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
        private List<Kurs> kurse;
        public List<Kurs> Kurse
        {
            get { return kurse; }
        }
        public Wertpapier(string _namen, int _isin)
        {
            ISIN = _isin;
            Namen = _namen;

        }

        protected Wertpapier()
        {
        }

        public void AnzeigenKurs()
        {

        }
        public void WerteHolen()
        {

        }
        public void AddKurs()
        {

        }
    }
}