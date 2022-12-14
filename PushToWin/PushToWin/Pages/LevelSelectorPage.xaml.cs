using PushToWin.Class.Gui;
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
    /// Interaction logic for LevelSelectorPage.xaml
    /// </summary>
    public partial class LevelSelectorPage : Page
    {
        public LevelSelectorPage()
        {
            InitializeComponent();
            BrushConverter bc = new BrushConverter();
            p.Background = (Brush)bc.ConvertFrom("#193C3E");
            l1.Background = (Brush)bc.ConvertFrom("#476365");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int row = 6, 
                col = 10;
            int lockedTo = 11;
            int num = 1;
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    BrushConverter bc = new BrushConverter();
                    Button a = new Button();
                    a.Background = (Brush)bc.ConvertFrom("#408185");
                    a.Margin = new Thickness(5);
                    a.FontSize = 30;
                    a.Foreground = num > lockedTo ? (Brush)bc.ConvertFrom("#cf901b") : a.Foreground;
                    a.Content = num <= lockedTo ? num++.ToString() : "🔒";
                    a.Click += Button_Click;
                    Grid.SetRow(a, r);
                    Grid.SetColumn(a, c);
                    g.Children.Add(a);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Content.ToString();
            int s;
            bool result = int.TryParse(name, out s);
            if (result)
            {
                string loc = $"../../../Levels/{name}.txt";
                GuiGameMatrix? temp = GuiFileHandler.MakeMatrixsFormFile(loc);
                if (temp != null)
                {
                    LevelEditorPage.GuiMatrix = temp;
                    GuiLevelEditorHelper.LoadGrid(LevelEditorPage.Instance.gArea, LevelEditorPage.GuiMatrix);
                    uint row = (uint)LevelEditorPage.GuiMatrix.Decor.GetLength(0), column = (uint)LevelEditorPage.GuiMatrix.Decor.GetLength(1);
                    LevelEditorPage.context.Size_Column = row;
                    LevelEditorPage.context.Size_Column = column;
                    MainWindow.context.MakeVisible("LevelEditor");
                }
            }
            //MainWindow.context.MakeVisible("GameWindow");
        }
    }
}
