using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            AddKurs();
        }
        


        // hier müssten eigentlich die daten aus der werteholenmethode ausgegeben werden, wenn ich alles richtig gemacht habe
        public void AddKurs()
        {
            Kurs kurs = new Kurs();
            kurs.WerteHolen();// mit angegebenem Koordinatensystem eigentlich
        }
        


    }
}