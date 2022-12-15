using System;
using System.Collections.Generic;
using System.Text;

namespace PushToWin.Class.Gui
{
    public class GuiGameMatrix
    {
        public GuiGameObjects[,] Objects { get; set; }
        public GuiGameObjects[,] Decor { get; set; }

        public GuiGameMatrix(uint row, uint column)
        {
            Objects = new GuiGameObjects[row,column];
            Decor = new GuiGameObjects[row,column];
        }
    }
}
