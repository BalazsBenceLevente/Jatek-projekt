using PushToWin.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace PushToWin.Class.Gui
{
    public class GuiHelper
    {
        public static void MakeRowDefinition(Grid g,uint size)
        {
            if (g.RowDefinitions.Count == size) return;
            int nextSize = (int)size - (int)g.RowDefinitions.Count;
            if (nextSize >= 1)
            {
                for (int i = 0; i < nextSize; i++)
                {
                    RowDefinition row = new RowDefinition();
                    g.RowDefinitions.Add(row);
                }

                if (g.RowDefinitions.Count != size)
                {
                    throw new Exception("Nem ugyan az méret");
                }
            }
            else if (nextSize <= -1)
            {
                for (int i = nextSize; i < 0; i++)
                {
                    g.RowDefinitions.RemoveAt(0);
                }
                if (g.RowDefinitions.Count != size)
                {
                    throw new Exception("Nem ugyan az méret");
                }
            }

        }
        public static void MakeColumnDefinition(Grid g, uint size)
        {
            if (g.ColumnDefinitions.Count == size) return;
            int nextSize = (int)size - (int)g.ColumnDefinitions.Count;
            if (nextSize >= 1)
            {
                for (int i = 0; i < nextSize; i++)
                {
                    ColumnDefinition col = new ColumnDefinition();
                    g.ColumnDefinitions.Add(col);
                }
                
                if(g.ColumnDefinitions.Count != size)
                {
                    throw new Exception("Nem ugyan az méret");
                }
            }
            else if (nextSize<=-1)
            {
                for (int i = nextSize; i < 0; i++)
                {
                    g.ColumnDefinitions.RemoveAt(0);
                }
                if (g.ColumnDefinitions.Count != size)
                {
                    throw new Exception("Nem ugyan az méret");
                }
            }
        }       
    }
}
