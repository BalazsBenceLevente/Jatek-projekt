using PushToWin.Class;
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
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = context;
            Dispatcher.BeginInvoke(new Action(() => InitGrid()), DispatcherPriority.ContextIdle, null);
        }
        private void InitGrid()
        {
            GuiHelper.MakeColumnDefinition(gArea,context.Size_X);
            GuiHelper.MakeRowDefinition(gArea,context.Size_Y);
            GuiHelper.DrawAllScreen(gArea, context.Size_X, context.Size_Y, (CB_Decor.Items[2] as GuiGameObjects).ImgSrc);
        }

        private Regex _regex = new Regex("[^0-9]+");
        private void NumbersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }

        private void Set_Click(object sender, RoutedEventArgs e)
        {
            string txt = context.Size_X >= 50 || context.Size_Y >= 50 ? "Too large playing field can efect the application preformance!" : "";
            if (context.CBIsChecked || MessageBox.Show($"Are you sure you want to resize? (It will delete everything!)\n{txt}", "Resize?", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                GuiHelper.MakeColumnDefinition(gArea, context.Size_X);
                GuiHelper.MakeRowDefinition(gArea, context.Size_Y);
                GuiHelper.DrawAllScreen(gArea, context.Size_X, context.Size_Y, context.ItemImgSrc);
            }
        }
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            (sender as ComboBox).SelectedIndex = 0;
        }
    }
}
