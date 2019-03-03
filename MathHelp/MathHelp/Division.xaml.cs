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
                totalRight.Text = "";
                totalWrong.Text = "";
                await DisplayAlert("End of Game", $"Correct: {rightAnswer}\n" + $"Wrong: {wrongAnswer}\n" +
                    $"{message}", "OK");
                
                await Navigation.PopModalAsync();
            }
            else
            {
                switch (difficulty)
                {
                    case 0:
                        firstNumber = num.Next(1, 10);
                        secondNumber = num.Next(1, 10);
                        answer.Focus();
                        if (firstNumber % secondNumber == 0)
                        {
                            total = firstNumber / secondNumber;
                            question.Text = $"{firstNumber} " + "/" + $" {secondNumber}".ToString();
                        }
                        else
                        {
                            do
                            {
                                firstNumber = num.Next(1, 10);
                                secondNumber = num.Next(1, 10);
                                total = firstNumber / secondNumber;
                                question.Text = $"{firstNumber} " + "/" + $" {secondNumber}".ToString();

                            } while (firstNumber % secondNumber != 0);
                        }
                        break;
                    case 1:
                        firstNumber = num.Next(3, 13);
                        secondNumber = num.Next(3, 13);
                        answer.Focus();
                        if (firstNumber % secondNumber == 0)
                        {
                            total = firstNumber / secondNumber;
                            question.Text = $"{firstNumber} " + "/" + $" {secondNumber}".ToString();
                            
                        }
                        else
                        {
                            do
                            {
                                firstNumber = num.Next(3, 13);
                                secondNumber = num.Next(3, 13);
                                total = firstNumber / secondNumber;
                                question.Text = $"{firstNumber} " + "/" + $" {secondNumber}".ToString();

                            } while (firstNumber % secondNumber != 0);
                        }
                        break;
                    case 2:

                        firstNumber = num.Next(4, 15);
                        secondNumber = num.Next(4, 15);
                        answer.Focus();
                        if (firstNumber % secondNumber == 0)
                        {
                            question.Text = $"{secondNumber} " + "/" + $" {firstNumber}".ToString();
                            total = secondNumber / firstNumber;
                        }
                        else
                        {
                            do
                            {
                                firstNumber = num.Next(4, 15);
                                secondNumber = num.Next(4, 15);
                                total = firstNumber / secondNumber;
                                question.Text = $"{firstNumber} " + "/" + $" {secondNumber}".ToString();

                            } while (firstNumber % secondNumber != 0);
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