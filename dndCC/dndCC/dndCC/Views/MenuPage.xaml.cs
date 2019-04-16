using dndCC.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace dndCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenu> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenu>
            {
                new HomeMenu {Id = MenuType.DisplayCharacters, Title="Display Characters" },
                new HomeMenu {Id = MenuType.Wiki, Title="Wiki" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenu)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}