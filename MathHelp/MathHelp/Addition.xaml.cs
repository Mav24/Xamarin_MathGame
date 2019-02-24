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
	public partial class Addition : ContentPage
	{
        private int difficulty;
        private int numberOfGames;
		public Addition (int difficulty, int numberOfGames)
		{
            this.difficulty = difficulty;
            this.numberOfGames = numberOfGames;
			InitializeComponent ();
		}

        private void Exit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {

        }
    }
}