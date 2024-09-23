using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest
{
    internal class ETF
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
        public ETF(string _Art, string _Namen, int _ISIN, string _Basis)
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
