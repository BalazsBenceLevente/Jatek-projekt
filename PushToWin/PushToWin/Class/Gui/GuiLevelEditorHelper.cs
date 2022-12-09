using PushToWin.Pages;
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
                        LevelEditorPage.GuiMatrix.Objects[r, c] = decorSelect;
                    }
                }
            }
        }
        static Dictionary<Tuple<uint, uint>, uint> DGround ;
        static Dictionary<Tuple<uint, uint>, uint> DForeGround ;
        public static void DrawAllScreen(Grid g, uint row, uint column, BitmapImage setImg)
        {
            g.Children.Clear();
            uint count = 0;
            DGround = new Dictionary<Tuple<uint, uint>, uint>();
            DForeGround = new Dictionary<Tuple<uint, uint>, uint>();
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {   
                    Image ground = new Image();
                    ground.Source = setImg;
                    Image foreground = new Image();
                    foreground.Source = new BitmapImage(new Uri("/img/game/emptyDebug.png", UriKind.Relative));
                    foreground.MouseUp += LevelEditorPage.Img_MouseLeftButtonUp;
                    DGround.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    DForeGround.Add(new Tuple<uint, uint>((uint)r, (uint)c),count++);
                    Grid.SetRow(ground, r);
                    Grid.SetColumn(ground, c);
                    Grid.SetRow(foreground, r);
                    Grid.SetColumn(foreground, c);
                    g.Children.Add(ground);
                    g.Children.Add(foreground);
                }
            }
        }
        public static void SetImgGround(Grid g, uint row, uint column, BitmapImage setImg)
        {
            //Image n = g.Children[(int)(row + column)] as Image;
            Image n = g.Children[(int)DGround[new Tuple<uint, uint>(row,column)]] as Image;
            n.Source = setImg;
        }        
    }
}
