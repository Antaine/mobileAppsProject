using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using dndCC.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;


namespace dndCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {

        public Character Character { get; set; }
        //   public ObservableCollection<FontFamily> Fonts { get => fonts; set => fonts = value; }
        string selectedRace;
        string selectedClass;
        string selectedBg;
        string selectedAln;

        public NewItemPage()
        {
            InitializeComponent();



            Character = new Character
            {
               
            };
            racePicker.Items.Add("DragonBorn");
            racePicker.Items.Add("Dwarf");
            racePicker.Items.Add("Elf");
            racePicker.Items.Add("Gnome");
            racePicker.Items.Add("Half-Elf");
            racePicker.Items.Add("Half-Orc");
            racePicker.Items.Add("Halfling");
            racePicker.Items.Add("Human");
            racePicker.Items.Add("Tiefling");

            classPicker.Items.Add("Barbarian");
            classPicker.Items.Add("Bard");
            classPicker.Items.Add("Cleric");
            classPicker.Items.Add("Druid");
            classPicker.Items.Add("Fighter");
            classPicker.Items.Add("Monk");
            classPicker.Items.Add("Paladin");
            classPicker.Items.Add("Ranger");
            classPicker.Items.Add("Rogue");
            classPicker.Items.Add("Sorcerer");
            classPicker.Items.Add("Warlock");
            classPicker.Items.Add("Wizard");

            bgPicker.Items.Add("Acolyte");
            bgPicker.Items.Add("Charlatan");
            bgPicker.Items.Add("Criminal/Spy");
            bgPicker.Items.Add("Entertainer");
            bgPicker.Items.Add("Folk Hero");
            bgPicker.Items.Add("Gladiator");
            bgPicker.Items.Add("Guild Artisan/Merchant");
            bgPicker.Items.Add("Hermit");
            bgPicker.Items.Add("Knight");
            bgPicker.Items.Add("Noble");
            bgPicker.Items.Add("Outlander");
            bgPicker.Items.Add("Pirate");
            bgPicker.Items.Add("Sage");
            bgPicker.Items.Add("Urchin");

            alnPicker.Items.Add("Lawful Good");
            alnPicker.Items.Add("Lawful Neutral");
            alnPicker.Items.Add("Lawful Evil");
            alnPicker.Items.Add("Neutral Good");
            alnPicker.Items.Add("True Neutral");
            alnPicker.Items.Add("Neutral Evil");
            alnPicker.Items.Add("Chaotic Good");
            alnPicker.Items.Add("Chaotic Neutral");
            alnPicker.Items.Add("Chaotic Evil");

            Character.Race = selectedRace;
            Character.Class = selectedClass;
            Character.Bg = selectedBg;
            Character.Align = selectedAln;

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Character.Race = selectedRace;
            Character.Class = selectedClass;
            Character.Bg = selectedBg;
            Character.Align = selectedAln;
            MessagingCenter.Send(this, "AddCharacter", Character);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void onRaceSelected(object sender, EventArgs args)
        {
            selectedRace = racePicker.Items[racePicker.SelectedIndex];

        }

        private void onClassSelected(object sender, EventArgs args)
        {
            selectedClass = classPicker.Items[classPicker.SelectedIndex];

        }

        private void onBgSelected(object sender, EventArgs args)
        {
            selectedBg = bgPicker.Items[bgPicker.SelectedIndex];

        }

        private void onAlnSelected(object sender, EventArgs args)
        {
            selectedAln = alnPicker.Items[alnPicker.SelectedIndex];

        }

        //}
    }

}