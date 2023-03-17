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
    public partial class Text_Page : ContentPage
    {
        Editor editor;
        Label lbl;
        Button Tagasibtn; 
        public Text_Page()
        {
            Tagasibtn = new Button
            {
                Text = "Tagasi",
                BackgroundColor = Color.DarkGray,
                TextColor = Color.White
            };
            Tagasibtn.Clicked += Tagasibtn_Clicked;
            editor = new Editor
            {
                Placeholder = "Type anything",
                PlaceholderColor = Color.DarkGray,
                BackgroundColor = Color.LightGray,
                TextColor = Color.Black,
                AutoSize = EditorAutoSizeOption.TextChanges
            };
            editor.TextChanged += Editor_TextChanged;
            lbl = new Label
            {
                Text = "Write an essay",
                BackgroundColor= Color.LightGray,
                TextColor= Color.Black,
            };



            Content = new StackLayout
            {
                Children = { Tagasibtn, lbl, editor }
            };
        }
        int i;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lbl.Text = editor.Text;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            if (key == 'A' || key == 'a')
            {
                i++;
                Tagasibtn.Text = key.ToString() + ": " + i.ToString();
            }
        }

        private async void Tagasibtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}