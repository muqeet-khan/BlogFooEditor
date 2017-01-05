using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace BlogFooEditor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if( Device.OS == TargetPlatform.iOS)
            {
                MainPage = new NavigationPage(new BlogFooEditor.MainPage())
                {
                    BarBackgroundColor = Color.FromRgb(101, 157, 247),
                    BarTextColor = Color.FromRgb(252,252,252)
                };
            }
            else
            {
                MainPage = new NavigationPage(new BlogFooEditor.MainPage());
            }

            //MainPage = new BlogFooEditor.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
