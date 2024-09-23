using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest
{
    internal class Bank
    {
        public List<Wertpapier> WertpapiereListe;

        public override string ToString()
        {
            return $"Wertpapiere: {WertpapiereListe}";
        }
    }
}