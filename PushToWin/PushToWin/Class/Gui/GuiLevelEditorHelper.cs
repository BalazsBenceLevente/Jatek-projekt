using PushToWin.Pages;
using PushToWin.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

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
                ReDrawAllScreen(g, context.Size_Row, context.Size_Column, decorSelect.ImgSrc);
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
        public static void LoadGrid(Grid g,GuiGameMatrix matrixs)
        {
            //Clear
            g.Children.Clear();
            //Make Grid
            uint row = (uint)matrixs.Decor.GetLength(0), column = (uint)matrixs.Decor.GetLength(1);
            GuiHelper.MakeRowDefinition(g, row);
            GuiHelper.MakeColumnDefinition(g, column);
            //DrawScreen
            ReDrawScreen(g,row,column,matrixs);
        }
        public static Dictionary<Tuple<uint, uint>, uint> D4;
        public static Dictionary<Tuple<uint, uint>, uint> D3;
        public static Dictionary<Tuple<uint, uint>, uint> D2;
        public static Dictionary<Tuple<uint, uint>, uint> D1;
        public static void ReDrawScreen(Grid g, uint row, uint column, GuiGameMatrix matrixs)
        {
            g.Children.Clear();
            uint count = 0;
            D4 = new Dictionary<Tuple<uint, uint>, uint>();
            D3 = new Dictionary<Tuple<uint, uint>, uint>();
            D2 = new Dictionary<Tuple<uint, uint>, uint>();
            D1 = new Dictionary<Tuple<uint, uint>, uint>();
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    Image g4 = new Image();
                    g4.Source = LevelEditorPage.GuiMatrix.Decor[r,c].ImgSrc;
                    Image g3 = new Image();
                    if (LevelEditorPage.GuiMatrix.Objects[r, c] != null && LevelEditorPage.GuiMatrix.Objects[r, c].IsObject)
                    {
                        g3.Source = LevelEditorPage.GuiMatrix.Objects[r, c].ImgSrc;
                    }
                    else
                    {
                        g3.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                    }
                    TextBox g2 = new TextBox();
                    g2.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "../Fonts/#Karmatic Arcade");
                    g2.HorizontalContentAlignment = HorizontalAlignment.Center;
                    g2.VerticalContentAlignment = VerticalAlignment.Center;
                    g2.Background = Brushes.Transparent;
                    g2.BorderThickness = new Thickness(0);
                    g2.Margin = new Thickness(0, 0, 20, 0);
                    g2.FontSize = 250;
                    g2.Text = LevelEditorPage.GuiMatrix.Objects[r, c] != null ? LevelEditorPage.GuiMatrix.Objects[r, c].Value.ToString() : "";
                    Image g1 = new Image();
                    g1.MouseUp += LevelEditorPage.Img_MouseLeftButtonUp;
                    if (LevelEditorPage.GuiMatrix.Objects[r, c] != null && LevelEditorPage.GuiMatrix.Objects[r, c].IsPlayer)
                    {
                        g1.Source = LevelEditorPage.GuiMatrix.Objects[r, c].ImgSrc;
                    }
                    else
                    {
                        g1.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                    }
                    D4.Add(new Tuple<uint, uint>((uint)r, (uint)c), count++);
                    D3.Add(new Tuple<uint, uint>((uint)r, (uint)c), count++);
                    D2.Add(new Tuple<uint, uint>((uint)r, (uint)c), count++);
                    D1.Add(new Tuple<uint, uint>((uint)r, (uint)c), count++);
                    Grid.SetRow(g4, r);
                    Grid.SetColumn(g4, c);
                    Grid.SetRow(g3, r);
                    Grid.SetColumn(g3, c);
                    Grid.SetRow(g2, r);
                    Grid.SetColumn(g2, c);
                    Grid.SetRow(g1, r);
                    Grid.SetColumn(g1, c);
                    g.Children.Add(g4);
                    g.Children.Add(g3);
                    g.Children.Add(g2);
                    g.Children.Add(g1);
                }
            }
        }
        public static void ReDrawAllScreen(Grid g, uint row, uint column, BitmapImage setImg)
        {
            g.Children.Clear();
            uint count = 0;
            D4 = new Dictionary<Tuple<uint, uint>, uint>();
            D3 = new Dictionary<Tuple<uint, uint>, uint>();
            D2 = new Dictionary<Tuple<uint, uint>, uint>();
            D1 = new Dictionary<Tuple<uint, uint>, uint>();
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {   
                    Image g4 = new Image();
                    g4.Source = setImg;
                    Image g3 = new Image();
                    g3.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                    TextBox g2 = new TextBox();
                    g2.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "../Fonts/#Karmatic Arcade");
                    g2.HorizontalContentAlignment = HorizontalAlignment.Center;
                    g2.VerticalContentAlignment = VerticalAlignment.Center;
                    g2.Background = Brushes.Transparent;
                    g2.BorderThickness = new Thickness(0);
                    g2.Margin = new Thickness(0,0,20,0);
                    g2.FontSize = 250;
                    Image g1 = new Image();
                    g1.Source = LevelEditorModel.ItemEmpty.ImgSrc;
                    g1.MouseUp += LevelEditorPage.Img_MouseLeftButtonUp;
                    D4.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    D3.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    D2.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    D1.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    Grid.SetRow(g4, r);
                    Grid.SetColumn(g4, c);
                    Grid.SetRow(g3, r);
                    Grid.SetColumn(g3, c);
                    Grid.SetRow(g2, r);
                    Grid.SetColumn(g2, c);
                    Grid.SetRow(g1, r);
                    Grid.SetColumn(g1, c);
                    g.Children.Add(g4);
                    g.Children.Add(g3);
                    g.Children.Add(g2);
                    g.Children.Add(g1);
                }
            }
        }
        public static void SetImgFloor4(Grid g, uint row, uint column, BitmapImage setImg)
        {
            Image n = g.Children[(int)D4[new Tuple<uint, uint>(row,column)]] as Image;
            n.Source = setImg;
        }
        public static void SetImgFloor3(Grid g, uint row, uint column, BitmapImage setImg)
        {
            Image n = g.Children[(int)D3[new Tuple<uint, uint>(row, column)]] as Image;
            n.Source = setImg;
        }
        public static void SetTextFloor2(Grid g, uint row, uint column, string setText)
        {
            TextBox n = g.Children[(int)D2[new Tuple<uint, uint>(row, column)]] as TextBox;
            n.Text  = setText;
        }
        public static void SetImgFloor1(Grid g, uint row, uint column, BitmapImage setImg)
        {
            Image n = g.Children[(int)D1[new Tuple<uint, uint>(row, column)]] as Image;
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
        public static void UpdateGrid(Grid g,GuiGameObjects[,] matrix)
        {
            uint row = (uint)matrix.GetLength(0), column = (uint)matrix.GetLength(1);
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    SetImgFloor3(g, (uint)r, (uint)c, LevelEditorModel.ItemEmpty.ImgSrc);
                    SetTextFloor2(g, (uint)r, (uint)c, "");
                    SetImgFloor1(g, (uint)r, (uint)c, LevelEditorModel.ItemEmpty.ImgSrc);
                    if (matrix[r, c] != null && matrix[r,c].IsPlayer)
                    {
                        SetImgFloor1(g, (uint)r, (uint)c, matrix[r,c].ImgSrc);
                    }
                    if (matrix[r, c] != null && matrix[r, c].IsObject)
                    {
                        SetImgFloor3(g, (uint)r, (uint)c, matrix[r, c].ImgSrc);
                        SetTextFloor2(g, (uint)r, (uint)c, matrix[r, c].Value != null ? matrix[r, c].Value.ToString() : "");
                    }
                }
            }
        }
    }
}
