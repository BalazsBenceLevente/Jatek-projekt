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
    /// Interaction logic for LevelEditorEscPage.xaml
    /// </summary>
    public partial class LevelEditorEscPage : Page
    {
        LevelEditorEscModel context = new LevelEditorEscModel();
        public LevelEditorEscPage()
        {
            InitializeComponent();
            BrushConverter bc = new BrushConverter();
            p.Background = (Brush)bc.ConvertFrom("#193C3E");
            l1.Background = (Brush)bc.ConvertFrom("#476365");
            l2.Background = (Brush)bc.ConvertFrom("#476365");
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
        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) //Kiegészit majd
        {
            switch ((sender as Label).Name)
            {
                case "Reset":
                    //LOGIC
                    break;
                case "MainMenu":
                    MainWindow.context.MakeVisible("Start");
                    break;
                case "QuitGame":
                    Application.Current.Shutdown();
                    break;
                case "SaveLevel":
                    //Popup Logic
                    break;
                case "TestLevel":
                    //LOGIC
                    MainWindow.context.MakeVisible("GameWindow");
                    break;
            }
        }
    }
}
