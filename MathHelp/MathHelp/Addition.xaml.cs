﻿using System;
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
        private static string plus = "\u002B";
        private int difficulty;
        private int numberOfQuestions;
        int firstNumber = 0;
        int secondNumber = 0;
        int rightAnswer = 0;
        int wrongAnswer = 0;
        int gameCount = 0;
        List<string> wrongQuestions = new List<string>();
        Random num;

        public Addition (int difficulty, int numberOfQuestions)
		{
            InitializeComponent();
            this.difficulty = difficulty;
            this.numberOfQuestions = numberOfQuestions;
            RandomNumber();
			
		}
        public Addition ()
        {
            InitializeComponent();
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            var total = firstNumber + secondNumber;


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
                
            }
            else
            {
                wrongQuestions.Add(question.Text);
                wrongAnswer++;
                totalWrong.TextColor = Color.Red;
                totalWrong.Text = $"Wrong: {wrongAnswer}";
                RandomNumber();
                answer.Text = "";
                
            }
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
                        gameCount++;
                        firstNumber = num.Next(1, 11);
                        secondNumber = num.Next(1, 11);
                        question.Text = $"{firstNumber} " + $"{plus}" + $" {secondNumber}".ToString();
                        answer.Focus();
                        break;
                    case 1:
                        gameCount++;
                        firstNumber = num.Next(4, 16);
                        secondNumber = num.Next(4, 16);
                        question.Text = $"{firstNumber} " + $"{plus}" + $" {secondNumber}".ToString();
                        answer.Focus();
                        break;
                    case 2:
                        gameCount++;
                        firstNumber = num.Next(5, 21);
                        secondNumber = num.Next(5, 21);
                        question.Text = $"{firstNumber} " + $"{plus}" + $" {secondNumber}".ToString();
                        answer.Focus();
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