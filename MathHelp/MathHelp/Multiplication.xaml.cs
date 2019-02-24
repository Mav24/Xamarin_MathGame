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
	public partial class Multiplication : ContentPage
	{
        int firstNumber = 0;
        int secondNumber = 0;
        int rightAnswer = 0;
        int wrongAnswer = 0;
        int gameCount = 1;
        List<string> wrongQuestions = new List<string>();

        public Multiplication ()
		{
			InitializeComponent ();
            RandomNumber();
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            var total = firstNumber * secondNumber;


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

        private void RandomNumber()
        {
            //wrongQuestions.Sort();
            string message = "Question you need to practice:\n";

            if (gameCount == 5)
            {
                foreach (var wrongAnswer in wrongQuestions)
                {
                    message += wrongAnswer + "\n";
                }
                DisplayAlert("End of Game", $"Correct: {rightAnswer}\n" + $"Wrong: {wrongAnswer}\n" +
                    $"{message}", "OK");
                totalRight.Text = "";
                totalWrong.Text = "";
            }
            else
            {
                Random num = new Random();
                firstNumber = num.Next(2, 10);
                secondNumber = num.Next(2, 10);
                question.Text = $"{firstNumber} " + "X" + $" {secondNumber}".ToString();
            }

        }
    }
}
