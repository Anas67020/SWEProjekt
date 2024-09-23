using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WpfAppTest
{
    internal class ETF : Wertpapier
    {
        private string art;
        public string Art
        {
            get { return art; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Art wurde nicht Angegeben!");
                }
                art = value;
            }
        }
        private string basis;
        public string Basis
        {
            get { return basis; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Basis wurde nicht Angegeben");
                }
                basis = value;
            }
        }
        public ETF(string _Name, int _ISIN, string _Art, string _Basis) : base(_Name, _ISIN)
        {
            Art = _Art;
            Basis = _Basis;
        }

        public override string ToString()
        {
            return $"Art: {art}, Basis: {basis}";
        }
    }
}