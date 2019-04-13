using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using dndCC.Models;
using dndCC.ViewModels;

namespace dndCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        CharacterDetailViewModel viewModel;

        public ItemDetailPage(CharacterDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var character = new Character
            {
                Text = "Character 1",
                Description = "This is an Character description."
            };

            viewModel = new CharacterDetailViewModel(character);
            BindingContext = viewModel;
        }
    }
}