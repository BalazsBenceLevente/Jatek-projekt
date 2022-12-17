using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PushToWin.ViewModels
{
    public class LevelEditorSelectModel : INotifyPropertyChanged
    {
        #region ImgChangeModel
        private string
            makeLevel = "Button1.png",
            loadLevel = "Button1.png";

        private string
            makeLevelP = "ButtonPressed1.png",
            loadLevelP = "ButtonPressed1.png";


        public string MakeLevel
        {
            get { return "../img/pages/buttons/" + makeLevel; }
            set
            {
                makeLevel = value;
                PropertyChangedHandler(makeLevel);
            }
        }

        public string LoadLevel
        {
            get { return "../img/pages/buttons/" + loadLevel; }
            set
            {
                loadLevel = value;
                PropertyChangedHandler(loadLevel);
            }
        }
        public void ImgSwitch(string name)
        {
            switch (name)
            {
                case "MakeLevel":
                    (makeLevel, makeLevelP) = (makeLevelP, makeLevel);
                    PropertyChangedHandler(nameof(makeLevel));
                    break;
                case "LoadLevel":
                    (loadLevel, loadLevelP) = (loadLevelP, loadLevel);
                    PropertyChangedHandler(nameof(loadLevel));
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
