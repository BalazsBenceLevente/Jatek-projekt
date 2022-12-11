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
        private static LevelEditorPage Instance { get;  set; }
        public static LevelEditorModel context = new LevelEditorModel();
        public static GuiGameMatrix GuiMatrix = new GuiGameMatrix(context.Size_Row,context.Size_Column);
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = context;
            Instance = this;
            Dispatcher.BeginInvoke(new Action(() => GuiLevelEditorHelper.InitGrid(gArea,CB_Decor.Items[4] as GuiGameObjects)), DispatcherPriority.Loaded, null);
        }

        private Regex _regex = new Regex("[^0-9]+");
        private void NumbersOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }
        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            (sender as ComboBox).SelectedIndex = 0;
        }
        private void Set_Click(object sender, RoutedEventArgs e)
        {
            if (CB_Decor.SelectedIndex == -1 || !(CB_Decor.Items[CB_Decor.SelectedIndex] as GuiGameObjects).IsDecor)
            {
                MessageBox.Show($"No Ground selected!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (context.CBIsChecked) {
                GuiLevelEditorHelper.InitGrid(gArea,CB_Decor.SelectedItem as GuiGameObjects);
                return;
            }
            if (((context.Size_Column >= 50) || (context.Size_Row >= 50)) && MessageBox.Show($"Too large playing field can efect the application preformance! Are you sure you want to continue ?", "Too Large!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            if (MessageBox.Show($"Are you sure you want to resize? (It will delete everything!)", "Resize?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            GuiLevelEditorHelper.InitGrid(gArea,CB_Decor.SelectedItem as GuiGameObjects);
        }
        public static void Img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var img = (sender as Image);
            int row = Grid.GetRow(img), column= Grid.GetColumn(img);
            if (context.CBIsDelete) 
            {
                img.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                GuiMatrix.Objects[row, column] = null;
                return;
            }
            if (context.ItemIsPlayer)
            {
                Tuple<uint,uint>? playerIndex = GuiLevelEditorHelper.FindPlayerChildrenIndex(GuiMatrix.Objects);
                if (playerIndex != null)
                {
                    Image i = Instance.gArea.Children[(int)GuiLevelEditorHelper.DForeGround[playerIndex]] as Image;
                    i.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                    GuiMatrix.Objects[playerIndex.Item1, playerIndex.Item2] = null;
                }
                img.Source = context.ItemImgSrc;
                GuiMatrix.Objects[row,column] = context.ItemSelected;
            }
            else if (context.ItemIsObject)
            {
                img.Source = context.ItemImgSrc;
                GuiMatrix.Objects[row, column] = context.ItemSelected;
            }
            else if (context.ItemIsDecor)
            {
                GuiLevelEditorHelper.SetImgGround(Instance.gArea, (uint)row, (uint)column,context.ItemImgSrc);
                GuiMatrix.Decor[row, column] = context.ItemSelected;
            }
        }
    }
}