using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PushToWin.ViewModels
{
    public class StartWindowModel : INotifyPropertyChanged
    {
        #region ImgChangeModel
        private string
            start = "Start.png",
            levelSelector = "LevelSelector.png",
            mapEditor = "MapEditor.png",
            quit = "Quit.png",
            //HoverImg
            startHover = "Logo.png",
            levelHover = "Logo.png",
            mapEditorHover = "Logo.png",
            quitHover = "Logo.png";
        public string Start
        {
            get
            {
                return "/img/mainwindow/" + start;
            }
            set
            {
                start = value;
                PropertyChangedHandler(nameof(start));
            }
        }
        public string LevelSelector
        {
            get
            {
                return "/img/mainwindow/" + levelSelector;
            }
            set
            {
                levelSelector = value;
                PropertyChangedHandler(nameof(levelSelector));
            }
        }
        public string MapEditor
        {
            get
            {
                return "/img/mainwindow/" + mapEditor;
            }
            set
            {
                mapEditor = value;
                PropertyChangedHandler(nameof(mapEditor));
            }
        }
        public string Quit {
            get
            {
                return "/img/mainwindow/" + quit;
            }
            set
            {
                quit = value;
                PropertyChangedHandler(nameof(quit));
            }
        }
        public void ImgSwitch(string name) {
            switch (name)
            {
                case "btStart":
                    (start, startHover) = (startHover, start);
                    PropertyChangedHandler(nameof(start));
                    break;
                case "btLevelSelector":
                    (levelSelector, levelHover) = ( levelHover, levelSelector);
                    PropertyChangedHandler(nameof(levelSelector));
                    break;
                case "btMapEditor":
                    (mapEditor, mapEditorHover) = (mapEditorHover, mapEditor);
                    PropertyChangedHandler(nameof(mapEditor));
                    break;
                case "btQuit":
                    (quit, quitHover) = (quitHover,quit);
                    PropertyChangedHandler(nameof(quit));
                    break;
            }
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        void PropertyChangedHandler([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
