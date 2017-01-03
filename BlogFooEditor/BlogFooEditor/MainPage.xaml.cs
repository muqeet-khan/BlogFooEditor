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

            ToolbarItem nav1 = new ToolbarItem("Preview", "add.png",async () =>
            {
                var post = new Post()
                {
                    Content = PostContent.Text,
                    Title = PostTitle.Text,
                    SubTitle = PostSubTitle.Text

                };
                await Navigation.PushAsync(new ShowResult(post));
            });
            ToolbarItems.Add(nav1);
        }
    }
}
