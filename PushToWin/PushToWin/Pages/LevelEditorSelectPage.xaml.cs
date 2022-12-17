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
    /// Interaction logic for LevelEditorSelectPage.xaml
    /// </summary>
    public partial class LevelEditorSelectPage : Page
    {
        LevelEditorSelectModel context = new LevelEditorSelectModel();
        public LevelEditorSelectPage()
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
        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) //Kiegészit majd
        {
            switch ((sender as Label).Name)
            {
                case "MakeLevel":
                    MainWindow.context.MakeVisible("LevelEditor");
                    break;
                case "LoadLevel":
                    MainWindow.context.MakeVisible("LevelEditor");
                    //LOGIC
                    break;
            }
        }
    }
}
