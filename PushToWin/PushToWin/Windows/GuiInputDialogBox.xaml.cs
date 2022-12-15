using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PushToWin.Windows
{
    /// <summary>
    /// Interaction logic for GuiInputDialogBox.xaml
    /// </summary>
    public partial class GuiInputDialogBox : Window
    {
        int from, to;
        bool regexNumbers;
        int value;
        public GuiInputDialogBox()
        {
            InitializeComponent();
        }
        public GuiInputDialogBox(string question,string title ="",int from = 0,int to = 9,bool regexNumbers = false)
        {
            InitializeComponent();
            this.Title = title;
            laQuestion.Content = question;
            this.from = from;
            this.to = to;
            this.regexNumbers = regexNumbers;
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            tbText.SelectAll();
            tbText.Focus();
        }
        private Regex _regex = new Regex("[^0-9]+");
        private void NumbersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = regexNumbers && _regex.IsMatch(e.Text);
        }
        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            
            bool b = int.TryParse(tbText.Text, out value);
            if (b && (value >=from &&  value<=to))
            {
                this.DialogResult = true;
            }
            else
            {
                laQuestion.Foreground = Brushes.Red;
            }
        }
        public int Answer
        {
            get { return value; }
        }
    }
}
