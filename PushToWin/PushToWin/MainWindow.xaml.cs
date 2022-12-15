﻿using PushToWin.Pages;
using PushToWin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PushToWin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindowModel context = new MainWindowModel();
        public MainWindow()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                switch (context.VisibilityActiveName)
                {
                    case "LevelSelector": //Back to Start
                        context.MakeVisible("Start");
                        break;
                    case "LevelEditorSelect": //Back to Start
                        context.MakeVisible("Start");
                        break;
                    case "LevelEditor": //Level Editor Esc
                        context.MakeVisible("LevelEditorEsc");
                        break;
                    case "LevelEditorEsc": // To level editor
                        context.MakeVisible("LevelEditor");
                        break;
                    case "GameWindow": //Game Window Esc
                        context.MakeVisible("GameWindowEsc");
                        break;
                    case "GameWindowEsc": // To Game window
                        context.MakeVisible("GameWindow");
                        break;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = context;
            context.MakeVisible("LevelEditor");
        }
    }
}
