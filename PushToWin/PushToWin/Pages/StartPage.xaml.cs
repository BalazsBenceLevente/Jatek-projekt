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
            BrushConverter bc = new BrushConverter();
            p.Background = (Brush)bc.ConvertFrom("#193C3E");
            l1.Background = (Brush)bc.ConvertFrom("#476365");
            this.DataContext = context;
        }
        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            context.ImgSwitch((sender as Label).Name);
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            context.ImgSwitch((sender as Label).Name);
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as Label).Name)
            {
                case "Start":
                    MainWindow.context.MakeVisible("GameWindow");
                    break;
                case "LevelSelector":
                    MainWindow.context.MakeVisible("LevelSelector");
                    break;
                case "LevelEditor":
                    MainWindow.context.MakeVisible("LevelEditorSelect");
                    break;
                case "Quit":
                    Application.Current.Shutdown();
                    break;
            }
        }
    }
}
