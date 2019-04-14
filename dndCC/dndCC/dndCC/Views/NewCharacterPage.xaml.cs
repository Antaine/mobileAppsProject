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
        string race;
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
            Character.Race = race;


            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            Character.Race = race;
            MessagingCenter.Send(this, "AddCharacter", Character);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void racePickerSelected(object sender, EventArgs args)
        {
            race = racePicker.Items[racePicker.SelectedIndex];
           // DisplayAlert(race,"","");

        }

        //void onRaceSelected(object sender, EventArgs args)
        //{
        //    Picker racePicker = (Picker)sender;
        //    int race = racePicker.SelectedIndex;
        //    racePicker = Items.Clear();
            
        //}
    }

}