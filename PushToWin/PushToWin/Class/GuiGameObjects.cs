using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace PushToWin.Class
{
    public class GuiGameObjects
    {
        public string Name { get; set; }
        public BitmapImage ImgSrc { get; set; }

        public GuiGameObjects(string n, BitmapImage i)
        {
            this.Name = n;
            this.ImgSrc = i;
        }
    }
}
