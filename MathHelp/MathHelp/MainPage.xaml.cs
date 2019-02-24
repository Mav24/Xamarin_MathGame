using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MathHelp
{
    public partial class MainPage : ContentPage
    {
        private int difficulty;
        private int numberOfQuestions;
        public MainPage()
        {
            InitializeComponent();
            
            
        }

        private void Multiplication_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new Multiplication(difficulty, numberOfQuestions)));
        }

        private void Division_Clicked(object sender, EventArgs e)
        {

        }

        private void Addition_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new Addition(difficulty, numberOfQuestions)));
        }

        private void Subtraction_Clicked(object sender, EventArgs e)
        {

        }

        private void Difficulty_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            difficulty = (int)e.NewValue;
            if (difficulty == 0)
            {
                Setting.Text = "Easy";
            }
            else if (difficulty == 1)
            {
                Setting.Text = "Medium";
            }
            else
            {
                Setting.Text = "Hard";
            }
        }

        private void Game_length_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            numberOfQuestions = (int)e.NewValue;
            
        }
    }
}
