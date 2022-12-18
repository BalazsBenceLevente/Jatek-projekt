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
                    GuiLevelEditorHelper.InitGrid(LevelEditorPage.Instance.gArea,LevelEditorPage.Instance.CB_Decor.Items[4] as GuiGameObjects);
                    MainWindow.context.MakeVisible("LevelEditor");
                    break;
                case "LoadLevel":
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Text file (*.txt)|*.txt";
                    if (ofd.ShowDialog() == true)
                    {
                        GuiGameMatrix? temp = GuiFileHandler.MakeMatrixsFormFile(ofd.FileName);
                        if (temp != null)
                        {
                            LevelEditorPage.GuiMatrix = temp;
                            GuiLevelEditorHelper.LoadGrid(LevelEditorPage.Instance.gArea,LevelEditorPage.GuiMatrix);
                            uint row = (uint)LevelEditorPage.GuiMatrix.Decor.GetLength(0), column = (uint)LevelEditorPage.GuiMatrix.Decor.GetLength(1);
                            LevelEditorPage.context.Size_Column = row;
                            LevelEditorPage.context.Size_Column = column;
                            MainWindow.context.MakeVisible("LevelEditor");
                        }
                    }
                    break;
            }
        }
    }
}
