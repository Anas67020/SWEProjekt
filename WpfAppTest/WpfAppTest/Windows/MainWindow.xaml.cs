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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Button Clicked");
            if (sender == btn_Buy)
            {
                InputPopup popup = new InputPopup("Where do you want to Invest?");
                if (popup.ShowDialog() == true)
                {
                    string userInput = popup.InputText;
                    MessageBox.Show(userInput);
                }
            }
            else if (sender == btn_Sell) txb_ClickOut2.Text = "Buttton two Clicked";
            else if (sender == btn_Chart) txb_ClickOut3.Text = "Buttton three Clicked";
            else if (sender == btn_Exit)
            {
                MessageBoxResult exit = MessageBox.Show("Do you realy want to Exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            else MessageBox.Show("Button not found");
        }
    }
}
