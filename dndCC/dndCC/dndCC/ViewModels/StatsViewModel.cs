using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using dndCC.Models;
using dndCC.Views;


namespace dndCC.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        public ObservableCollection<Character> Characters { get; set; }
        public Command LoadStatsCommand { get; set; }

        public StatsViewModel()
        {
            Title = "Display Stats";
            Characters = new ObservableCollection<Character>();
            LoadStatsCommand = new Command(async () => await ExecuteLoadStatsCommand());

            //Change to NewCharacterPage
            MessagingCenter.Subscribe<NewItemPage, Character>(this, "AddCharacter", async (obj, character) =>
            {
                var newCharacter = character as Character;
                Characters.Add(newCharacter);
                await DataStore.AddCharacterAsync(newCharacter);
            });

        }

        async Task ExecuteLoadStatsCommand()
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