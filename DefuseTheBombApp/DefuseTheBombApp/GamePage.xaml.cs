using Plugin.TextToSpeech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace DefuseTheBombApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
        User u;
        static string bomb = new Random().Next(1, 4).ToString();
        private int level = 1;
        string currentLevel;
      
		public GamePage (User u)
		{
			InitializeComponent ();
            this.u = u;
            lblUserName.Text = "Нека играта започне " + u.Username;
            
  		}

         private void Btn_Clicked(object sender, EventArgs e)
        {
            //Button myButton = new Button();
            Button button = sender as Button;

            //Game Over
          
            if (button.Text == bomb)
                {
              
                    DisplayAlert("Бомбата гръмна", "БУУМ!", "Опитай отново");
                    lblScore.IsVisible = false;
                    u.Score = 0;
                    bomb = new Random().Next(1, 4).ToString();
                }
                else
                {
                    u.Score += 1;
                    DisplayAlert("Бомбата е обезвредена", "Успешно обезвредена","Продължи да играеш");
                    lblScore.IsVisible = true;
                    lblScore.Text ="Точките ти са " + u.Score;
                    bomb = new Random().Next(1, 4).ToString();
                }

          
            for(int i = 0; i <= u.Score; i = i + 3)
            {

               
               
                if (i==3)
                {
                    level++;
                    //myButton.Text = "Бутон от новото ниво";
                    //myButton.Clicked += Btn_Clicked;
                    //myStackLayout.Children.Add(myButton);
                    //myButton.IsVisible = true;

                }

                else
                {
                    level = 1;
                    //myStackLayout.Children.Remove(myButton);
                    //myButton.IsVisible = false;

                }
             
            }
             currentLevel = lblLevel.Text = "Ти си на ниво " + level;
            CrossTextToSpeech.Current.Speak(currentLevel);
        }
	}
}