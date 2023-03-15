using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project_1_Elemendid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start_Page : ContentPage
    {
        List<ContentPage> contentPages = new List<ContentPage>() { new Text_Page(), new Timer(), new Box_Page(), new StepperSlider_Page(), new RGB_Page() };
        List<string> text = new List<string> { "Text Page", "Timer", "Box Page", "Stepper and Slider", "RGB" };
        public Start_Page()
        {
            
            StackLayout st = new StackLayout 
            { 
                Orientation= StackOrientation.Vertical,
                BackgroundColor = Color.White
            };
            for (int i = 0; i < contentPages.Count; i++)
            {
                Button button = new Button
                {
                    Text = text[i],
                    TabIndex = i,
                    BackgroundColor = Color.DarkGray,
                    TextColor = Color.White,
                };
                button.Clicked += NavigationFunction;
                st.Children.Add(button);
            }
            Content = st;
        }

        private async void NavigationFunction(object sender, EventArgs e)
        {
            Button b = (Button)sender; // Button b = sender as Button;
            await Navigation.PushAsync(contentPages[b.TabIndex]);
        }
    }
}