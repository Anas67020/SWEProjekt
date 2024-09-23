using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest
{
    internal class Anleihen : Wertpapier
    {
        private DateTime laufzeit;
        public DateTime Laufzeit
        {
            get { return laufzeit; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new Exception("Laufzeit ist abgelaufen!");
                }
                laufzeit = value;
            }
        }
        private double kouponwert;
        public double Kouponwert
        {
            get { return kouponwert; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Kouponwert nicht angegeben");
                }
                kouponwert = value;
            }
        }
        public Anleihen(String _Name, int _ISIN, DateTime _Laufzeit, double _Kouponwert) : base(_Name, _ISIN)
        {
            Laufzeit = _Laufzeit;
            Kouponwert = _Kouponwert;
        }
        public override string ToString()
        {
            return $"Laufzeit: {laufzeit}, Kouponwert: {kouponwert}";
        }
    }
}