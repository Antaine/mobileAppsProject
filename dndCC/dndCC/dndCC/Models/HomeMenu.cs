using System;
using System.Collections.Generic;
using System.Text;

namespace dndCC.Models
{
    //Menu
    public enum MenuType
    {
        DisplayCharacters,
        Wiki
    }
    public class HomeMenu
    {
        public MenuType Id { get; set; }

        public string Title { get; set; }
    }
}
