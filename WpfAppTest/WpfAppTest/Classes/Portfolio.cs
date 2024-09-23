using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest
{
    internal class Portfolio
    {
        private List<WertpapierPosten> wertpapiere;
        public List<WertpapierPosten> Wertpapiere
        {
            get { return wertpapiere; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Wertpapier Liste ist Leer!");
                }
                wertpapiere = value;
            }
        }
        public void verkaufen()
        {

        }
        public void kaufen()
        {

        }
        public void Anzeigen()
        {

        }
        public override string ToString()
        {
            return $"Wertpapiere: {wertpapiere} ";
        }
    }
}