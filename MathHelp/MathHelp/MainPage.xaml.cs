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
            numberOfQuestions = 5;
            Setting.TextColor = Color.Green;

        }

        private void Multiplication_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new Multiplication(difficulty, numberOfQuestions)));
        }

        private void Division_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new Division(difficulty, numberOfQuestions)));
        }

        private void Addition_Clicked(object sender, EventArgs e)
        {
                Navigation.PushModalAsync(new NavigationPage(new Addition(difficulty, numberOfQuestions)));
            
        }

        private void Subtraction_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new Subtraction(difficulty, numberOfQuestions)));
        }

        private void Difficulty_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            difficulty = (int)e.NewValue;
            if (difficulty == 0)
            {
                Setting.Text = "Easy";
                Setting.TextColor = Color.Green;
            }
            else if (difficulty == 1)
            {
                Setting.Text = "Medium";
                Setting.TextColor = Color.Orange;
            }
            else
            {
                Setting.Text = "Hard";
                Setting.TextColor = Color.Red;
            }
        }

        private void Game_length_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            numberOfQuestions = (int)e.NewValue;
            switch (numberOfQuestions)
            {
                case 0:
                    questons.Text = "5";
                    numberOfQuestions = 5;
                    break;
                case 1:
                    questons.Text = "10";
                    numberOfQuestions = 10;
                    break;
                case 2:
                    questons.Text = "20";
                    numberOfQuestions = 20;
                    break;
                default:
                    break;
            }

        }
    }
}
