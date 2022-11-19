using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PushToWin.ViewModels
{
    public class StartPageModel : INotifyPropertyChanged
    {
        #region ImgChangeModel
        private string
            img_start = "Start.png",
            img_levelSelector = "LevelSelector.png",
            img_mapEditor = "MapEditor.png",
            img_quit = "Quit.png",
            //HoverImg
            img_startHover = "Logo.png",
            img_levelHover = "Logo.png",
            img_mapEditorHover = "Logo.png",
            img_quitHover = "Logo.png";
        public string Img_Start
        {
            get
            {
                return "/img/pages/start/" + img_start;
            }
            set
            {
                img_start = value;
                PropertyChangedHandler(nameof(img_start));
            }
        }
        public string Img_LevelSelector
        {
            get
            {
                return "/img/pages/start/" + img_levelSelector;
            }
            set
            {
                img_levelSelector = value;
                PropertyChangedHandler(nameof(img_levelSelector));
            }
        }
        public string Img_MapEditor
        {
            get
            {
                return "/img/pages/start/" + img_mapEditor;
            }
            set
            {
                img_mapEditor = value;
                PropertyChangedHandler(nameof(img_mapEditor));
            }
        }
        public string Img_Quit {
            get
            {
                return "/img/pages/start/" + img_quit;
            }
            set
            {
                img_quit = value;
                PropertyChangedHandler(nameof(img_quit));
            }
        }
        public void ImgSwitch(string name) {
            switch (name)
            {
                case "GameWindow":
                    (img_start, img_startHover) = (img_startHover, img_start);
                    PropertyChangedHandler(nameof(img_start));
                    break;
                case "LevelSelector":
                    (img_levelSelector, img_levelHover) = ( img_levelHover, img_levelSelector);
                    PropertyChangedHandler(nameof(img_levelSelector));
                    break;
                case "LevelEditorSelect":
                    (img_mapEditor, img_mapEditorHover) = (img_mapEditorHover, img_mapEditor);
                    PropertyChangedHandler(nameof(img_mapEditor));
                    break;
                case "Quit":
                    (img_quit, img_quitHover) = (img_quitHover,img_quit);
                    PropertyChangedHandler(nameof(img_quit));
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
