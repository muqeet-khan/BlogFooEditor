using BlogFooEditor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BlogFooEditor
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Done.Clicked += Done_Activated;
        }

        private async void Done_Activated(object sender, EventArgs e)
        {
            var post = new Post()
            {
                Content = PostContent.Text,
                Title = PostTitle.Text,
                SubTitle = PostSubTitle.Text

            };
            await Navigation.PushAsync(new ShowResult(post));
        }
    }
}
