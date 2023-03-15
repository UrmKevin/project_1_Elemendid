using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace project_1_Elemendid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGB_Page : ContentPage
    {
        List<Xamarin.Forms.Slider> sliders = new List<Xamarin.Forms.Slider>() { new Xamarin.Forms.Slider(), new Xamarin.Forms.Slider(), new Xamarin.Forms.Slider() };
        List<string> names = new List<string> { "Red", "Green", "Blue"};
        List<Xamarin.Forms.Slider> slidersonly = new List<Xamarin.Forms.Slider> { };
        // List of objects
        List<Object> objects = new List<Object> { };
        Xamarin.Forms.BoxView box;
        Random rnd = new Random();
        Button rndColor, rainbow;
        public RGB_Page()
        {
            // Title name
            Title = "RGB";

            // Creating Button
            rndColor = new Button
            {
                Text = "Random Color",
                BackgroundColor = Color.DarkGray,
                TextColor = Color.White,
            };
            rndColor.Clicked += RndColor_Clicked;
            rainbow = new Button
            {
                Text = "Rainbow",
                BackgroundColor = Color.DarkGray,
                TextColor = Color.White,
            };
            rainbow.Clicked += Glow_Clicked;
            // Creating BoxView
            box = new Xamarin.Forms.BoxView
            {
                Color = Color.FromRgb(0, 0, 0),
                WidthRequest = 400,
                HeightRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            objects.Add(box);
            // creating slider and adding them to a list
            for (int i = 0; i < sliders.Count; i++)
            {
                string min = "#000000";
                if (names[i]=="Red")
                {
                    min = "#FF0000";
                }
                else if (names[i] == "Green")
                {
                    min = "#00FF00";
                }
                else if (names[i] == "Blue")
                {
                    min = "#0000FF";
                }
                Xamarin.Forms.Slider slider = new Xamarin.Forms.Slider
                {
                    TabIndex = i,
                    Minimum = 0,
                    Maximum = 255,
                    Value = 0,
                    ThumbColor = Color.FromHex(min),
                    MinimumTrackColor = Color.FromHex(min),
                    MaximumTrackColor = Color.LightGray,
                };
                slider.ValueChanged += Slider_ValueChanged;
                objects.Add(slider); slidersonly.Add(slider);
            }
            objects.Add(rainbow);
            objects.Add(rndColor);

            // AbsoluteLayout
            AbsoluteLayout abs = new AbsoluteLayout();
            double y = 0.5;
            int forbox = 0;
            foreach (var item in objects)
            {
                y += 0.05;
                forbox += 1;
                if (forbox == 1)
                {
                    AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0, 0, 400, 400));
                    AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                }
                else
                {
                    AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1, y, 400, 25));
                    AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                }
                if (forbox == 5)
                {
                    AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1, 0.9, 400, 50));
                    AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                }
                if (forbox == 6)
                {
                    AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1, 1, 400, 50));
                    AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                }
                abs.Children.Add((View)item);
            }
            Content = abs;
        }
        // For FromRgb
        int red;
        int green;
        int blue;
        // Make BoxView change colors randomly
        private async void Glow_Clicked(object sender, EventArgs e)
        {
            red = rnd.Next(0, 255);
            green = rnd.Next(0, 255);
            blue = rnd.Next(0, 255);
            Color rndColor = Color.FromRgb(red, green, blue);
            while (true)
            {
                red += 5;
                green += 5;
                blue += 5;
                box.Color = rndColor;
                await Task.Delay(50);
                if (box.Color == Color.FromRgb(255,255,255))
                {
                    break;
                }
            }
        }
        // Random color
        private async void RndColor_Clicked(object sender, EventArgs e)
        {
            red = rnd.Next(0, 255);
            slidersonly[0].Value = red;
            green = rnd.Next(0, 255);
            slidersonly[1].Value = green;
            blue = rnd.Next(0, 255);
            slidersonly[2].Value = blue;
            box.Color = Color.FromRgb(red, green, blue);
        }


        // Changing color of a box by using FromRgb() for sliders
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var slider = (Xamarin.Forms.Slider)sender;
            if (slider.ThumbColor == Color.FromHex("#FF0000"))
            {
                red = (int)e.NewValue;
            }
            else if (slider.ThumbColor == Color.FromHex("#00FF00"))
            {
                green = (int)e.NewValue;
            }
            else if (slider.ThumbColor == Color.FromHex("#0000FF"))
            {
                blue = (int)e.NewValue;
            }
            box.Color = Color.FromRgb(red, green, blue);
        }
    }
}