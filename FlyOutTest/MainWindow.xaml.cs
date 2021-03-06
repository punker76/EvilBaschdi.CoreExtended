﻿using System.Reflection;
using EvilBaschdi.Core.Extensions;
using EvilBaschdi.CoreExtended.Application;
using EvilBaschdi.CoreExtended.Wpf;
using FlyOutTest.Properties;
using MahApps.Metro.Controls;

namespace FlyOutTest
{
    /// <inheritdoc cref="MetroWindow" />
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            IApplicationSettingsBaseHelper applicationSettingsBaseHelper = new ApplicationSettingsBaseHelper(Settings.Default);
            ISettings coreSettings = new CoreSettings(applicationSettingsBaseHelper);
            IThemeManagerHelper themeManagerHelper = new ThemeManagerHelper();
            IMetroStyle style = new MetroStyle(this, coreSettings, themeManagerHelper);
            IFlyout flyout = new CustomFlyout(this, style, Assembly.GetExecutingAssembly().GetLinkerTime());
            flyout.Run();
        }
    }
}