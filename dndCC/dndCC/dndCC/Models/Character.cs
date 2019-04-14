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
        //Display Details
        public string displayDetails { get { return Name + " the " + Race + " " + Class; } }
        
    }
}