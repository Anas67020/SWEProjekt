using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppTest
{
    internal class Kunde
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name nicht angegeben!");
                }
                name = value;
            }
        }
        private Dictionary<string, Wertpapier> wertPapierDict;
        public Dictionary<string, Wertpapier> WertPapierDict
        {
            get { return wertPapierDict; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Wertpapier nicht Angegeben!");
                }
                wertPapierDict = value;
            }
        }
        public void CountWertpapiere()
        {
            MessageBox.Show(WertPapierDict.Count().ToString());
        }
        public override string ToString()
        {
            return $"Name: {name}, Wertpapier: {WertPapierDict}";
        }
    }
}