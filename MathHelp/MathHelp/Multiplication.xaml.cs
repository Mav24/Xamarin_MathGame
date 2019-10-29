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
        private static readonly string multiple = "\u00D7";
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

        public Multiplication(int difficulty, int numberofQuestions)
        {
            this.difficulty = difficulty;
            this.numberOfQuestions = numberofQuestions;
            InitializeComponent();
            RandomNumber();
        }

        public Multiplication()
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
                        firstNumber = num.Next(1, 6);
                        secondNumber = num.Next(1, 6);
                        //answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} {multiple} {firstNumber} = ?".ToString();
                            total = secondNumber * firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} {multiple} {secondNumber} = ?".ToString();
                            total = firstNumber * secondNumber;
                        }
                        break;
                    case 1:
                        firstNumber = num.Next(3, 11);
                        secondNumber = num.Next(2, 11);
                        //answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} {multiple} {firstNumber} = ?".ToString();
                            total = secondNumber * firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} {multiple} {secondNumber} = ?".ToString();
                            total = firstNumber * secondNumber;
                        }
                        break;
                    case 2:

                        firstNumber = num.Next(5, 15);
                        secondNumber = num.Next(5, 15);
                        //answer.Focus();
                        if (firstNumber < secondNumber)
                        {
                            question.Text = $"{secondNumber} {multiple} {firstNumber} = ?".ToString();
                            total = secondNumber * firstNumber;
                        }
                        else
                        {
                            question.Text = $"{firstNumber} {multiple} {secondNumber} = ?".ToString();
                            total = firstNumber * secondNumber;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            answer.Text += button.Text;

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

        private void Exit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            answer.Text = "";
        }


        //      private static string multiple = "\u00D7";
        //      private int difficulty;
        //      private int numberOfQuestions;
        //      int firstNumber = 0;
        //      int secondNumber = 0;
        //      int rightAnswer = 0;
        //      int wrongAnswer = 0;
        //      int gameCount = 1;
        //      List<string> wrongQuestions = new List<string>();

        //      Random num;

        //      public Multiplication (int difficulty, int numberOfQuestions)
        //{
        //          this.difficulty = difficulty;
        //          this.numberOfQuestions = numberOfQuestions;
        //	InitializeComponent ();
        //          RandomNumber();

        //          answer.Completed += Submit_Clicked;
        //      }
        //      public Multiplication()
        //      {
        //          InitializeComponent();
        //      }

        //      private void Submit_Clicked(object sender, EventArgs e)
        //      {
        //          var total = firstNumber * secondNumber;


        //          if (!int.TryParse(answer.Text, out int userAnswer))
        //          {
        //              DisplayAlert("Error", "Numeric values only", "Try Again!");
        //          }
        //          else if (userAnswer == total)
        //          {
        //              rightAnswer++;
        //              totalRight.TextColor = Color.Green;
        //              totalRight.Text = $"Correct: {rightAnswer}";
        //              RandomNumber();
        //              answer.Text = "";
        //              gameCount++;
        //          }
        //          else
        //          {
        //              wrongQuestions.Add(num1.Text + " " + num2.Text);
        //              wrongAnswer++;
        //              totalWrong.TextColor = Color.Red;
        //              totalWrong.Text = $"Wrong: {wrongAnswer}";
        //              RandomNumber();
        //              answer.Text = "";
        //              gameCount++;
        //          }

        //      }

        //      async void RandomNumber()
        //      {

        //          //wrongQuestions.Sort();
        //          string message = "Questions you need to practice:\n";
        //          num = new Random();
        //          if (gameCount == numberOfQuestions)
        //          {
        //              foreach (var wrongAnswer in wrongQuestions)
        //              {
        //                  message += wrongAnswer + "\n";
        //              }
        //              await DisplayAlert("End of Game", $"Correct: {rightAnswer}\n" + $"Wrong: {wrongAnswer}\n" +
        //                  $"{message}", "OK");
        //              totalRight.Text = "";
        //              totalWrong.Text = "";
        //              await Navigation.PopModalAsync();
        //          }
        //          else
        //          {
        //              switch (difficulty)
        //              {
        //                  case 0:
        //                      firstNumber = num.Next(1, 6);
        //                      secondNumber = num.Next(1, 6);
        //                      num1.Text = $"{firstNumber}".ToString();
        //                      num2.Text = $"{multiple}" + $" {secondNumber}".ToString();

        //                      answer.Focus();
        //                      break;
        //                  case 1:
        //                      firstNumber = num.Next(3, 11);
        //                      secondNumber = num.Next(3, 11);
        //                      num1.Text = $"{firstNumber}".ToString();
        //                      num2.Text = $"{multiple}" + $" {secondNumber}".ToString();
        //                      answer.Focus();
        //                      break;
        //                  case 2:

        //                      firstNumber = num.Next(5, 13);
        //                      secondNumber = num.Next(5, 13);
        //                      num1.Text = $"{firstNumber}".ToString();
        //                      num2.Text = $"{multiple}" + $" {secondNumber}".ToString();
        //                      answer.Focus();
        //                      break;
        //                  default:
        //                      break;
        //              }
        //          }


        //      }

        //      private void Exit_Clicked(object sender, EventArgs e)
        //      {
        //          Navigation.PopModalAsync();
        //      }
    }
}
