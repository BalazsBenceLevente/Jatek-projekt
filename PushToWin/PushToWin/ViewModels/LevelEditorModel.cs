using PushToWin.Class.Gui;
using PushToWin.Pages;
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
        #region SelectModel
        private static GuiGameObjects ItemDefault { get; set; } = new GuiGameObjects("<Select Item>",new BitmapImage(new Uri("/img/pages/leveleditor/SelectItem.png", UriKind.Relative)));
        public string ItemName { get; set; } = ItemDefault.Name;
        public BitmapImage ItemImgSrc { get; set; } = ItemDefault.ImgSrc;

        public GuiGameObjects ItemSelected => new GuiGameObjects(ItemName,ItemImgSrc);

        private GuiGameObjects _itemsPlayer;
        private GuiGameObjects _itemsObject;
        private GuiGameObjects _itemsDecor;
        public GuiGameObjects ItemsSelectPlayer
        {
            get { return _itemsPlayer; }
            set
            {
                _itemsPlayer = value;
                PropertyChangedHandler(nameof(_itemsPlayer));
                ItemName = value.Name;
                PropertyChangedHandler(nameof(ItemName));
                ItemImgSrc = value.ImgSrc;
                PropertyChangedHandler(nameof(ItemImgSrc));
            }
        }
        public GuiGameObjects ItemsSelectObject
        {
            get { return _itemsObject; }
            set
            {
                _itemsObject = value;
                PropertyChangedHandler(nameof(_itemsObject));
                ItemName = value.Name;
                PropertyChangedHandler(nameof(ItemName));
                ItemImgSrc = value.ImgSrc;
                PropertyChangedHandler(nameof(ItemImgSrc));
            }
        }
        public GuiGameObjects ItemsSelectDecor
        {
            get { return _itemsDecor; }
            set
            {
                _itemsDecor = value;
                PropertyChangedHandler(nameof(_itemsDecor));
                ItemName = value.Name;
                PropertyChangedHandler(nameof(ItemName));
                ItemImgSrc = value.ImgSrc;
                PropertyChangedHandler(nameof(ItemImgSrc));
            }
        }
        private static ObservableCollection<GuiGameObjects> _player = new ObservableCollection<GuiGameObjects>()
        {
            ItemDefault,
            new GuiGameObjects("Plusz",new BitmapImage(new Uri("/img/game/character/Plusz.png",UriKind.Relative)),isPlayer:true),
            new GuiGameObjects("Minusz",new BitmapImage(new Uri("/img/game/character/Minusz.png",UriKind.Relative)),isPlayer:true),
            new GuiGameObjects("Szorzas",new BitmapImage(new Uri("/img/game/character/Szorzas.png",UriKind.Relative)),isPlayer:true),

        };
        public ObservableCollection<GuiGameObjects> ItemsPlayer => _player;

        ObservableCollection<GuiGameObjects> _object = new ObservableCollection<GuiGameObjects>()
        {
           ItemDefault,
           new GuiGameObjects("Zaszlo",new BitmapImage(new Uri("/img/game/object/Zaszlo.png",UriKind.Relative)),isObject:true),
           new GuiGameObjects("Lakat",new BitmapImage(new Uri("/img/game/object/Lakat.png",UriKind.Relative)),isObject:true),
           new GuiGameObjects("Doboz",new BitmapImage(new Uri("/img/game/object/Doboz.png",UriKind.Relative)),isObject:true),
           new GuiGameObjects("Kő",new BitmapImage(new Uri("/img/game/object/Ko.png",UriKind.Relative)),isObject:true),
           new GuiGameObjects("Plusz",new BitmapImage(new Uri("/img/game/object/Plusz.png",UriKind.Relative)),isObject:true),
           new GuiGameObjects("Minusz",new BitmapImage(new Uri("/img/game/object/Minusz.png",UriKind.Relative)),isObject:true),
           new GuiGameObjects("Szorzás",new BitmapImage(new Uri("/img/game/object/Szorzas.png",UriKind.Relative)),isObject:true),

        };
        public ObservableCollection<GuiGameObjects> ItemsObject => _object;

        ObservableCollection<GuiGameObjects> _decor = new ObservableCollection<GuiGameObjects>()
        {
            ItemDefault,
            new GuiGameObjects("Fal",new BitmapImage(new Uri("/img/game/decor/Fal.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj1",new BitmapImage(new Uri("/img/game/decor/Talaj1.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj2",new BitmapImage(new Uri("/img/game/decor/Talaj2.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj3",new BitmapImage(new Uri("/img/game/decor/Talaj3.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj4",new BitmapImage(new Uri("/img/game/decor/Talaj4.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj5",new BitmapImage(new Uri("/img/game/decor/Talaj5.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj6",new BitmapImage(new Uri("/img/game/decor/Talaj6.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj7",new BitmapImage(new Uri("/img/game/decor/Talaj7.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj8",new BitmapImage(new Uri("/img/game/decor/Talaj8.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj9",new BitmapImage(new Uri("/img/game/decor/Talaj9.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj10",new BitmapImage(new Uri("/img/game/decor/Talaj10.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj11",new BitmapImage(new Uri("/img/game/decor/Talaj11.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj12",new BitmapImage(new Uri("/img/game/decor/Talaj12.png",UriKind.Relative)),isDecor:true),
            new GuiGameObjects("Talaj13",new BitmapImage(new Uri("/img/game/decor/Talaj13.png",UriKind.Relative)),isDecor:true),

        };
        public ObservableCollection<GuiGameObjects> ItemsDecor => _decor;
        #endregion
        #region SizeModel
        private uint size_X = 22;
        public  uint Size_X
        {
            get { return size_X; }
            set { 
                size_X = value == 0 ? 1 : value;
                PropertyChangedHandler(nameof(size_X));
            }
        }
        private uint size_Y = 10;
        public uint Size_Y
        {
            get { return size_Y; }
            set {
                size_Y = value == 0? 1: value;
                PropertyChangedHandler(nameof(size_Y));
            }
        }
        #endregion
        #region CheckedModel
        public bool CBIsChecked { get; set; }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        void PropertyChangedHandler([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
