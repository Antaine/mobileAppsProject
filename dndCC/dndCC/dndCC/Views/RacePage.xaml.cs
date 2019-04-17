using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using dndCC.Models;
using dndCC.Views;
using dndCC.ViewModels;
using Windows.UI.Xaml;

namespace dndCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RacePage : ContentPage
    {
        WikiViewModel viewModel;
        public RacePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new WikiViewModel();

        }



    }
        
}