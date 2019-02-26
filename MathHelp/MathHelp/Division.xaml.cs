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
	public partial class Division : ContentPage
	{
        private int difficulty;
        private int numberOfQuestions;
        int firstNumber = 0;
        int secondNumber = 0;
        int total = 0;
        int rightAnswer = 0;
        int wrongAnswer = 0;
        int gameCount = 1;
        List<string> wrongQuestions = new List<string>();

        Random num;

        public Division(int difficulty, int numberOfQuestions)
        {
            this.difficulty = difficulty;
            this.numberOfQuestions = numberOfQuestions;
            InitializeComponent();
            RandomNumber();
        }

        public Division ()
		{
			InitializeComponent ();
		}

        private void Submit_Clicked(object sender, EventArgs e)
        {

            if (!int.TryParse(answer.Text, out int userAnswer))
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
                gameCount++;
            }
            else
            {
                wrongQuestions.Add(question.Text);
                wrongAnswer++;
                totalWrong.TextColor = Color.Red;
                totalWrong.Text = $"Wrong: {wrongAnswer}";
                RandomNumber();
                answer.Text = "";
                answer.Focus();
                gameCount++;
            }
        }


        async void RandomNumber()
        {
            string message = "Questions you need to practice:\n";
            num = new Random();
            if (numberOfQuestions == 0)
            {
                numberOfQuestions = 5;
            }
            if (gameCount == numberOfQuestions)
            {
                foreach (var wrongAnswer in wrongQuestions)
                {
                    message += wrongAnswer + "\n";
                }
                await DisplayAlert("End of Game", $"Correct: {rightAnswer}\n" + $"Wrong: {wrongAnswer}\n" +
                    $"{message}", "OK");
                totalRight.Text = "";
                totalWrong.Text = "";
                await Navigation.PopModalAsync();
            }
            else
            {
                switch (difficulty)
                {
                    case 0:
                        firstNumber = num.Next(1, 4);
                        secondNumber = num.Next(1, 4);
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} " + "/" + $" {firstNumber}".ToString();
                            total = secondNumber / firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} " + "/" + $" {secondNumber}".ToString();
                            total = firstNumber / secondNumber;
                        }
                        break;
                    case 1:
                        firstNumber = num.Next(2, 9);
                        secondNumber = num.Next(2, 9);
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} " + "/" + $" {firstNumber}".ToString();
                            total = secondNumber / firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} " + "/" + $" {secondNumber}".ToString();
                            total = firstNumber / secondNumber;
                        }
                        break;
                    case 2:

                        firstNumber = num.Next(2, 13);
                        secondNumber = num.Next(2, 13);
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} " + "/" + $" {firstNumber}".ToString();
                            total = secondNumber / firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} " + "/" + $" {secondNumber}".ToString();
                            total = firstNumber / secondNumber;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}