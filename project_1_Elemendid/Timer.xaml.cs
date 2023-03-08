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
    public partial class Timer : ContentPage
    {
        bool OnOff = true;
        public Timer()
        {
            InitializeComponent();
            stopbtn.Clicked += Stopbtn_Clicked;
            NaitaAeg();
        }

        private void Stopbtn_Clicked(object sender, EventArgs e)
        {
            if (OnOff == true)
            {
                OnOff = false;
                ongoing.Text = "Timer stopped";
            }
            else if (OnOff == false)
            {
                OnOff = true;
                ongoing.Text = "Timer is going";
                NaitaAeg();
            }
        }

        private async void NaitaAeg()
        {
            while (OnOff)
            {
                lbl.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            NaitaAeg();
            lbl.TextColor = Color.LightGray;
            await Task.Delay(140); //0.14 of one second
            lbl.TextColor = Color.White;
        }

        private async void tagasibtn_Clicked_1(object sender, EventArgs e)
        {

            await Navigation.PopAsync();
        }
    }
}