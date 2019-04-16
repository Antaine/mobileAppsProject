using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using dndCC.Models;
using dndCC.Views;
using dndCC.ViewModels;
using Windows.UI.Xaml;

namespace dndCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Wiki : ContentPage
    {
        WikiViewModel viewModel;
        public Wiki()
        {
            InitializeComponent();
            BindingContext = viewModel = new WikiViewModel();
        }

        async void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var character = args.SelectedItem as Character;
            if (character == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new CharacterDetailViewModel(character)));

            // Manually deselect item.
            //Chwck
          //  CharactersListView.SelectedItem = null;
        }
        //async void AddCharacter_Clicked(object sender, EventArgs e)
        //{
        //    //Check
        //    await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        //}

        private async void OnRaceClicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new NavigationPage(new RacePage()));
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Characters.Count == 0)
                viewModel.LoadStatsCommand.Execute(null);
        }

        private void racesClicked()
        {

        }
    }
}