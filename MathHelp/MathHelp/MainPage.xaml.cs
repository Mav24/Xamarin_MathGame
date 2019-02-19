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
        int firstNumber = 0;
        int secondNumber = 0;
        int rightAnswer = 0;
        int wrongAnswer = 0;
        

        public MainPage()
        {
            InitializeComponent();
            RandomNumber();
            
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            var total = firstNumber * secondNumber;
            if(!int.TryParse(answer.Text , out int userAnswer))
            {
                DisplayAlert("Error", "Numeric values only", "Try Again!");
            }
            else if (userAnswer == total)
            {
                rightAnswer++;
                totalRight.TextColor = Color.Green;
                totalRight.Text = $"Correct: {rightAnswer}";
                RandomNumber();
                answer.Text = "";
                answer.Focus();
            }
            else
            {
                wrongAnswer++;
                totalWrong.TextColor = Color.Red;
                totalWrong.Text = $"Wrong: {wrongAnswer}";
                answer.Text = "";
                answer.Focus();
            }

        }

        private void RandomNumber()
        {

            Random num = new Random();
            firstNumber = num.Next(2, 10);
            secondNumber = num.Next(2, 10);

            question.Text = $"{firstNumber} " + "X" + $" {secondNumber}".ToString();
        }
    }
}
