using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using dndCC.Models;
using dndCC.Views;

namespace dndCC.ViewModels
{
    public class CharactersViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }
        public Command LoadCharactersCommand { get; set; }

        public CharactersViewModel()
        {
            Title = "Browse";
            Characters = new ObservableCollection<Character>();
            LoadCharactersCommand = new Command(async () => await ExecuteLoadCharactersCommand());

            //Change to NewCharacterPage
            MessagingCenter.Subscribe<NewItemPage, Character>(this, "AddCharacter", async (obj, character) =>
            {
                var newCharacter = character as Character;
                Characters.Add(newCharacter);
                await DataStore.AddCharacterAsync(newCharacter);
            });
        }

        async Task ExecuteLoadCharactersCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Characters.Clear();
                var characters = await DataStore.GetCharactersAsync(true);
                foreach (var character in characters)
                {
                    Characters.Add(character);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}