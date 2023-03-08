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
        public Start_Page()
        {
            Button Textbtn = new Button
            {
                Text= "Text Page",
                BackgroundColor= Color.DarkGray,
                TextColor= Color.White,
            };
            Button Timerbtn = new Button
            {
                Text = "Timer Page",
                BackgroundColor = Color.DarkGray,
                TextColor = Color.White,
            };
            Button Boxbtn = new Button
            {
                Text = "Box Page",
                BackgroundColor = Color.DarkGray,
                TextColor = Color.White,
            };
            Textbtn.Clicked += Textbtn_Clicked;
            Timerbtn.Clicked += Timerbtn_Clicked;
            Boxbtn.Clicked += Boxbtn_Clicked;
            StackLayout st=new StackLayout 
            { 
                Orientation= StackOrientation.Vertical,
                BackgroundColor = Color.White,
                Children=
                {
                    Textbtn,Timerbtn,Boxbtn
                }
            };
            Content = st;
        }

        private async void Boxbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Box_Page());
        }

        private async void Timerbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Timer());
        }

        private async void Textbtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Text_Page());
        }
    }
}