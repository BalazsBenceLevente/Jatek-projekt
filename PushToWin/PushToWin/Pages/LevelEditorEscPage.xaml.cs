using Microsoft.Win32;
using PushToWin.Class.Gui;
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
                    if (MessageBox.Show("Warning: this action will delete everything!\nAre you sure you want to continue", "Warning!",MessageBoxButton.OKCancel,MessageBoxImage.Warning) != MessageBoxResult.OK) return;
                    GuiLevelEditorHelper.InitGrid(LevelEditorPage.Instance.gArea, LevelEditorPage.Instance.CB_Decor.Items[4] as GuiGameObjects);
                    MainWindow.context.MakeVisible("LevelEditor");
                    break;
                case "MainMenu":
                    MainWindow.context.MakeVisible("Start");
                    break;
                case "QuitGame":
                    Application.Current.Shutdown();
                    break;
                case "SaveLevel":
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Text file (*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        GuiFileHandler.SaveLevelToFile(saveFileDialog.FileName,LevelEditorPage.GuiMatrix);
                    }
                    break;
                case "TestLevel":
                    //LOGIC
                    MainWindow.context.MakeVisible("GameWindow");
                    break;
            }
        }
    }
}
