using PushToWin.Pages;
using PushToWin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PushToWin.Class.Gui
{
    public class GuiLevelEditorHelper
    {
        public static void InitGrid(Grid g, GuiGameObjects decorSelect)
        {
            var context = LevelEditorPage.context;
            if (decorSelect.IsDecor)
            {
                //Clear
                g.Children.Clear();
                //Make Grid
                GuiHelper.MakeRowDefinition(g, context.Size_Row);
                GuiHelper.MakeColumnDefinition(g, context.Size_Column);
                //Set Gird
                DrawAllScreen(g, context.Size_Row, context.Size_Column, decorSelect.ImgSrc);
                //Set Matrix
                LevelEditorPage.GuiMatrix = new GuiGameMatrix(context.Size_Row, context.Size_Column);
                for (int r = 0; r < context.Size_Row; r++)
                {
                    for (int c = 0; c < context.Size_Column; c++)
                    {
                        LevelEditorPage.GuiMatrix.Decor[r, c] = decorSelect;
                    }
                }
            }
        }
        public static Dictionary<Tuple<uint, uint>, uint> D3;
        public static Dictionary<Tuple<uint, uint>, uint> D2;
        public static Dictionary<Tuple<uint, uint>, uint> D1;
        public static void DrawAllScreen(Grid g, uint row, uint column, BitmapImage setImg)
        {
            g.Children.Clear();
            uint count = 0;
            D3 = new Dictionary<Tuple<uint, uint>, uint>();
            D2 = new Dictionary<Tuple<uint, uint>, uint>();
            D1 = new Dictionary<Tuple<uint, uint>, uint>();
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {   
                    Image g3 = new Image();
                    g3.Source = setImg;
                    Image g2 = new Image();
                    g2.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                    Image g1 = new Image();
                    g1.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                    g1.MouseUp += LevelEditorPage.Img_MouseLeftButtonUp;
                    D3.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    D2.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    D1.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    Grid.SetRow(g3, r);
                    Grid.SetColumn(g3, c);
                    Grid.SetRow(g2, r);
                    Grid.SetColumn(g2, c);
                    Grid.SetRow(g1, r);
                    Grid.SetColumn(g1, c);
                    g.Children.Add(g3);
                    g.Children.Add(g2);
                    g.Children.Add(g1);
                }
            }
        }
        public static void SetImgFloor3(Grid g, uint row, uint column, BitmapImage setImg)
        {
            Image n = g.Children[(int)D3[new Tuple<uint, uint>(row,column)]] as Image;
            n.Source = setImg;
        }
        public static void SetImgFloor2(Grid g, uint row, uint column, BitmapImage setImg)
        {
            Image n = g.Children[(int)D2[new Tuple<uint, uint>(row, column)]] as Image;
            n.Source = setImg;
        }
        public static Tuple<uint,uint>? FindPlayerChildrenIndex(GuiGameObjects[,] matrix)
        {
            uint row = (uint)matrix.GetLength(0), column = (uint)matrix.GetLength(1);
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    if (matrix[r, c] != null && matrix[r, c].IsPlayer) return new Tuple<uint, uint>((uint)r, (uint)c);
                }
            }
            return null;
        }
    }
}
