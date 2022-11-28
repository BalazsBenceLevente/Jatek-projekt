using PushToWin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PushToWin.Pages
{
    /// <summary>
    /// Interaction logic for LevelEditorPage.xaml
    /// </summary>
    public partial class LevelEditorPage : Page
    {
        public LevelEditorPage()
        {
            InitializeComponent();
        }

        LevelEditorModel context = new LevelEditorModel();
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = context;
            
        }
    }
}
