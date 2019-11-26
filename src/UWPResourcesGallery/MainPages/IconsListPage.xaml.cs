﻿using System.Diagnostics;
using System.Threading.Tasks;
using UWPResourcesGallery.Controls.IconControls;
using UWPResourcesGallery.Model.Icon;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace UWPResourcesGallery.MainPages
{
    /// <summary>
    /// Page displaying list of icons
    /// </summary>
    public sealed partial class IconsListPage : Page
    {
        private readonly IconItemSource source = new IconItemSource();

        public IconsListPage()
        {
            InitializeComponent();

            Loaded += LoadIcons;
        }

        private void LoadIcons(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Task.Run(delegate ()
            {
                _ = Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, () =>
                {
                    ItemsGridView.ItemsSource = source.FilteredItems;
                });
            });
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs args)
        {
            source.Filter((sender as TextBox).Text);
        }

        private void ItemsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var container = ((sender as GridView).ContainerFromItem(e.ClickedItem) as GridViewItem).ContentTemplateRoot as IconItemControl;
            var animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("ForwardConnectedAnimation", container.IconViewPresenter);
            if(animation != null && ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 7))
            {
                animation.Configuration = new BasicConnectedAnimationConfiguration();
            }
            Frame.Navigate(typeof(IconDetailPage), e.ClickedItem as IconItem, new DrillInNavigationTransitionInfo());
        }
    }
}
