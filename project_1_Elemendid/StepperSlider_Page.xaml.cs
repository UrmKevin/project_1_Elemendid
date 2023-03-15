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
    public partial class StepperSlider_Page : ContentPage
    {
        Stepper stp;
        Slider sld;
        Label lbl;
        public StepperSlider_Page()
        {
            stp = new Stepper
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                Minimum = 0,
                Maximum = 100,
                Value = 14,
                Increment = 2
            };
            stp.ValueChanged += Stp_ValueChanged;
            lbl = new Label
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Text = "Change font size",
                FontSize = stp.Value
            };
            sld = new Slider
            {
                Minimum = stp.Minimum,
                Maximum = stp.Maximum,
                Value = stp.Value,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black
            };
            sld.ValueChanged += Stp_ValueChanged; ;

            // StackLayout + Content
            List<Object> objects = new List<object> { lbl, sld, stp };
            AbsoluteLayout abs = new AbsoluteLayout();
            double y = 0;
            foreach (var item in objects)
            {
                y += 0.2;
                AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.1, y, 300, 150));
                AbsoluteLayout.SetLayoutFlags((BindableObject)item,AbsoluteLayoutFlags.PositionProportional);
                abs.Children.Add((View)item);
            }
            Content = abs;
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == sld)
            {
                stp.Value = sld.Value;
            }
            else if (sender == stp)
            {
                sld.Value = stp.Value;
            }
            
            lbl.FontSize = e.NewValue;
        }
    }
}