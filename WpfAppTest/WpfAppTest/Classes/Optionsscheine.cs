using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeUnrepublic
{
    internal class Optionsscheine
    {
        private DateTime laufzeitende;
        public DateTime Laufzeitende
        {
            get { return laufzeitende; }
            set
            {
                if( value < DateTime.Now)
                {
                    throw new Exception("Die Laufzeit ist Abgelaufen!"); 
                }
                laufzeitende = value;
            }
        }
        private string optionstyp;
        public string Optionstyp
        {
            get { return optionstyp; }
            set 
            { 
                if (value == null)
                {
                    throw new Exception("Optionstyp wurde nicht Angegeben!");
                }
                optionstyp = value; 
            }
        }
        public string CallPut()
        {
            return Optionstyp = "call";
        }
        public Optionsscheine(string _Namen, int _ISIN, DateTime _Laufzeitende, string _Optionstyp)
        {
            Laufzeitende = Laufzeitende;
            Optionstyp = _Optionstyp;
        }
        public override string ToString()
        {
            return $"Laufzeitende: {Laufzeitende}, Optionstyp: {Optionstyp}";
        }
    }
}
