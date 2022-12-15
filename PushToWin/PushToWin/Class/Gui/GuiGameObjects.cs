using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace PushToWin.Class.Gui
{
    public class GuiGameObjects
    {
        public string Name { get; set; }
        public uint? Value { get; set; }
        public BitmapImage? ImgSrc { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsObject { get; set; }
        public bool IsDecor { get; set; }

        public GuiGameObjects(string n, BitmapImage? i = null,uint? value = null,bool isPlayer = false,bool isObject = false, bool isDecor = false)
        {
            this.Name = n;
            this.ImgSrc = i;
            this.Value = value;
            this.IsPlayer = isPlayer;
            this.IsObject = isObject;
            this.IsDecor = isDecor;
        }
    }
}
