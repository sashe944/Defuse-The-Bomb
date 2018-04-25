using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DefuseTheBombApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void Btn_PlayClicked(object sender,EventArgs args)
        {
            User u = new User();
            u.Username = UserName.Text;

            Navigation.PushModalAsync(new GamePage(u));
        }
	}
}
