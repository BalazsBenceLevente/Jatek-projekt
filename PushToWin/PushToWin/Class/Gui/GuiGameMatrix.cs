using System;
using System.Collections.Generic;
using System.Text;

namespace PushToWin.Class.Gui
{
    public class GuiGameMatrix
    {
        public GuiGameObjects[,] Objects { get; set; }
        public GuiGameObjects[,] Decor { get; set; }

        public GuiGameMatrix(uint x,uint y)
        {
            Objects = new GuiGameObjects[x,y];
            Decor = new GuiGameObjects[x,y];
        }
    }
}
