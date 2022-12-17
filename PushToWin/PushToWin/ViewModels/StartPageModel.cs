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
            start = "Button1.png",
            levelSelector = "Button1.png",
            levelEditor = "Button1.png",
            quit = "Button1.png";
        private string
            startP = "ButtonPressed1.png",
            levelSelectorP = "ButtonPressed1.png",
            levelEditorP = "ButtonPressed1.png",
            quitP = "ButtonPressed1.png";

        public string Start
        {
            get { return "../img/pages/buttons/" + start; }
            set
            {
                start = value;
                PropertyChangedHandler(start);
            }
        }

        public string LevelSelector
        {
            get { return "../img/pages/buttons/" + levelSelector; }
            set
            {
                levelSelector = value;
                PropertyChangedHandler(levelSelector);
            }
        }

        public string LevelEditor
        {
            get { return "../img/pages/buttons/" + levelEditor; }
            set
            {
                levelEditor = value;
                PropertyChangedHandler(levelEditor);
            }
        }

        public string Quit
        {
            get { return "../img/pages/buttons/" + quit; }
            set
            {
                quit = value;
                PropertyChangedHandler(quit);
            }
        }
        public void ImgSwitch(string name)
        {
            switch (name)
            {
                case "Start":
                    (start, startP) = (startP, start);
                    PropertyChangedHandler(nameof(start));
                    break;
                case "LevelSelector":
                    (levelSelector, levelSelectorP) = (levelSelectorP, levelSelector);
                    PropertyChangedHandler(nameof(levelSelector));
                    break;
                case "LevelEditor":
                    (levelEditor, levelEditorP) = (levelEditorP, levelEditor);
                    PropertyChangedHandler(nameof(levelEditor));
                    break;
                case "Quit":
                    (quit, quitP) = (quitP, quit);
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
