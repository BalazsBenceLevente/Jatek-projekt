using PushToWin.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media.Imaging;

namespace PushToWin.ViewModels
{
    public class LevelEditorModel : INotifyPropertyChanged
    {
        public string ItemName { get; set; }
        public BitmapImage ItemImgSrc { get; set; }

        private GuiGameObjects _itemsSelected;
        public GuiGameObjects ItemsSelected { get { return _itemsSelected; } 
            set {
                _itemsSelected = value;
                PropertyChangedHandler(nameof(_itemsSelected));
                ItemName = value.Name;
                PropertyChangedHandler(nameof(ItemName));
                ItemImgSrc = value.ImgSrc;
                PropertyChangedHandler(nameof(ItemImgSrc));
            } 
        }
        private static ObservableCollection<GuiGameObjects> _player = new ObservableCollection<GuiGameObjects>()
        {
            new GuiGameObjects("Plusz",new BitmapImage(new Uri("/img/game/character/Plusz.png",UriKind.Relative))),
            new GuiGameObjects("Minusz",new BitmapImage(new Uri("/img/game/character/Minusz.png",UriKind.Relative))),

        };
        public ObservableCollection<GuiGameObjects> ItemsPlayer => _player;
        //ObservableCollection<GuiGameObjects> _object = new ObservableCollection<GuiGameObjects>()
        //{
        //    new GuiGameObjects("Plusz",new Uri("",UriKind.Relative)),

        //};
        //public ObservableCollection<GuiGameObjects> ItemsObject => _object;
        //ObservableCollection<GuiGameObjects> _decor = new ObservableCollection<GuiGameObjects>()
        //{
        //    new GuiGameObjects("Plusz",new Uri("",UriKind.Relative)),

        //};
        //public ObservableCollection<GuiGameObjects> ItemsDecor => _decor;
        public event PropertyChangedEventHandler PropertyChanged;
        void PropertyChangedHandler([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
