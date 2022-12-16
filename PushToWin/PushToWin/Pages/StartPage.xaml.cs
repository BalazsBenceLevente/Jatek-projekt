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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Page
    {
        StartPageModel context = new StartPageModel();
        public StartWindow()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = context;
        }
        //private void Label_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    context.ImgSwitch((sender as Label).Name.Substring(2));
        //}

        //private void Label_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    context.ImgSwitch((sender as Label).Name.Substring(2));
        //}

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var send = (sender as Label).Name;
            if (send == "laQuit") Application.Current.Shutdown();
            MainWindow.context.MakeVisible(send.Substring(2));
        }
    }
}
