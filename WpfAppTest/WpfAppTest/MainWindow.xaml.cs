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

namespace WpfAppTest
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
            if (sender == btn_ClickMe1) txb_ClickOut1.Text = "Buttton one Clicked";
            else if (sender == btn_ClickMe2) txb_ClickOut2.Text = "Buttton two Clicked";
            else if (sender == btn_ClickMe3) txb_ClickOut3.Text = "Buttton three Clicked";
            else if (sender == btn_Exit)
            {
                MessageBoxResult exit = MessageBox.Show("Do you realy want to Exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (exit == MessageBoxResult.Yes) Application.Current.Shutdown();
            }
            else if (sender == btn_NextPage)
            {
                MainFrame.Navigate(new PageTwo());
            }
            else if (sender == btn_FirstPage)
            {
                MainFrame.Content = null;
            }
            else MessageBox.Show("Button not found");
        }
    }
}
