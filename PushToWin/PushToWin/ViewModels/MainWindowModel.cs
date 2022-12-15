using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace PushToWin.ViewModels
{
    public class MainWindowModel : INotifyPropertyChanged
    {

        #region PageVisibilityModel
        public string VisibilityActiveName { get; set; } = "Start";

        private Visibility visibility_start = Visibility.Visible;
        private Visibility visibility_levelSelector = Visibility.Hidden;
        private Visibility visibility_levelEditorSelect = Visibility.Hidden;
        private Visibility visibility_levelEditor = Visibility.Hidden;
        private Visibility visibility_levelEditorEsc = Visibility.Hidden;
        private Visibility visibility_gameWindow = Visibility.Hidden;
        private Visibility visibility_gameWindowEsc = Visibility.Hidden;
        public Visibility Visibility_Start
        {
            get
            {
                return visibility_start;
            }
            set
            {
                visibility_start = value;
                PropertyChangedHandler(nameof(visibility_start));
            }
        }
        public Visibility Visibility_LevelSelector
        {
            get
            {
                return visibility_levelSelector;
            }
            set
            {
                visibility_levelSelector = value;
                PropertyChangedHandler(nameof(visibility_levelSelector));
            }
        }
        public Visibility Visibility_LevelEditorSelect
        {
            get
            {
                return visibility_levelEditorSelect;
            }
            set
            {
                visibility_levelEditorSelect = value;
                PropertyChangedHandler(nameof(visibility_levelEditorSelect));
            }
        }
        public Visibility Visibility_LevelEditor
        {
            get
            {
                return visibility_levelEditor;
            }
            set
            {
                visibility_levelEditor = value;
                PropertyChangedHandler(nameof(visibility_levelEditor));
            }
        }
        public Visibility Visibility_LevelEditorEsc
        {
            get
            {
                return visibility_levelEditorEsc;
            }
            set
            {
                visibility_levelEditorEsc = value;
                PropertyChangedHandler(nameof(visibility_levelEditorEsc));
            }
        }
        public Visibility Visibility_GameWindow
        {
            get
            {
                return visibility_gameWindow;
            }
            set
            {
                visibility_gameWindow = value;
                PropertyChangedHandler(nameof(visibility_gameWindow));
            }
        }
        public Visibility Visibility_GameWindowEsc
        {
            get
            {
                return visibility_gameWindowEsc;
            }
            set
            {
                visibility_gameWindowEsc = value;
                PropertyChangedHandler(nameof(visibility_gameWindowEsc));
            }
        }
        public void MakeVisible(string s)
        {
            visibility_start = s == "Start" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_start));
            visibility_levelSelector = s == "LevelSelector" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_levelSelector));
            visibility_levelEditorSelect = s == "LevelEditorSelect" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_levelEditorSelect));
            visibility_levelEditor = s == "LevelEditor" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_levelEditor));
            visibility_levelEditorEsc = s == "LevelEditorEsc" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_levelEditorEsc));
            visibility_gameWindow = s == "GameWindow" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_gameWindow));
            visibility_gameWindowEsc = s == "GameWindowEsc" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_gameWindowEsc));
            List<string> allowedWords = new List<string> { "Start", "LevelSelector", "LevelEditorSelect", "LevelEditor", "LevelEditorEsc", "GameWindow", "GameWindowEsc" };
            VisibilityActiveName = allowedWords.Contains(s) ? allowedWords[allowedWords.FindIndex(x=>x == s)] : "";
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        void PropertyChangedHandler([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
