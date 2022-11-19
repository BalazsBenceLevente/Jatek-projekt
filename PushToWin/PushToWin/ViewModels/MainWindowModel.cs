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
        private Visibility visibility_start = Visibility.Visible;
        private Visibility visibility_pause = Visibility.Hidden;
        private Visibility visibility_levelSelector = Visibility.Hidden;
        private Visibility visibility_levelEditorSelect = Visibility.Hidden;
        private Visibility visibility_levelEditor = Visibility.Hidden;
        private Visibility visibility_levelGameWindow = Visibility.Hidden;
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
        public Visibility Visibility_Pause
        {
            get
            {
                return visibility_pause;
            }
            set
            {
                visibility_pause = value;
                PropertyChangedHandler(nameof(visibility_pause));
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
        public Visibility Visibility_LevelGameWindow
        {
            get
            {
                return visibility_levelGameWindow;
            }
            set
            {
                visibility_levelGameWindow = value;
                PropertyChangedHandler(nameof(visibility_levelGameWindow));
            }
        }
        public void MakeVisible(string s)
        {
            visibility_start = s == "Start" ? Visibility.Visible : Visibility.Hidden;
            visibility_pause = s == "Pause" ? Visibility.Visible : Visibility.Hidden;
            visibility_levelSelector = s == "LevelSelector" ? Visibility.Visible : Visibility.Hidden;
            visibility_levelEditorSelect = s == "LevelEditorSelect" ? Visibility.Visible : Visibility.Hidden;
            visibility_levelEditor = s == "LevelEditor" ? Visibility.Visible : Visibility.Hidden;
            visibility_levelGameWindow = s == "GameWindow" ? Visibility.Visible : Visibility.Hidden;
            PropertyChangedHandler(nameof(visibility_start));
            PropertyChangedHandler(nameof(visibility_pause));
            PropertyChangedHandler(nameof(visibility_levelSelector));
            PropertyChangedHandler(nameof(visibility_levelEditorSelect));
            PropertyChangedHandler(nameof(visibility_levelEditor));
            PropertyChangedHandler(nameof(visibility_levelGameWindow));

        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        void PropertyChangedHandler([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
