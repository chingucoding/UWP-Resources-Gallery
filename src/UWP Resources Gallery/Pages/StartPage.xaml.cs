﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPResourcesGallery.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }

        private void NavigateToIconListPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateToIconsListPage();
        }


        private void NavigateToSystemBrushesPage_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NavigateToPageType(typeof(SystemBrushesListPage));
        }
    }
}
