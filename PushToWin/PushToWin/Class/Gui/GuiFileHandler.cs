using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PushToWin.Class.Gui
{
    public class GuiFileHandler
    {
        public static void SaveLevelToFile(string location,GuiGameMatrix matrixs)
        {
            StreamWriter sw = new StreamWriter(location);
            uint row = (uint)matrixs.Decor.GetLength(0), column = (uint)matrixs.Decor.GetLength(1);
            sw.WriteLine($"{row};{column}");
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    sw.WriteLine(matrixs.Decor[r,c].MakeString());
                }
            }
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < column; c++)
                {
                    if (matrixs.Objects[r, c] == null)
                    {
                        sw.WriteLine("null");
                    }
                    else
                    {
                        sw.WriteLine(matrixs.Objects[r, c].MakeString());
                    }
                }
            }
            sw.Close();
        }
        public static GuiGameMatrix? MakeMatrixsFormFile(string location)
        {
            try
            {
                GuiGameMatrix temp;
                StreamReader sr = new StreamReader(location,Encoding.UTF8);
                string[] size = sr.ReadLine().Split(';');
                uint row = uint.Parse(size[0]), col = uint.Parse(size[1]);
                temp = new GuiGameMatrix(row,col);
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                    {
                        string[] s = sr.ReadLine().Split(';');
                        BitmapImage? parse1 = s[1] == string.Empty ? null : new BitmapImage(new Uri(s[1], UriKind.Absolute));
                        uint? parse2;
                        if (s[2] == string.Empty) parse2 = null; else parse2 = uint.Parse(s[2]);
                        bool parse3 = bool.Parse(s[3]);
                        bool parse4 = bool.Parse(s[4]);
                        bool parse5 = bool.Parse(s[5]);
                        temp.Decor[r, c] =
                            new GuiGameObjects(
                                s[0],
                                parse1,
                                parse2,
                                parse3,
                                parse4,
                                parse5
                        );
                    }
                }
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++)
                    {
                        string[] s = sr.ReadLine().Split(';');
                        if (s.Length == 1 && s[0] == "null")
                        {
                            temp.Objects[r, c] = null;
                        }
                        else
                        {
                            BitmapImage? parse1 = s[1] == string.Empty ? null : new BitmapImage(new Uri(s[1]));
                            uint? parse2;
                            if (s[2] == string.Empty) parse2 = null; else parse2 = uint.Parse(s[2]);
                            bool parse3 = bool.Parse(s[3]);
                            bool parse4 = bool.Parse(s[4]);
                            bool parse5 = bool.Parse(s[5]);
                            temp.Objects[r, c] =
                                new GuiGameObjects(
                                    s[0],
                                    parse1,
                                    parse2,
                                    parse3,
                                    parse4,
                                    parse5
                            );
                        }
                    }
                }
                return temp;
            }
            catch (Exception)
            {
                MessageBox.Show("File corrupted !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
