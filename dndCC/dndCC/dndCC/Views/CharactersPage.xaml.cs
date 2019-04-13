using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using dndCC.Models;
using dndCC.Views;
using dndCC.ViewModels;

namespace dndCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        CharactersViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CharactersViewModel();
        }

        async void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var character = args.SelectedItem as Character;
            if (character == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new CharacterDetailViewModel(character)));

            // Manually deselect item.
            //Chwck
            CharactersListView.SelectedItem = null;
        }

        async void AddCharacter_Clicked(object sender, EventArgs e)
        {
            //Check
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Characters.Count == 0)
                viewModel.LoadCharactersCommand.Execute(null);
        }
    }
}