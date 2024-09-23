using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnrepublic
{
    internal class Aktien
    {
        private string kuerzel;
        public string Kuerzel
        {
            get { return kuerzel; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Kuerzel nicht Angegeben!");
                }
                kuerzel = value;
            }
        }
        private string unternehmen;
        public string Untrnehmen
        {
            get { return unternehmen; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Unternehmen nicht Angegeben!");
                }
                unternehmen = value;
            }
        }
        private double dividende;
        public double Dividende
        {
            get { return dividende; }
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Dividende nicht Angegeben!");
                }
                dividende = value;
            }
        }
        public Aktien(string _Namen, int _ISIN, string _Kuerzel, string _Unternehmen, double _Dividende)
        {
            Kuerzel = _Kuerzel;
            unternehmen= _Unternehmen;
            Dividende = _Dividende;
        }
        public override string ToString()
        {
            return $"Kuerzel: {Kuerzel}, Unternehmen: {unternehmen}, Dividende: {Dividende}";
        }
    }
}

