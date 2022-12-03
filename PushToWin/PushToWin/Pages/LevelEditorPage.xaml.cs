using PushToWin.Class.Gui;
using PushToWin.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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
        GuiGameMatrix GuiMatrix;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = context;
            Dispatcher.BeginInvoke(new Action(() => InitGrid(CB_Decor.Items[2] as GuiGameObjects)), DispatcherPriority.Loaded, null);
        }
        private void InitGrid(GuiGameObjects decorSelect)
        {
            if (decorSelect.IsDecor)
            {
                //Clear
                gArea.Children.Clear();
                //Make Grid
                GuiHelper.MakeColumnDefinition(gArea,context.Size_X);
                GuiHelper.MakeRowDefinition(gArea,context.Size_Y);
                //Set Gird
                GuiHelper.DrawAllScreen(gArea, context.Size_X, context.Size_Y, decorSelect.ImgSrc);
                //Set Matrix
                GuiMatrix = new GuiGameMatrix(context.Size_X,context.Size_Y);
                for (int i = 0; i < context.Size_X; i++)
                {
                    for (int a = 0; a < context.Size_Y; a++)
                    {
                        GuiMatrix.Objects[i, a] = decorSelect;
                    }
                }
            }
        }

        private Regex _regex = new Regex("[^0-9]+");
        private void NumbersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            string txt = context.Size_X >= 50 || context.Size_Y >= 50 ? "Too large playing field can efect the application preformance!" : "";
            if (CB_Decor.SelectedIndex == -1 || !(CB_Decor.Items[CB_Decor.SelectedIndex] as GuiGameObjects).IsDecor)
            {
                MessageBox.Show($"No Decor selected!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (context.CBIsChecked || MessageBox.Show($"Are you sure you want to resize? (It will delete everything!)\n{txt}", "Resize?", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                InitGrid(CB_Decor.SelectedItem as GuiGameObjects);
            }
        }
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            (sender as ComboBox).SelectedIndex = 0;
        }
    }
}
