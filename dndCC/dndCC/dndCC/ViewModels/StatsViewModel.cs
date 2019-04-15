using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace dndCC.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        public StatsViewModel()
        {
            Title = "Stats";

        }

        public ICommand OpenWebCommand { get; }
    }
}