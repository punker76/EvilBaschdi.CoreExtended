﻿using System.Reflection;
using System.Windows;
using EvilBaschdi.Core.Security;
using EvilBaschdi.CoreExtended.TestUi.ViewModel;
using MahApps.Metro.Controls;

namespace EvilBaschdi.CoreExtended.TestUi
{
    /// <inheritdoc cref="MetroWindow" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly MainWindowViewModel _mainWindowViewModel;

        /// <summary>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //MessageBox.Show(VersionHelper.GetWindowsClientVersion());
            IEncryption encryption = new Encryption();

            _mainWindowViewModel = new MainWindowViewModel(encryption);
            Loaded += MainWindowLoaded;

            var filePath = Assembly.GetEntryAssembly()?.Location;
            if (filePath != null)
            {
                TestTaskbarIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(filePath);
            }


            //var contextMenu = new ContextMenu();

            //foreach (string accentItem in applicationStyleViewModelCodeBehind.StyleAccents)
            //{
            //    var menuItem = new MenuItem
            //    {
            //        Header = accentItem
            //    };

            //    contextMenu.Items.Add(menuItem);
            //}


            //TestTaskbarIcon.ContextMenu = contextMenu;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = _mainWindowViewModel;
        }
    }
}