using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project_1_Elemendid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Box_Page : ContentPage
    {
        Button Tagasibtn;
        BoxView box;
        public Box_Page()
        {
            Tagasibtn = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.DarkGray,
                TextColor = Color.White
            };
            Tagasibtn.Clicked += Tagasibtn_Clicked;
            box = new BoxView
            {
                Color = Color.Chartreuse,
                CornerRadius = 10,
                WidthRequest = 20,
                HeightRequest = 30,
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.Center
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap);
            Content = new StackLayout
            {
                Orientation= StackOrientation.Horizontal,
                Children = {box}
            };
            //Animation();
        }
        Random rnd;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
            box.WidthRequest = box.WidthRequest + 5;
            box.HeightRequest = box.HeightRequest + 7;
            box.Rotation += 10;
            try
            {
                Vibration.Vibrate();
                var a = TimeSpan.FromSeconds(0.5);
                Vibration.Vibrate(a);
            }
            catch (Exception)
            {

            }
        }

        private async void Tagasibtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void Animation()
        {
            while (true)
            {
                box.WidthRequest =  50;
                box.HeightRequest =  70;

                for (int i = 0; i < 20; i++)
                {
                    box.HeightRequest = box.HeightRequest - 7;
                    box.WidthRequest += 20;
                    await Task.Delay(10);
                }
                for (int f = 0; f < 20; f++)
                {
                    box.HeightRequest = box.HeightRequest + 7;
                    box.WidthRequest = box.WidthRequest - 20;
                    await Task.Delay(10);
                }
                for (int f = 0; f < 20; f++)
                {
                    box.WidthRequest = box.WidthRequest + 20;
                    await Task.Delay(10);
                }
                for (int f = 0; f < 20; f++)
                {
                    box.WidthRequest = box.WidthRequest - 20;
                    await Task.Delay(10);
                }
            }
        }
    }
}