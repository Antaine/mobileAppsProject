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
        public static Xamarin.Forms.Keyboard Numeric { get; }
        public Character Character { get; set; }
        string selectedRace;
        string selectedClass;
        string selectedBg;
        string selectedAln;
        int selectedLvl;

        public NewItemPage(Character characterPass)
        {
            InitializeComponent();



            Character = new Character
            {
               
            };
            racePicker.Items.Add("Dragonborn");
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

            lvlPicker.Items.Add("1");
            lvlPicker.Items.Add("2");
            lvlPicker.Items.Add("3");
            lvlPicker.Items.Add("4");
            lvlPicker.Items.Add("5");
            lvlPicker.Items.Add("6");
            lvlPicker.Items.Add("7");
            lvlPicker.Items.Add("8");
            lvlPicker.Items.Add("9");
            lvlPicker.Items.Add("10");
            lvlPicker.Items.Add("11");
            lvlPicker.Items.Add("12");
            lvlPicker.Items.Add("13");
            lvlPicker.Items.Add("14");
            lvlPicker.Items.Add("15");
            lvlPicker.Items.Add("16");
            lvlPicker.Items.Add("17");
            lvlPicker.Items.Add("18");
            lvlPicker.Items.Add("19");
            lvlPicker.Items.Add("20");

            Character.Race = selectedRace;
            Character.Class = selectedClass;
            Character.Bg = selectedBg;
            Character.Align = selectedAln;
            Character.Lvl = selectedLvl;

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {

            Character.Race = selectedRace;
            Character.Class = selectedClass;
            Character.Bg = selectedBg;
            Character.Align = selectedAln;
            Character.Lvl = selectedLvl;
            addRaceBonus(Character);
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

        private void onLvlSelected(object sender, EventArgs args)
        {
            selectedLvl = Int32.Parse(lvlPicker.Items[lvlPicker.SelectedIndex]);

        }

        private int sortRoll(int roll1, int roll2, int roll3,int roll4)
        {
            int d1 = roll1;
            int d2 = roll2;
            int d3 = roll3;
            int temp = roll4;
            int total;
            Console.WriteLine("Roll1 ",roll1," Roll2 ",roll2, "Roll3 ",roll3, "Roll4", roll4);
            if (temp>d1)
            {
                d1 = temp;
                temp = roll1;
            }

            if(temp>d2)
            {
               d2 = temp;
               temp = roll2;
            }

            if(temp>d3)
            {
                d3 = temp;
                
            }

            total = d1 + d2 + d3;
            return total;
        }

        public int randomD6()
        {
            int min = 1;
            int max = 7;
            int d61;
            int d62;
            int d63;
            int temp;
            int total = 0;
            Random random = new Random();

            d61 = random.Next(min,max);
            d62 = random.Next(min, max);
            d63 = random.Next(min, max);
            temp = random.Next(min, max);
            total = sortRoll(d61,d62,d63,temp);

            return total;
        }

        private void rollStats(object sender, EventArgs args)
        {
            Character.Str = randomD6();
            Character.Dex = randomD6();
            Character.Con = randomD6();
            Character.Int = randomD6();
            Character.Wis = randomD6();
            Character.Cha = randomD6();
            addRaceBonus(Character);
        }

        private void addRaceBonus(Character character)
        {
            string race = character.Race;
            if (race == "Dragonborn")
            {
               character.strRace = 2;
               character.chaRace = 1;
            }

          else if (race =="Dwarf")
            {
                character.strRace = 2;
                character.conRace = 2;
            }

            else if (race == "Elf")
            {
                character.dexRace = 2;
                character.wisRace = 1;
            }

            else if (race == "Gnome")
            {
                character.intRace = 2;
                character.conRace = 1;
            }

            else if (race == "Half-Elf")
            {
                character.chaRace = 2;
                character.dexRace = 1;
                character.conRace = 1;
            }

            else if (race == "Half-Orc")
            {
                character.strRace = 2;
                character.conRace = 1;
            }

            else if (race == "Halfling")
            {
                character.dexRace = 2;
                character.chaRace = 1;
            }

            else if (race == "Human")
            {
                character.strRace = 1;
                character.dexRace = 1;
                character.conRace = 1;
                character.intRace = 1;
                character.wisRace = 1;
                character.chaRace = 1;
            }

            else if (race == "Tiefling")
            {
                character.chaRace = 2;
                character.intRace = 1;
            }
        }

    }

}