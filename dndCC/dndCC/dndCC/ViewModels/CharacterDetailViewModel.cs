using System;

using dndCC.Models;

namespace dndCC.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        public Character Character { get; set; }
        public CharacterDetailViewModel(Character character = null)
        {
            Title = character?.Text;
            Character = character;
        }
    }
}
