using PushToWin.Class.Gui;
using PushToWin.ViewModels;
using PushToWin.Windows;
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
        public static void Img_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) // TODO: átdolgoz, doboz Masegebox szám (0-99)
        {
            Image img = (sender as Image);
            int row = Grid.GetRow(img), column= Grid.GetColumn(img);
            if (context.CBIsDelete) 
            {
                Img_MouseDelete(img,row,column);               
                return;
            }
            if (context.ItemIsPlayer)
            {
                Img_MouseIsPlayer(img,row,column);
                return;
            }
            else if (context.ItemIsObject)
            {
                Img_MouseIsObject(img, row, column);
                return;
            }
            else if (context.ItemIsDecor)
            {
                Img_MouseItemIsDecor(img, row, column);
                return;
            }
        }
        private static void Img_MouseDelete(Image img,int row,int column) // done
        {
            img.Source = LevelEditorModel.ItemEmpty.ImgSrc;
            GuiLevelEditorHelper.SetImgFloor3(Instance.gArea, (uint)row, (uint)column, LevelEditorModel.ItemEmpty.ImgSrc);
            GuiLevelEditorHelper.SetTextFloor2(Instance.gArea, (uint)row, (uint)column, "");
            GuiMatrix.Objects[row, column] = null;
        }
        private static void Img_MouseIsPlayer(Image img, int row, int column) //done
        {
            Tuple<uint, uint>? playerIndex = GuiLevelEditorHelper.FindPlayerChildrenIndex(GuiMatrix.Objects);
            if (playerIndex != null)
            {
                Image i = Instance.gArea.Children[(int)GuiLevelEditorHelper.D1[playerIndex]] as Image;
                i.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                GuiMatrix.Objects[playerIndex.Item1, playerIndex.Item2] = null;
            }
            img.Source = context.ItemImgSrc;
            GuiLevelEditorHelper.SetImgFloor3(Instance.gArea, (uint)row, (uint)column, LevelEditorModel.ItemEmpty.ImgSrc);
            GuiLevelEditorHelper.SetTextFloor2(Instance.gArea, (uint)row, (uint)column, "");
            GuiMatrix.Objects[row, column] = context.ItemSelected;
        }
        private static void Img_MouseIsObject(Image img, int row, int column) // box szám beir 
        {
            string valueSet = "";
            if(context.ItemName == "Doboz") //ha doboz
            {
                GuiInputDialogBox inputDialog = new GuiInputDialogBox("Please give a number between (0-9):","Number Input",0,9,true);
                if (inputDialog.ShowDialog() == false) return;
                context.Value = (uint)inputDialog.Answer;
                valueSet = inputDialog.Answer.ToString();
            }
            GuiLevelEditorHelper.SetImgFloor3(Instance.gArea, (uint)row, (uint)column, context.ItemImgSrc);
            GuiLevelEditorHelper.SetTextFloor2(Instance.gArea, (uint)row, (uint)column, valueSet);
            GuiMatrix.Objects[row, column] = context.ItemSelected;
        }
        private static void Img_MouseItemIsDecor(Image img, int row, int column) //okés
        {
            GuiLevelEditorHelper.SetImgFloor4(Instance.gArea, (uint)row, (uint)column, context.ItemImgSrc);
            GuiMatrix.Decor[row, column] = context.ItemSelected;
        }
    }
}