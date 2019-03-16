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
	public partial class Subtraction : ContentPage
	{

        private static string minus = "\u2212";
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

        public Subtraction(int difficulty, int numberOfQuestions)
        {
            this.difficulty = difficulty;
            this.numberOfQuestions = numberOfQuestions;
            InitializeComponent();
            RandomNumber();
        }

        public Subtraction ()
		{
			InitializeComponent ();
		}
        
        async void RandomNumber()
        {
            string message = "Questions you need to practice:\n";
            num = new Random();
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
                        firstNumber = num.Next(1, 11);
                        secondNumber = num.Next(1, 11);
                        answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} {minus} {firstNumber} =";
                            //num1.Text = $"{secondNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {firstNumber}".ToString();
                            total = secondNumber - firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} {minus} {secondNumber} =";
                            //num1.Text = $"{firstNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {secondNumber}".ToString();
                            total = firstNumber - secondNumber;
                        }
                        break;
                    case 1:
                        firstNumber = num.Next(2, 16);
                        secondNumber = num.Next(2, 16);
                        answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} {minus} {firstNumber} =";
                            //num1.Text = $" {secondNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {firstNumber}".ToString();
                            total = secondNumber - firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} {minus} {secondNumber} =";
                            //num1.Text = $"{firstNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {secondNumber}".ToString();
                            total = firstNumber - secondNumber;
                        }
                        break;
                    case 2:

                        firstNumber = num.Next(2, 21);
                        secondNumber = num.Next(2, 21);
                        answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} {minus} {firstNumber} =";
                            //num1.Text = $" {secondNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {firstNumber}".ToString();
                            total = secondNumber - firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} {minus} {secondNumber} =";
                            //num1.Text = $"{firstNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {secondNumber}".ToString();
                            total = firstNumber - secondNumber;
                        }
                        break;
                    default:
                        break;
                }
            }
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

        private void Exit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}