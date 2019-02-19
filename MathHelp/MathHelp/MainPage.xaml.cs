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
        public MainPage()
        {
            InitializeComponent();
            RandomNumber();
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            var total = firstNumber * secondNumber;
            var userAnswer = int.Parse(answer.Text);
            if (userAnswer == total)
            {
                result.TextColor = Color.Green;
                result.Text = "Correct!";
                RandomNumber();
                answer.Text = "";
                answer.Focus();
            }
            else
            {
                result.TextColor = Color.Red;
                result.Text = "Sorry try again!";
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
