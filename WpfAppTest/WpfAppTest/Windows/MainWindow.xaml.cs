using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppTest;

namespace TradeUnrepublic
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Portfolio p = new Portfolio();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btn_Buy)
            {
                InputPopup popup = new InputPopup("How much do you want to buy?");
                if (popup.ShowDialog() == true)
                {
                    string userInput = popup.InputText;
                    string chosenStock = popup.cbx_chose.Text;  // Assuming this is the ComboBox value
                    if (int.TryParse(userInput, out int anzahl))
                    {
                        p.kaufen(chosenStock, anzahl);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number.");
                    }
                }
            }
            else if (sender == btn_Sell)
            {
                InputPopup popup = new InputPopup("What do you want to sell?");
                if (popup.ShowDialog() == true)
                {
                    string userInput = popup.InputText;
                    p.verkaufen(userInput);
                }
            }
            else if (sender == btn_Chart)
            {
                MessageBox.Show("You own the following: " + p.Anzeigen());
            }
            else if (sender == btn_Exit)
            {
                MessageBoxResult exit = MessageBox.Show("Do you really want to Exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (exit == MessageBoxResult.Yes) Application.Current.Shutdown();
            }
            else if (sender == btn_NextPage)
            {
                MainFrame.Content = new PageTwo();
            }
            else if (sender == btn_FirstPage)
            {
                MainFrame.Content = null;
            }
        }
    }
}

