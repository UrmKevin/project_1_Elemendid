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
    public partial class DatePicker_Page : ContentPage
    {
        DatePicker dp;
        Label lbl, describtion, title;

        StackLayout st = new StackLayout();
        public DatePicker_Page()
        {
            dp = new DatePicker
            {
                TextColor = Color.Black,
                Format = "m"
            };
            dp.DateSelected += Dp_DateSelected;
            lbl = new Label
            {
                Text = "",
                FontSize = 14,
                TextColor = Color.DarkGray,
            };
            describtion = new Label
            {
                Text = "",
                FontSize = 12,
                TextColor = Color.DarkGray,
            }; 
            title = new Label
            {
                Text = "",
                FontSize = 14,
                TextColor = Color.Black,
            };
            st = new StackLayout
            {
                Children = { dp, title, lbl },
            };
            Content = st;
        }

        private void Dp_DateSelected(object sender, DateChangedEventArgs e)
        {
            var m = e.NewDate.Month;
            var d = e.NewDate.Day;

            lbl.Text = e.NewDate.ToString();
            if (m == 3 && d >= 21 || m == 4 && d <= 19)
            {
                title.Text = "Kozerog";
                describtion.Text = "describtion";
            }
        }
    }
}