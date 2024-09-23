using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest
{
    internal class Kurs
    {
        private double wert;
        public double Wert
        {
            get { return wert; }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Werte nicht angegeben!");
                }
                wert = value;
            }
        }
        private DateTime datum;
        public DateTime Datum
        {
            get { return datum; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new Exception("Datum liegt in der Vergangenheit!");
                }
                datum = value;
            }
        }

        public override string ToString()
        {
            return $"Werte: {wert}, Datum: {datum}";
        }
    }
}