using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using dndCC.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;


namespace dndCC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {

        public Character Character { get; set; }
     //   public ObservableCollection<FontFamily> Fonts { get => fonts; set => fonts = value; }

        public NewItemPage()
        {
            InitializeComponent();


            //Label header = new Label
            //{
            //    Text = "Picker",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center
            //};

            //Picker picker = new Picker
            //{
            //    Title = "Color",
            //    VerticalOptions = LayoutOptions.CenterAndExpand
            //};

            //foreach (string colorName in nameToColor.Keys)
            //{
            //    picker.Items.Add(colorName);
            //}

            //BoxView boxView = new BoxView
            //{
            //    WidthRequest = 150,
            //    HeightRequest = 150,
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.CenterAndExpand
            //};

            /* picker.SelectedIndexChanged += (sender, args) = &gt;
             {
                 if (picker.SelectedIndex == -1)
                 {
                     boxView.Color = Color.Default;
                 }
                 else
                 {
                     string colorName = picker.Items[picker.SelectedIndex];
                     boxView.Color = nameToColor[colorName];
                 }
             };*/

            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //this.Content = new StackLayout
            //{
            //    Children =
            //{
            //    header,
            //    picker,
            //    boxView
            //}
            //};

            Character = new Character
            {

            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddCharacter", Character);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }

}