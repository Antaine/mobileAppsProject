using System;

namespace dndCC.Models
{
    public class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string Bg { get; set; }
        public string Align { get; set; }
        public int Lvl { get; set; }
        //Display Details
        public string displayDetails { get { return Name + " the " + Race + " " + Class; } }

        public int Str { get; set; }
        public int Dex { get; set; }
        public int Con { get; set; }
        public int Int { get; set; }
        public int Wis { get; set; }
        public int Cha { get; set; }

    }
}