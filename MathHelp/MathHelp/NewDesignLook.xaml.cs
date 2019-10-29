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
    public partial class NewDesignLook : ContentPage
    {
        private static readonly string minus = "\u2212";
        private readonly int difficulty;
        private readonly int numberOfQuestions;
        int firstNumber = 0;
        int secondNumber = 0;
        int total = 0;
        int rightAnswer = 0;
        int wrongAnswer = 0;
        int gameCount = 1;
        readonly List<string> wrongQuestions = new List<string>();
        Random num;

        public NewDesignLook( int difficulty, int numberofQuestions)
        {
            this.difficulty = difficulty;
            this.numberOfQuestions = numberofQuestions;
            InitializeComponent();
            RandomNumber();
            question.Text = "Hello World";
        }

        public NewDesignLook()
        {
            InitializeComponent();
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
                        //answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            //question.Text = $"{secondNumber} {minus} {firstNumber} =";
                            //num1.Text = $"{secondNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {firstNumber}".ToString();
                            question.Text = $"{secondNumber}{minus}{firstNumber}".ToString();
                            total = secondNumber - firstNumber;
                        }
                        else
                        {
                            //question.Text = $"{firstNumber} {minus} {secondNumber} =";
                            //num1.Text = $"{firstNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {secondNumber}".ToString();
                            question.Text = $"{firstNumber}{minus}{secondNumber}".ToString();
                            total = firstNumber - secondNumber;
                        }
                        break;
                    case 1:
                        firstNumber = num.Next(2, 16);
                        secondNumber = num.Next(2, 16);
                        //answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            //question.Text = $"{secondNumber} {minus} {firstNumber} =";
                            //num1.Text = $" {secondNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {firstNumber}".ToString();
                            question.Text = $"{secondNumber}{minus}{firstNumber}".ToString();
                            total = secondNumber - firstNumber;
                        }
                        else
                        {
                            //question.Text = $"{firstNumber} {minus} {secondNumber} =";
                            //num1.Text = $"{firstNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {secondNumber}".ToString();
                            question.Text = $"{firstNumber}{minus}{secondNumber}".ToString();
                            total = firstNumber - secondNumber;
                        }
                        break;
                    case 2:

                        firstNumber = num.Next(2, 21);
                        secondNumber = num.Next(2, 21);
                        //answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            //question.Text = $"{secondNumber} {minus} {firstNumber} =";
                            //num1.Text = $" {secondNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {firstNumber}".ToString();
                            question.Text = $"{secondNumber}{minus}{firstNumber}".ToString();
                            total = secondNumber - firstNumber;
                        }
                        else
                        {
                            //question.Text = $"{firstNumber} {minus} {secondNumber} =";
                            //num1.Text = $"{firstNumber}".ToString();
                            //num2.Text = $"{minus}" + $" {secondNumber}".ToString();
                            question.Text = $"{firstNumber}{minus}{secondNumber}".ToString();
                            total = firstNumber - secondNumber;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            //if (sender == zeroButton)
            //    answer.Text += "0";
            //if (sender == oneButton)
            //    answer.Text += "1";
            //if (sender == twoButton)
            //    answer.Text += "2";
            //if (sender == threeButton)
            //    answer.Text += "3";
            //if (sender == fourButton)
            //    answer.Text += "4";
            //if (sender == fiveButton)
            //    answer.Text += "5";
            //if (sender == sixButton)
            //    answer.Text += "6";
            //if (sender == sevenButton)
            //    answer.Text += "7";
            //if (sender == eightButton)
            //    answer.Text += "8";
            //if (sender == nineButton)
            //    answer.Text += "9";

        }

        private void NumberSelected(object sender, EventArgs e)
        {

        }

        private void Equals_Clicked(object sender, EventArgs e)
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
    }
}