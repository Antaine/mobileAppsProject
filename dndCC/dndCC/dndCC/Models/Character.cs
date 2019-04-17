using System;

namespace dndCC.Models
{
    //Character Model
    public class Character
    {
        //User Input
        public string Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Bg { get; set; }
        public string Align { get; set; }
        public int Lvl { get; set; }
        //Display Details on View
        public string displayDetails { get { return Name + " the " + Race + " " + Class; } }

        //Stats
        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }
        //Race Bonus
        public int strRace { get; set; }
        public int dexRace { get; set; }
        public int conRace { get; set; }
        public int intRace { get; set; }
        public int wisRace { get; set; }
        public int chaRace { get; set; }
    }
}