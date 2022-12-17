using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Imaging;

namespace PushToWin.ViewModels
{
    public class LevelEditorEscModel : INotifyPropertyChanged
    {
        #region ImgChangeModel
        private string 
            reset = "Button1.png",
            mainMenu = "Button1.png",
            quitGame = "Button1.png",
            saveLevel = "Button1.png",
            testLevel = "Button1.png";
        private string
            resetP = "ButtonPressed1.png",
            mainMenuP = "ButtonPressed1.png",
            quitGameP = "ButtonPressed1.png",
            saveLevelP = "ButtonPressed1.png",
            testLevelP = "ButtonPressed1.png";

        public string Reset
        {
            get { return "../img/pages/buttons/" + reset; }
            set
            {
                testLevel = value;
                PropertyChangedHandler(reset);
            }
        }

        public string MainMenu
        {
            get { return "../img/pages/buttons/" + mainMenu; }
            set
            {
                testLevel = value;
                PropertyChangedHandler(mainMenu);
            }
        }

        public string QuitGame
        {
            get { return "../img/pages/buttons/" + quitGame; }
            set
            {
                testLevel = value;
                PropertyChangedHandler(quitGame);
            }
        }

        public string SaveLevel
        {
            get { return "../img/pages/buttons/" + saveLevel; }
            set
            {
                testLevel = value;
                PropertyChangedHandler(saveLevel);
            }
        }

        public string TestLevel
        {
            get { return "../img/pages/buttons/" + testLevel; }
            set
            {
                testLevel = value;
                PropertyChangedHandler(testLevel);
            }
        }
        public void ImgSwitch(string name) {
            switch (name)
            {
                case "Reset":
                    (reset, resetP) = (resetP, reset);
                    PropertyChangedHandler(nameof(reset));
                    break;
                case "MainMenu":
                    (mainMenu, mainMenuP) = ( mainMenuP, mainMenu);
                    PropertyChangedHandler(nameof(mainMenu));
                    break;
                case "QuitGame":
                    (quitGame, quitGameP) = (quitGameP, quitGame);
                    PropertyChangedHandler(nameof(quitGame));
                    break;
                case "SaveLevel":
                    (saveLevel, saveLevelP) = (saveLevelP,saveLevel);
                    PropertyChangedHandler(nameof(saveLevel));
                    break;
                case "TestLevel":
                    (testLevel, testLevelP) = (testLevelP, testLevel);
                    PropertyChangedHandler(nameof(testLevel));
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
