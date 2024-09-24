using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using TradeUnrepublic;

namespace WpfAppTest
{
    internal class Portfolio
    {
        private List<WertpapierPosten> wertpapiere;
        private Bank bank = new Bank();

        public Portfolio()
        {
            // Initialize the wertpapiere list to prevent NullReferenceExceptions
            wertpapiere = new List<WertpapierPosten>();
        }

        public List<WertpapierPosten> Wertpapiere
        {
            get { return wertpapiere; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Wertpapier Liste ist leer!");
                }
                wertpapiere = value;
            }
        }

        public void verkaufen(string userinput)
        {
            // Use a safer way to remove items while iterating
            WertpapierPosten toRemove = null;

            foreach (var wp in wertpapiere)
            {
                if (userinput == wp.WP.Namen)
                {
                    toRemove = wp;
                    break;  // Once found, exit loop
                }
            }

            if (toRemove != null)
            {
                wertpapiere.Remove(toRemove);
                MessageBox.Show("You sold " + userinput + " and it was removed from your Portfolio.");
            }
            else
            {
                MessageBox.Show("Item not found in the portfolio.");
            }
        }

        public void kaufen(string userinput, int anzahl)
        {
            foreach (var wp in bank.WertpapiereListe)
            {
                if (userinput == wp.Namen)
                {
                    WertpapierPosten posten = new WertpapierPosten(anzahl, wp);
                    wertpapiere.Add(posten);
                    MessageBox.Show("You bought " + userinput + " and it was added to your Portfolio.");
                    return;  // Exit after buying
                }
            }
            MessageBox.Show("Wertpapier not found.");
        }

        public string Anzeigen()
        {
            StringBuilder result = new StringBuilder();
            foreach (var wp in wertpapiere)
            {
                result.AppendLine(wp.ToString());
            }
            return result.ToString();
        }

        public override string ToString()
        {
            return $"Wertpapiere: {string.Join(", ", wertpapiere)}";
        }
    }
}
