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
using static System.Net.WebRequestMethods;

namespace project_1_Elemendid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RGB_Page : ContentPage
    {
        List<Xamarin.Forms.Slider> sliders = new List<Xamarin.Forms.Slider> { new Xamarin.Forms.Slider(), new Xamarin.Forms.Slider(), new Xamarin.Forms.Slider(), new Xamarin.Forms.Slider() };
        List<string> names = new List<string> { "Red", "Green", "Blue", "Round"};
        List<Xamarin.Forms.Slider> slidersonly = new List<Xamarin.Forms.Slider> { };
        List<Label> labelsonly = new List<Label> { };
        List<Object> objects = new List<Object> { };
        AbsoluteLayout abs = new AbsoluteLayout();
        Xamarin.Forms.BoxView box;
        Random rnd = new Random();
        Button rndColor;
        Stepper changeSize;
        double bx = 0, by = 0;
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
            changeSize = new Stepper
            {
                Minimum = 0,
                Maximum = 400,
                Value = 400,
                Increment = 100,
                WidthRequest = 100,
                HeightRequest = 50,
            };
            changeSize.ValueChanged += ChangeSize_ValueChanged;
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
            int counter = 0;
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
                else if (names[i] == "Round")
                {
                    min = "#000000";
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
                if (names[i] == "Round")
                {
                    slider.Minimum = 1;
                    slider.Maximum = 200;
                    slider.ThumbColor = Color.Black;
                    slider.MinimumTrackColor = Color.Black;
                    slider.ValueChanged += Slider_ValueChanged1;
                }
                else
                {
                    slider.ValueChanged += Slider_ValueChanged;
                }
                objects.Add(slider);
                slidersonly.Add(slider);
                if (counter < 3)
                {
                    counter++;
                    Label label = new Label
                    {
                        WidthRequest = 350,
                        HorizontalOptions = LayoutOptions.Center,
                    };
                    if (counter == 1)
                    {
                        label.Text = "R: 0";
                    }
                    else if (counter == 2)
                    {
                        label.Text = "G: 0";
                    }
                    else
                    {
                        label.Text = "B: 0";
                    }
                    objects.Add(label);
                    labelsonly.Add(label);
                }
            }
            objects.Add(changeSize);
            objects.Add(rndColor);

            double y = 0.5;
            int forbox = 0;
            foreach (var item in objects)
            {
                y += 0.04;
                forbox += 1;
                if (forbox == 1)
                {
                    AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(bx, by, 400, 400));
                    AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                }
                else
                {
                    AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1, y, 400, 20));
                    AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                }
                if (forbox == 9)
                {
                    AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1, 0.9, 400, 50));
                    AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                }
                if (forbox == 10)
                {
                    AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1, 1, 400, 50));
                    AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                }
                abs.Children.Add((View)item);
            }
            Content = abs;
        }

        private void ChangeSize_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double newValue = e.NewValue;

            box.HeightRequest = newValue;
            box.WidthRequest = newValue;

            if (newValue == 400)
            {
                bx = 0;
                by = 0;
            }
            else if (newValue == 300)
            {
                bx = 0.5;
                by = 0.1;
            }
            else if (newValue == 200)
            {
                bx = 0.5;
                by = 0.18;
            }
            else if (newValue == 100)
            {
                bx = 0.5;
                by = 0.25;
            }

            AbsoluteLayout.SetLayoutBounds(box, new Rectangle(bx, by, box.HeightRequest, box.WidthRequest));
        }

        private void Slider_ValueChanged1(object sender, ValueChangedEventArgs e)
        {
            var slider = (Xamarin.Forms.Slider)sender;
            box.CornerRadius = slider.Value;
        }

        // For FromRgb
        int red;
        int green;
        int blue;
        //double redSlider;
        Color boxColor;
        // Random color
        private void RndColor_Clicked(object sender, EventArgs e)
        {
            red = rnd.Next(0, 255);
            slidersonly[0].Value = red;
            //while (redSlider < red)
            //{
            //    redSlider += 5;    
            //    slidersonly[0].Value += 5;
            //}
            green = rnd.Next(0, 255);
            slidersonly[1].Value = green;
            blue = rnd.Next(0, 255);
            slidersonly[2].Value = blue;
            boxColor = Color.FromRgb(red, green, blue);
            box.Color = boxColor;

            sliders[3].ThumbColor = boxColor;
            sliders[3].MinimumTrackColor = boxColor;
        }

        // Changing color of a box by using FromRgb() for sliders
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var slider = (Xamarin.Forms.Slider)sender;
            if (slider.ThumbColor == Color.FromHex("#FF0000"))
            {
                red = (int)e.NewValue;
                labelsonly[0].Text = "R: " + red;
            }
            else if (slider.ThumbColor == Color.FromHex("#00FF00"))
            {
                green = (int)e.NewValue;
                labelsonly[1].Text = "G: " + green;
            }
            else if (slider.ThumbColor == Color.FromHex("#0000FF"))
            {
                blue = (int)e.NewValue;
                labelsonly[2].Text = "B: " + blue;
            }
            box.Color = Color.FromRgb(red, green, blue);
        }
    }
}