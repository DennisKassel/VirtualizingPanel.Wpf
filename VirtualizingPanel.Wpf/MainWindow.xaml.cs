﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VirtualizingPanel.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private Random random = new Random(DateTime.Now.Millisecond);

        public ObservableCollection<string> ItemCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += OnLoaded;
            var length = 30;

            this.ItemCollection = new ObservableCollection<string>(
                Enumerable.Repeat(chars, length).Select((x) => new string(Enumerable.Repeat(chars, 10)
                    .Select(s => s[random.Next(0, chars.Length)]).ToArray())));

            this.OnPropertyChanged(nameof(ItemCollection));
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ScrollToItem((this.ItemCollection.Count / 2) - 1);
        }

        private void ScrollToItem(int index)
        {
            VirtualizingTilePanel panel = this.ItemsControl.FindChild<VirtualizingTilePanel>();
            var content = this.ItemsControl.ItemContainerGenerator.ContainerFromItem(this.ItemCollection[index]);
            ((ContentPresenter)content).SetValue(TextBlock.ForegroundProperty, new SolidColorBrush(Colors.Red));
            panel.MakeVisible((Visual)content, new Rect(new Size(0, 0)));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
