using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MathHelp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsSelection : ContentPage
	{
        private readonly int gameType;
		public SettingsSelection (int gameType, string pageTitle)
		{
			InitializeComponent ();
            this.gameType = gameType;
            title.Text = pageTitle;
		}

        private void Easy_Clicked(object sender, EventArgs e)
        {
            switch (gameType)
            {
                case 1:
                    Navigation.PushAsync(new Subtraction(0, 8), true);
                    break;
                case 2:
                    Navigation.PushAsync(new Addition(0, 8), true);
                    break;
                case 3:
                    Navigation.PushAsync(new Multiplication(0, 8), true);
                    break;
                case 4:
                    Navigation.PushAsync(new Division(0, 8), true);
                    break;
                default:
                    break;
            }
        }

        private void Medium_Clicked(object sender, EventArgs e)
        {
            switch (gameType)
            {
                case 1:
                    Navigation.PushAsync(new Subtraction(1, 15), true);
                    break;
                case 2:
                    Navigation.PushAsync(new Addition(1, 15), true);
                    break;
                case 3:
                    Navigation.PushAsync(new Multiplication(1, 15), true);
                    break;
                case 4:
                    Navigation.PushAsync(new Division(1, 15), true);
                    break;
                default:
                    break;
            }
        }

        private void Hard_Clicked(object sender, EventArgs e)
        {
            switch (gameType)
            {
                case 1:
                    Navigation.PushAsync(new Subtraction(2, 25), true);
                    break;
                case 2:
                    Navigation.PushAsync(new Addition(2, 25), true);
                    break;
                case 3:
                    Navigation.PushAsync(new Multiplication(2, 25), true);
                    break;
                case 4:
                    Navigation.PushAsync(new Division(2, 25), true);
                    break;
                default:
                    break;
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
            
        }
    }
}