using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnrepublic
{
    internal class Kurs
    {
        private double werte;
        public double Werte
        {
            get { return werte; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Werte nicht angegeben!");
                }
                werte = value;
            }
        }

        public override string ToString()
        {
            return $"Werte: {werte}";
        }
    }
}
