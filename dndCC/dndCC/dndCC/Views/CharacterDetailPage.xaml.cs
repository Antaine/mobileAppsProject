using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using dndCC.Models;
using dndCC.ViewModels;

namespace dndCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        CharacterDetailViewModel viewModel;

        public ItemDetailPage(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var character = new Character
            {
                Name = "Character Name",
                Class = "Bard"
            };
            //addRaceBonus(character);
            viewModel = new CharacterDetailViewModel(character);
            BindingContext = viewModel;
        }

        private async void statsClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Wiki());
        }

        //private void addRaceBonus(Character character)
        //{
        //    string race = character.Race;
        //    if (race.Equals("Dragonborn"))
        //    {
        //        character.strRace = 2;
        //        character.chaRace = 1;
        //    }

        //    else if (race.Equals("Dwarf"))
        //    {
        //        character.strRace = 2;
        //        character.conRace = 2;
        //    }

        //    else if (race.Equals("Elf"))
        //    {
        //        character.dexRace = 2;
        //        character.wisRace = 1;
        //    }

        //    else if (race.Equals("Gnome"))
        //    {
        //        character.intRace = 2;
        //        character.conRace = 1;
        //    }

        //    else if (race.Equals("Half-Elf"))
        //    {
        //        character.chaRace = 2;
        //        character.dexRace = 1;
        //        character.conRace = 1;
        //    }

        //    else if (race.Equals("Half-Orc"))
        //    {
        //        character.strRace = 2;
        //        character.conRace = 1;
        //    }

        //    else if (race.Equals("Halfling"))
        //    {
        //        character.dexRace = 2;
        //        character.chaRace = 1;
        //    }

        //    else if (race.Equals("Human"))
        //    {
        //        character.strRace = 1;
        //        character.dexRace = 1;
        //        character.conRace = 1;
        //        character.intRace = 1;
        //        character.wisRace = 1;
        //        character.chaRace = 1;
        //    }

        //    else if (race.Equals("Tiefling"))
        //    {
        //        character.chaRace = 2;
        //        character.intRace = 1;
        //    }
        //}
    }
}