using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppTest
{
    /// <summary>
    /// Interaktionslogik für InputPopup.xaml
    /// </summary>
    public partial class InputPopup : Window
    {
        public string InputText { get; private set; }

        public InputPopup(string input = "")
        {
            InitializeComponent();
            UpdateHintVisibility();
            txbl_hint.Text = input;
        }

        private void btn_Clicked(object sender, RoutedEventArgs e)
        {
            if (sender == btn_Enter)
            {
                InputText = txb_Input.Text;
                DialogResult = true;
                Close();
            }
            else if (sender == btn_Cancel)
            {
                DialogResult = false;
                Close();
            }
        }

        private void UpdateHintVisibility()
        {
            if (string.IsNullOrEmpty(txb_Input.Text))
            {
                txbl_hint.Visibility = Visibility.Visible; // Show hint if TextBox is empty
            }
            else
            {
                txbl_hint.Visibility = Visibility.Collapsed; // Hide hint if TextBox has text
            }
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateHintVisibility();
        }
    }
}
